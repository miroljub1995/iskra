using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;
using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebGenerator.Extensions;

public static class TypeExtensions
{
    public static bool IsJSObjectWrapper(this Type type)
        => type.IsDefined(typeof(GenerateBindingsAttribute), false);

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