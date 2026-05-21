using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Reflection.Emit;
using Iskra.Core.Components;

namespace Iskra.Core.HotReload;

[RequiresUnreferencedCode("TypeDependencyGraph uses reflection and IL scanning that is only valid when hot reload is active (interpreter mode).")]
public sealed class TypeDependencyGraph
{
    private static readonly Dictionary<short, OpCode> s_opCodes = typeof(OpCodes)
        .GetFields(BindingFlags.Public | BindingFlags.Static)
        .Where(f => f.FieldType == typeof(OpCode))
        .Select(f => (OpCode)f.GetValue(null)!)
        .ToDictionary(op => op.Value);

    private readonly Dictionary<Type, HashSet<Type>> _edges = new();
    private readonly HashSet<Type> _invalidated = new();
    private readonly Lock _lock = new();

    public bool IsDependentTo(Type a, IEnumerable<Type> types)
    {
        var targets = new HashSet<Type>(types);

        if (targets.Contains(a))
            return true;

        lock (_lock)
        {
            var visited = new HashSet<Type>();
            var queue = new Queue<Type>();
            queue.Enqueue(a);
            visited.Add(a);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                // Lazily scan types not yet in the graph or marked invalidated.
                if (_invalidated.Remove(current) || !_edges.ContainsKey(current))
                {
                    _edges[current] = ScanDirectDependencies(current);
                }

                var deps = _edges[current];

                foreach (var dep in deps)
                {
                    if (targets.Contains(dep))
                        return true;

                    if (IsUserType(dep) && visited.Add(dep))
                        queue.Enqueue(dep);
                }
            }

            return false;
        }
    }

    public void Invalidate(Type[] types)
    {
        lock (_lock)
        {
            foreach (var type in types)
            {
                _invalidated.Add(type);
            }
        }
    }

    private static bool IsUserAssembly(Assembly asm)
    {
        var name = asm.GetName().Name;
        if (name is null)
            return false;

        return !name.StartsWith("System.", StringComparison.Ordinal)
            && !name.StartsWith("Microsoft.", StringComparison.Ordinal)
            && !name.Equals("System", StringComparison.Ordinal)
            && !name.Equals("netstandard", StringComparison.Ordinal)
            && !name.Equals("mscorlib", StringComparison.Ordinal);
    }

    private static bool IsUserType(Type type) => IsUserAssembly(type.Assembly);

    private static HashSet<Type> ScanDirectDependencies(Type type)
    {
        var ctorTypes = new HashSet<Type>();
        var otherTypes = new HashSet<Type>();

        var methods = type.GetMethods(
            BindingFlags.Instance | BindingFlags.Static |
            BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.DeclaredOnly);

        var ctors = type.GetConstructors(
            BindingFlags.Instance | BindingFlags.Static |
            BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.DeclaredOnly);

        foreach (var method in methods.Cast<MethodBase>().Concat(ctors))
        {
            MethodBody? body;
            try { body = method.GetMethodBody(); }
            catch { continue; }

            if (body is null)
                continue;

            var il = body.GetILAsByteArray();
            if (il is null)
                continue;

            ScanIL(il, method.Module, ctorTypes, otherTypes);
        }

        ctorTypes.Remove(type);
        otherTypes.Remove(type);

        // Exclude IComponent types that are only referenced via their constructor.
        // Child components manage their own hot reload, so the parent doesn't need
        // to track them as dependencies.
        var result = new HashSet<Type>(otherTypes);
        foreach (var t in ctorTypes)
        {
            if (!otherTypes.Contains(t) && typeof(IComponent).IsAssignableFrom(t))
                continue;

            result.Add(t);
        }

        return result;
    }

    private static void ScanIL(byte[] il, Module module, HashSet<Type> ctorTypes, HashSet<Type> otherTypes)
    {
        int pos = 0;

        while (pos < il.Length)
        {
            short code;
            if (il[pos] == 0xFE)
            {
                if (pos + 1 >= il.Length)
                    break;
                code = (short)(0xFE00 | il[pos + 1]);
                pos += 2;
            }
            else
            {
                code = il[pos];
                pos += 1;
            }

            if (!s_opCodes.TryGetValue(code, out var opCode))
                break;

            switch (opCode.OperandType)
            {
                case OperandType.InlineMethod:
                    int methodToken = ReadI32(il, ref pos);
                    ResolveMethodTypes(module, methodToken, ctorTypes, otherTypes);
                    break;

                case OperandType.InlineField:
                    int fieldToken = ReadI32(il, ref pos);
                    if (TryResolve(() => module.ResolveField(fieldToken), out var field))
                    {
                        if (field!.DeclaringType is { } ft)
                            otherTypes.Add(ft);
                        otherTypes.Add(field.FieldType);
                    }
                    break;

                case OperandType.InlineType:
                case OperandType.InlineTok:
                    int typeToken = ReadI32(il, ref pos);
                    if (TryResolve(() => module.ResolveType(typeToken), out var resolved) && resolved is not null)
                        otherTypes.Add(resolved);
                    else if (TryResolve(() => module.ResolveMethod(typeToken)?.DeclaringType, out var dt) && dt is not null)
                        otherTypes.Add(dt);
                    break;

                case OperandType.InlineI:
                case OperandType.InlineBrTarget:
                case OperandType.InlineString:
                case OperandType.InlineSig:
                case OperandType.ShortInlineR:
                    pos += 4;
                    break;

                case OperandType.InlineI8:
                case OperandType.InlineR:
                    pos += 8;
                    break;

                case OperandType.ShortInlineBrTarget:
                case OperandType.ShortInlineI:
                case OperandType.ShortInlineVar:
                    pos += 1;
                    break;

                case OperandType.InlineVar:
                    pos += 2;
                    break;

                case OperandType.InlineSwitch:
                    int count = ReadI32(il, ref pos);
                    pos += count * 4;
                    break;

                case OperandType.InlineNone:
                    break;
            }
        }
    }

    private static void ResolveMethodTypes(Module module, int token, HashSet<Type> ctorTypes, HashSet<Type> otherTypes)
    {
        if (!TryResolve(() => module.ResolveMethod(token), out var method) || method is null)
            return;

        var isCtor = method is ConstructorInfo;
        var target = isCtor ? ctorTypes : otherTypes;

        if (method.DeclaringType is { } dt)
            target.Add(dt);

        if (method is MethodInfo mi && mi.IsGenericMethod)
        {
            foreach (var ga in mi.GetGenericArguments())
                otherTypes.Add(ga);
        }

        if (method.DeclaringType is { IsGenericType: true })
        {
            foreach (var ga in method.DeclaringType.GetGenericArguments())
                otherTypes.Add(ga);
        }
    }

    private static int ReadI32(byte[] il, ref int pos)
    {
        int val = BitConverter.ToInt32(il, pos);
        pos += 4;
        return val;
    }

    private static bool TryResolve<T>(Func<T?> resolve, out T? result)
    {
        try
        {
            result = resolve();
            return result is not null;
        }
        catch
        {
            result = default;
            return false;
        }
    }
}
