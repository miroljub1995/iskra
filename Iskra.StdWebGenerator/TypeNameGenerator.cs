using System.Reflection;
using System.Runtime.CompilerServices;
using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebGenerator;

public static class TypeNameGenerator
{
    private static readonly HashSet<Type> SameNameTypes =
    [
        typeof(int),
    ];

    public static string Execute(Type? type, ICustomAttributeProvider? attrs = null)
    {
        if (type is null)
        {
            return "null";
        }

        var isNullable = attrs?.IsDefined(typeof(NullableAttribute), inherit: false) ?? false;
        var nullableIndicator = isNullable ? "?" : "";

        if (type.IsDefined(typeof(GenerateBindingsAttribute)))
        {
            return type.Name + nullableIndicator;
        }

        if (SameNameTypes.Contains(type))
        {
            return type.Name + nullableIndicator;
        }

        throw new NotSupportedException($"Type {type} is not supported.");
    }
}