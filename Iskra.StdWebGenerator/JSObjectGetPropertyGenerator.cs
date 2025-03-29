using System.Runtime.InteropServices.JavaScript;
using Iskra.StdWebGenerator.Extensions;

namespace Iskra.StdWebGenerator;

public record JSObjectGetPropertyGeneratorRes(
    string Name,
    MyType ReturnType
);

public static class JSObjectGetPropertyGenerator
{
    public static JSObjectGetPropertyGeneratorRes Execute(MyType type)
    {
        var asNullableSuffix = type.IsNullable ? "AsNullable" : "";

        return type switch
        {
            _ when type.Type.IsArray => new(
                Name: $"GetPropertyAsJSObjectV2{asNullableSuffix}",
                ReturnType: new MyType(
                    Type: typeof(JSObject),
                    IsNullable: type.IsNullable,
                    ElementType: null,
                    GenericTypeArguments: []
                )
            ),
            _ when type.Type == typeof(bool) => new(
                Name: $"GetPropertyAsBoolean{asNullableSuffix}",
                ReturnType: type
            ),
            _ when type.Type == typeof(int) => new(
                Name: $"GetPropertyAsInt32{asNullableSuffix}",
                ReturnType: type
            ),
            _ when type.Type == typeof(long) => new(
                Name: $"GetPropertyAsInt64{asNullableSuffix}",
                ReturnType: type
            ),
            _ when type.Type == typeof(double) => new(
                Name: $"GetPropertyAsDouble{asNullableSuffix}",
                ReturnType: type
            ),
            _ when type.Type == typeof(string) => new(
                Name: $"GetPropertyAsStringV2{asNullableSuffix}",
                ReturnType: type
            ),
            _ when type.Type == typeof(JSObject) => new(
                Name: $"GetPropertyAsJSObjectV2{asNullableSuffix}",
                ReturnType: type
            ),
            _ when type.Type.IsOneOf() => new(
                Name: $"GetPropertyAsOneOf{asNullableSuffix}",
                ReturnType: new MyType(
                    Type: typeof(JSObject),
                    IsNullable: type.IsNullable,
                    ElementType: null,
                    GenericTypeArguments: []
                )
            ),
            _ when type.Type.IsJSObjectWrapper() => new(
                Name: $"GetPropertyAsJSObjectV2{asNullableSuffix}",
                ReturnType: new MyType(
                    Type: typeof(JSObject),
                    IsNullable: type.IsNullable,
                    ElementType: null,
                    GenericTypeArguments: []
                )
            ),
            _ => throw new($"Property of type {type} is not supported."),
        };
    }
}