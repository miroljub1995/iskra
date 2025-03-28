using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;
using Iskra.StdWebApi.Api;
using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebGenerator.Extensions;

public static class TypeExtensions
{
    public static bool IsStatic(this Type type)
        => type is { IsAbstract: true, IsSealed: true };

    public static bool IsJSObjectWrapper(this Type type)
    {
        // if (type.IsArray && type.GetElementType() is { } elementType)
        // {
        //     return IsJSObjectWrapper(elementType);
        // }

        return type.IsDefined(typeof(GenerateBindingsAttribute), false);
    }

    public static bool IsOneOf(this Type type)
    {
        return type.IsGenericType
               && type.GetGenericTypeDefinition() is { } def
               && (
                   def == typeof(OneOf<,>)
                   || def == typeof(OneOf<,,>)
                   || def == typeof(OneOf<,,,>)
                   || def == typeof(OneOf<,,,,>)
               );
    }

    public static Type ToMarshalAsJSType(this Type type)
    {
        return type switch
        {
            _ when type == typeof(int) => typeof(JSType.Number),
            _ when type == typeof(float) => typeof(JSType.Number),

            _ when type == typeof(string) => typeof(JSType.String),

            _ when type.IsJSObjectWrapper() => typeof(JSType.Object),
            _ when type == typeof(JSObject) => typeof(JSType.Object),
            _ => throw new Exception($"Type {type} is not supported."),
        };
    }
}