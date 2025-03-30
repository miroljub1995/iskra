using System.Runtime.InteropServices.JavaScript;
using Iskra.StdWebGenerator.Extensions;

namespace Iskra.StdWebGenerator;

public record JSObjectSetPropertyGeneratorRes(
    string Name,
    MyType ReturnType
);

public class JSObjectSetPropertyGenerator
{
    public static JSObjectSetPropertyGeneratorRes Execute(MyType type)
    {
        return type switch
        {
            _ when type.Type.IsIReadOnlyList() => new(
                Name: "SetProperty",
                ReturnType: new MyType(
                    Type: typeof(JSObject),
                    IsNullable: type.IsNullable,
                    ElementType: null,
                    GenericTypeArguments: []
                )
            ),
            _ when type.Type == typeof(bool) => new(
                Name: "SetProperty",
                ReturnType: type
            ),
            _ when type.Type == typeof(int) => new(
                Name: "SetProperty",
                ReturnType: type
            ),
            _ when type.Type == typeof(long) => new(
                Name: "SetProperty",
                ReturnType: type
            ),
            _ when type.Type == typeof(double) => new(
                Name: "SetProperty",
                ReturnType: type
            ),
            _ when type.Type == typeof(string) => new(
                Name: "SetProperty",
                ReturnType: type
            ),
            _ when type.Type == typeof(JSObject) => new(
                Name: "SetProperty",
                ReturnType: type
            ),
            _ when type.Type.IsOneOf() => new(
                Name: "SetProperty",
                ReturnType: new MyType(
                    Type: typeof(JSObject),
                    IsNullable: type.IsNullable,
                    ElementType: null,
                    GenericTypeArguments: []
                )
            ),
            _ when type.Type.IsJSObjectWrapper() => new(
                Name: "SetProperty",
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