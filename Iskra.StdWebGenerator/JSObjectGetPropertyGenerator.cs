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

        MyType returnType = type switch
        {
            _ when type.Type.IsArray => new MyType(
                Type: typeof(JSObject),
                IsNullable: type.IsNullable,
                ElementType: null,
                GenericTypeArguments: []
            ),
            _ when type.Type == typeof(bool) => type,
            _ when type.Type == typeof(bool?) => type,
            _ when type.Type == typeof(int) => type,
            _ when type.Type == typeof(int?) => type,
            _ when type.Type == typeof(long) => type,
            _ when type.Type == typeof(long?) => type,
            _ when type.Type == typeof(double) => type,
            _ when type.Type == typeof(double?) => type,
            _ when type.Type == typeof(double) => type,
            _ when type.Type == typeof(string) => type,
            _ when type.Type == typeof(JSObject) => type,
            _ when type.Type.IsOneOf() => new MyType(
                Type: typeof(JSObject),
                IsNullable: type.IsNullable,
                ElementType: null,
                GenericTypeArguments: []
            ),
            _ when type.Type.IsJSObjectWrapper() => new MyType(
                Type: typeof(JSObject),
                IsNullable: type.IsNullable,
                ElementType: null,
                GenericTypeArguments: []
            ),
            _ => throw new($"Property of type {type} is not supported."),
        };

        string asType = returnType switch
        {
            _ when returnType.Type == typeof(bool) => "AsBoolean",
            _ when returnType.Type == typeof(int) => "AsInt32",
            _ when returnType.Type == typeof(long) => "AsInt64",
            _ when returnType.Type == typeof(double) => "AsDouble",
            _ when returnType.Type == typeof(string) => "AsStringV2",
            _ when returnType.Type == typeof(JSObject) => "AsJSObjectV2",
            _ => throw new($"Property of type {type} is not supported."),
        };

        return new(
            Name: $"GetProperty{asType}{asNullableSuffix}",
            ReturnType: returnType
        );
    }
}