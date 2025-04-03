using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices.JavaScript;
using Iskra.StdWebGenerator.Extensions;
using Iskra.StdWebGenerator.JSObjectMarkers;

namespace Iskra.StdWebGenerator;

public static class MyTypeToJSLevelExtensions
{
    [return: NotNullIfNotNull("type")]
    public static MyType? ToJSLevelType(this MyType? type)
        => type switch
        {
            null => null,
            _ when type.Type.IsJSObjectWrapper() => new MyType(typeof(JSObject), type.IsNullable, null, []),
            _ when type.Type == typeof(bool) => type,
            _ when type.Type == typeof(int) => type,
            _ when type.Type == typeof(long) => type,
            _ when type.Type == typeof(double) => type,
            _ when type.Type == typeof(string) => type,
            _ when type.Type == typeof(JSObject) => type,
            _ when type.Type == typeof(JSObjectArray) => type,
            _ when type.Type == typeof(JSObjectFunction) => type,
            _ when type.Type == typeof(ObjectForJS) => type,
            _ when type.Type.IsIReadOnlyList() => new MyType(typeof(JSObjectArray), type.IsNullable, null, []),
            _ when type.Type == typeof(Task) => type,
            _ when type.Type.IsSubclassOf(typeof(Delegate)) => new MyType(
                Type: typeof(JSObjectFunction),
                IsNullable: type.IsNullable,
                ElementType: null,
                GenericTypeArguments: []
            ),
            _ when type.Type == typeof(object) => type with { Type = typeof(ObjectForJS) },
            _ when type.Type.IsOneOf() => type with { Type = typeof(ObjectForJS) },
            _ => throw new Exception($"Unsupported type {type}")
        };
}