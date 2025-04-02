using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.InteropServices.JavaScript;
using Iskra.StdWebApi.Api;
using Iskra.StdWebApi.Attributes;
using Iskra.StdWebGenerator.Extensions;
using Iskra.StdWebGenerator.JSObjectMarkers;

namespace Iskra.StdWebGenerator;

public static class TypeNameGenerator
{
    private static readonly Dictionary<Type, string> TypeMapping = new()
    {
        { typeof(void), "void" },
        { typeof(int), "int" },
        { typeof(long), "long" },
        { typeof(bool), "bool" },
        { typeof(double), "double" },
        { typeof(string), "string" },
        { typeof(object), "object" },
        { typeof(JSObject), "JSObject" },
        { typeof(JSObjectArray), "JSObject" },
        { typeof(JSObjectFunction), "JSObject" },
        { typeof(ObjectForJS), "object" },
    };

    public static string Execute(ParameterInfo parameterInfo)
    {
        var nullabilityInfo = new NullabilityInfoContext().Create(parameterInfo);
        var asParams = parameterInfo.IsDefinedAsParams();
        return (asParams ? "params " : "") + Execute(parameterInfo.ParameterType, nullabilityInfo, true);
    }

    [Obsolete("Use Execute(MyType type)")] public static bool NotNullProp { get; set; }

    [Obsolete("Use Execute(MyType type)")]
    public static string Execute(Type type, NullabilityInfo? nullabilityInfo, bool fromRead = false)
    {
        var fallbackNullability =
            new NullabilityInfoContext().Create(typeof(TypeNameGenerator).GetProperty(nameof(NotNullProp)));

        return Execute(MyType.From(type, nullabilityInfo ?? fallbackNullability, fromRead));
    }

    public static string Execute(MyType type)
    {
        var nullableIndicator = type.IsNullable ? "?" : "";

        if (type.Type.IsDefined(typeof(GenerateBindingsAttribute)))
        {
            return type.Type.Name + nullableIndicator;
        }

        if (TypeMapping.TryGetValue(type.Type, out var typeMappingName))
        {
            return typeMappingName + nullableIndicator;
        }

        if (type.Type.IsArray && type.ElementType is not null)
        {
            if (type.Type.GetElementType() is not { } arrayElementType)
            {
                throw new Exception($"Array {type} has not element type.");
            }

            return Execute(type.ElementType) + "[]" + nullableIndicator;
        }

        if (type.Type.IsGenericType)
        {
            var genericDef = type.Type.GetGenericTypeDefinition();

            if (genericDef == typeof(OneOf<,>))
            {
                var t1 = Execute(type.GenericTypeArguments[0]);
                var t2 = Execute(type.GenericTypeArguments[1]);

                return $"OneOf<{t1},{t2}>" + nullableIndicator;
            }

            if (genericDef == typeof(OneOf<,,>))
            {
                var t1 = Execute(type.GenericTypeArguments[0]);
                var t2 = Execute(type.GenericTypeArguments[1]);
                var t3 = Execute(type.GenericTypeArguments[2]);

                return $"OneOf<{t1}, {t2}, {t3}>" + nullableIndicator;
            }

            if (genericDef == typeof(OneOf<,,,>))
            {
                var t1 = Execute(type.GenericTypeArguments[0]);
                var t2 = Execute(type.GenericTypeArguments[1]);
                var t3 = Execute(type.GenericTypeArguments[2]);
                var t4 = Execute(type.GenericTypeArguments[3]);

                return $"OneOf<{t1}, {t2}, {t3}, {t4}>" + nullableIndicator;
            }

            if (genericDef == typeof(OneOf<,,,,>))
            {
                var t1 = Execute(type.GenericTypeArguments[0]);
                var t2 = Execute(type.GenericTypeArguments[1]);
                var t3 = Execute(type.GenericTypeArguments[2]);
                var t4 = Execute(type.GenericTypeArguments[3]);
                var t5 = Execute(type.GenericTypeArguments[4]);

                return $"OneOf<{t1}, {t2}, {t3}, {t4}, {t5}>" + nullableIndicator;
            }

            if (genericDef == typeof(Task<>))
            {
                var t1 = Execute(type.GenericTypeArguments[0]);
                return $"Task<{t1}>" + nullableIndicator;
            }

            if (genericDef == typeof(IList<>))
            {
                var t1 = Execute(type.GenericTypeArguments[0]);
                return $"IList<{t1}>" + nullableIndicator;
            }

            if (genericDef == typeof(IReadOnlyList<>))
            {
                var t1 = Execute(type.GenericTypeArguments[0]);
                return $"IReadOnlyList<{t1}>" + nullableIndicator;
            }

            throw new NotSupportedException($"Type {type} is not supported.");
        }

        if (type.Type == typeof(Task))
        {
            return "Task" + nullableIndicator;
        }

        throw new NotSupportedException($"Type {type} is not supported.");
    }
}