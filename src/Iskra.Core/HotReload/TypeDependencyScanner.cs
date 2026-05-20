using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Reflection.Emit;

namespace Iskra.Core.HotReload;

// This class only runs when hot reload is active, which requires the interpreter
// (no trimming). The trimmer annotations are suppressed because the IL and metadata
// are guaranteed to be present in that configuration.
[RequiresUnreferencedCode("TypeDependencyScanner uses reflection and IL scanning that is only valid when hot reload is active (interpreter mode).")]
internal static class TypeDependencyScanner
{
    private static readonly Dictionary<short, OpCode> s_opCodes = typeof(OpCodes)
        .GetFields(BindingFlags.Public | BindingFlags.Static)
        .Where(f => f.FieldType == typeof(OpCode))
        .Select(f => (OpCode)f.GetValue(null)!)
        .ToDictionary(op => op.Value);

    /// <summary>
    /// Returns all types transitively referenced by <paramref name="type"/>'s methods.
    /// Only follows into types from the same assembly (user code).
    /// </summary>
    public static HashSet<Type> GetDependencies(Type type)
    {
        var result = new HashSet<Type>();
        Collect(type, type.Assembly, result);
        return result;
    }

    private static void Collect(Type type, Assembly boundary, HashSet<Type> visited)
    {
        if (!visited.Add(type))
            return;

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
            // GetMethodBody() throws for methods without managed IL (P/Invoke, extern,
            // runtime-generated methods like delegate Invoke, array accessors, etc.).
            // These have no IL to scan, so we skip them.
            try { body = method.GetMethodBody(); }
            catch { continue; }

            if (body is null)
                continue;

            var il = body.GetILAsByteArray();
            if (il is null)
                continue;

            foreach (var dep in ScanIL(il, method.Module))
            {
                if (dep.Assembly == boundary)
                    Collect(dep, boundary, visited);
                else
                    visited.Add(dep);
            }
        }
    }

    private static List<Type> ScanIL(byte[] il, Module module)
    {
        var types = new List<Type>();
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
                    ResolveMethodTypes(module, methodToken, types);
                    break;

                case OperandType.InlineField:
                    int fieldToken = ReadI32(il, ref pos);
                    if (TryResolve(() => module.ResolveField(fieldToken), out var field))
                    {
                        if (field!.DeclaringType is { } ft)
                            types.Add(ft);
                        types.Add(field.FieldType);
                    }
                    break;

                case OperandType.InlineType:
                case OperandType.InlineTok:
                    int typeToken = ReadI32(il, ref pos);
                    if (TryResolve(() => module.ResolveType(typeToken), out var resolved) && resolved is not null)
                        types.Add(resolved);
                    else if (TryResolve(() => module.ResolveMethod(typeToken)?.DeclaringType, out var dt) && dt is not null)
                        types.Add(dt);
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

        return types;
    }

    private static void ResolveMethodTypes(Module module, int token, List<Type> types)
    {
        if (!TryResolve(() => module.ResolveMethod(token), out var method) || method is null)
            return;

        if (method.DeclaringType is { } dt)
            types.Add(dt);

        if (method is MethodInfo mi && mi.IsGenericMethod)
        {
            foreach (var ga in mi.GetGenericArguments())
                types.Add(ga);
        }

        if (method.DeclaringType is { IsGenericType: true })
        {
            foreach (var ga in method.DeclaringType.GetGenericArguments())
                types.Add(ga);
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
