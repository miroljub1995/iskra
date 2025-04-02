using System.Runtime.InteropServices.JavaScript;
using Iskra.StdWebApi.Api;
using Iskra.StdWebGenerator.Extensions;
using Iskra.StdWebGenerator.JSObjectMarkers;

namespace Iskra.StdWebGenerator;

public record JSObjectSetPropertyGeneratorRes(
    string Name,
    MyType InputType
);

public class JSObjectSetPropertyGenerator
{
    public static JSObjectSetPropertyGeneratorRes Execute(MyType type)
    {
        return type switch
        {
            _ when type.Type.IsIReadOnlyList() => new(
                Name: "SetProperty",
                InputType: new MyType(
                    Type: typeof(JSObjectArray),
                    IsNullable: type.IsNullable,
                    ElementType: null,
                    GenericTypeArguments: []
                )
            ),
            _ when type.Type == typeof(bool) => new(
                Name: $"SetProperty{(type.IsNullable ? "AsBooleanNullable" : "")}",
                InputType: type
            ),
            _ when type.Type == typeof(int) => new(
                Name: $"SetProperty{(type.IsNullable ? "AsInt32Nullable" : "")}",
                InputType: type
            ),
            _ when type.Type == typeof(long) => new(
                Name: $"SetProperty{(type.IsNullable ? "AsInt64Nullable" : "")}",
                InputType: type
            ),
            _ when type.Type == typeof(double) => new(
                Name: $"SetProperty{(type.IsNullable ? "AsDoubleNullable" : "")}",
                InputType: type
            ),
            _ when type.Type == typeof(string) => new(
                Name: "SetProperty",
                InputType: type
            ),
            _ when type.Type == typeof(JSObject) => new(
                Name: "SetProperty",
                InputType: type
            ),
            _ when type.Type.IsOneOf() => HandleOneOf(type),
            _ when type.Type.IsJSObjectWrapper() => new(
                Name: "SetProperty",
                InputType: new MyType(
                    Type: typeof(JSObject),
                    IsNullable: type.IsNullable,
                    ElementType: null,
                    GenericTypeArguments: []
                )
            ),
            _ => throw new($"Property of type {type} is not supported."),
        };
    }

    private static JSObjectSetPropertyGeneratorRes HandleOneOf(MyType type)
    {
        var marshalledGenericArguments = type.GenericTypeArguments
            .Select(x =>
            {
                return x.Type switch
                {
                    _ when x.Type == typeof(bool) => x,
                    _ when x.Type == typeof(int) => x,
                    _ when x.Type == typeof(long) => x,
                    _ when x.Type == typeof(double) => x,
                    _ when x.Type == typeof(string) => x,
                    _ when x.Type == typeof(JSObject) => x,
                    _ when x.Type.IsJSObjectWrapper() => new(
                        Type: typeof(JSObject),
                        IsNullable: x.IsNullable,
                        ElementType: null,
                        GenericTypeArguments: []
                    ),
                    _ => throw new($"Type {type.Type} is not supported.")
                };
            })
            .ToArray();

        var marshalledType = type.Type
            .GetGenericTypeDefinition()
            .MakeGenericType(marshalledGenericArguments
                .Select(x => x.Type)
                .ToArray()
            );

        return new(
            Name: "SetPropertyAsOneOf",
            InputType: new MyType(
                Type: marshalledType,
                IsNullable: type.IsNullable,
                ElementType: null,
                GenericTypeArguments: marshalledGenericArguments
            )
        );
    }
}