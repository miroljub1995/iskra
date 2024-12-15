using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;
using Iskra.StdWebApi.Attributes;
using Iskra.StdWebGenerator.Extensions;

namespace Iskra.StdWebGenerator;

public static class TypeNameGenerator
{
    private static readonly Dictionary<Type, string> TypeMapping = new()
    {
        { typeof(void), "void" },
        { typeof(int), "int" },
        { typeof(object), "object" },
        { typeof(JSObject), "JSObject" },
    };

    public static string Execute(Type? type, ICustomAttributeProvider? attrs = null, int nullableStateIndex = 0)
    {
        if (type is null)
        {
            return "null";
        }

        if (type.IsGenericParameter)
        {
            return type.Name;
        }

        var isNullable = type.IsNullable(attrs, nullableStateIndex);

        var nullableIndicator = isNullable ? "?" : "";

        if (type.IsDefined(typeof(GenerateBindingsAttribute)))
        {
            return type.Name + nullableIndicator;
        }

        if (TypeMapping.TryGetValue(type, out var typeMappingName))
        {
            return typeMappingName + nullableIndicator;
        }

        if (type.IsArray && type.GetElementType() is { } arrayElementType)
        {
            var asParams = attrs?.IsDefined(typeof(AsParamsAttribute), false) ?? false;
            var asParamsPrefix = asParams ? "params " : "";

            var elementName = Execute(arrayElementType, attrs, nullableStateIndex + 1);
            return $"{asParamsPrefix}{elementName}[]" + nullableIndicator;
        }

        throw new NotSupportedException($"Type {type} is not supported.");
    }
}