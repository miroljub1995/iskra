using System.Reflection;
using System.Runtime.CompilerServices;
using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebGenerator.Extensions;

public static class TypeExtensions
{
    public static bool IsNullable(this Type type, ICustomAttributeProvider? attrs = null, int nullableStateIndex = 0)
    {
        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
        {
            return true;
        }


        var nullableAttribute =
            attrs?.GetCustomAttributes(typeof(NullableAttribute), false).SingleOrDefault() as NullableAttribute;

        var isNullable =
            nullableAttribute?.NullableFlags.Length > nullableStateIndex &&
            nullableAttribute?.NullableFlags[nullableStateIndex] == 2;

        return isNullable;
    }

    public static bool IsJSObjectWrapper(this Type type)
        => type.IsDefined(typeof(GenerateBindingsAttribute), false);
}