using System.Reflection;
using System.Runtime.InteropServices.JavaScript;
using Iskra.StdWebApi.Api;
using Iskra.StdWebApi.Attributes;
using Iskra.StdWebGenerator.Extensions;

namespace Iskra.StdWebGenerator;

public static class TypeNameGenerator
{
    private static readonly Dictionary<Type, string> TypeMapping = new()
    {
        { typeof(void), "void" },
        { typeof(int), "int" },
        { typeof(bool), "bool" },
        { typeof(double), "double" },
        { typeof(string), "string" },
        { typeof(object), "object" },
        { typeof(JSObject), "JSObject" },
    };

    public static string Execute(ParameterInfo parameterInfo)
    {
        var nullabilityInfo = new NullabilityInfoContext().Create(parameterInfo);
        var asParams = parameterInfo.IsDefinedAsParams();
        return (asParams ? "params " : "") + Execute(parameterInfo.ParameterType, nullabilityInfo, true);
    }

    public static string Execute(PropertyInfo propertyInfo)
    {
        var nullabilityInfo = new NullabilityInfoContext().Create(propertyInfo);
        return Execute(propertyInfo.PropertyType, nullabilityInfo, propertyInfo.CanRead);
    }

    public static string Execute(Type type, NullabilityInfo? nullabilityInfo, bool fromRead = false)
    {
        var nullabilityState = fromRead ? nullabilityInfo?.ReadState : nullabilityInfo?.WriteState;

        var nullableIndicator = nullabilityState == NullabilityState.Nullable ? "?" : "";

        if (type.IsDefined(typeof(GenerateBindingsAttribute)))
        {
            return type.Name + nullableIndicator;
        }

        if (TypeMapping.TryGetValue(type, out var typeMappingName))
        {
            return typeMappingName + nullableIndicator;
        }

        if (type.IsArray)
        {
            if (type.GetElementType() is not { } arrayElementType)
            {
                throw new Exception($"Array {type} has not element type.");
            }

            return Execute(arrayElementType, nullabilityInfo?.ElementType, true) + "[]" + nullableIndicator;
        }

        if (type.IsGenericType)
        {
            var genericDef = type.GetGenericTypeDefinition();
            var genericArgs = type.GetGenericArguments();

            if (genericDef == typeof(Nullable<>))
            {
                return Execute(genericArgs[0], null, true) + nullableIndicator;
            }

            if (genericDef == typeof(OneOf<,>))
            {
                var t1 = Execute(genericArgs[0], nullabilityInfo?.GenericTypeArguments[0], true);
                var t2 = Execute(genericArgs[1], nullabilityInfo?.GenericTypeArguments[1], true);

                return $"OneOf<{t1},{t2}>";
            }

            if (genericDef == typeof(OneOf<,,>))
            {
                var t1 = Execute(genericArgs[0], nullabilityInfo?.GenericTypeArguments[0], true);
                var t2 = Execute(genericArgs[1], nullabilityInfo?.GenericTypeArguments[1], true);
                var t3 = Execute(genericArgs[2], nullabilityInfo?.GenericTypeArguments[2], true);

                return $"OneOf<{t1}, {t2}, {t3}>";
            }

            if (genericDef == typeof(OneOf<,,,>))
            {
                var t1 = Execute(genericArgs[0], nullabilityInfo?.GenericTypeArguments[0], true);
                var t2 = Execute(genericArgs[1], nullabilityInfo?.GenericTypeArguments[1], true);
                var t3 = Execute(genericArgs[2], nullabilityInfo?.GenericTypeArguments[2], true);
                var t4 = Execute(genericArgs[3], nullabilityInfo?.GenericTypeArguments[3], true);

                return $"OneOf<{t1}, {t2}, {t3}, {t4}>";
            }

            if (genericDef == typeof(OneOf<,,,,>))
            {
                var t1 = Execute(genericArgs[0], nullabilityInfo?.GenericTypeArguments[0], true);
                var t2 = Execute(genericArgs[1], nullabilityInfo?.GenericTypeArguments[1], true);
                var t3 = Execute(genericArgs[2], nullabilityInfo?.GenericTypeArguments[2], true);
                var t4 = Execute(genericArgs[3], nullabilityInfo?.GenericTypeArguments[3], true);
                var t5 = Execute(genericArgs[4], nullabilityInfo?.GenericTypeArguments[4], true);

                return $"OneOf<{t1}, {t2}, {t3}, {t4}, {t5}>";
            }
        }

        throw new NotSupportedException($"Type {type} is not supported.");
    }
}