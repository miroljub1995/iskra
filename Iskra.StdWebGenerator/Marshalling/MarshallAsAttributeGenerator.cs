using System.Runtime.InteropServices.JavaScript;
using Iskra.StdWebGenerator.Extensions;
using Iskra.StdWebGenerator.JSObjectMarkers;

namespace Iskra.StdWebGenerator.Marshalling;

public static class MarshallAsAttributeGenerator
{
    public static string? Execute(MyType type)
    {
        return 0 switch
        {
            _ when type.Type == typeof(bool) => null,
            _ when type.Type == typeof(int) => null,
            _ when type.Type == typeof(long) => null,
            _ when type.Type == typeof(double) => null,
            _ when type.Type == typeof(string) => null,
            _ when type.Type == typeof(object) => $"JSMarshalAs<{GetJSType(type)}>",
            _ when type.Type == typeof(JSObject) => null,
            _ when type.Type == typeof(JSObjectArray) => null,
            _ when type.Type == typeof(JSObjectFunction) => null,
            _ when type.Type == typeof(ObjectForJS) => $"JSMarshalAs<{GetJSType(type)}>",
            _ when type.Type.IsArray && type.ElementType is not null =>
                $"JSMarshalAs<JSType.Array<{GetJSType(type.ElementType)}>>",
            _ when type.Type.IsSubclassOf(typeof(Delegate)) => GetAttributeForDelegate(type),
            _ => throw new Exception($"Type {type} is not supported.")
        };
    }

    private static string GetAttributeForDelegate(MyType type)
    {
        var methodInfo = type.Type
            .GetDelegateMethodInfo();

        MyType[] returnTypes = methodInfo.IsVoid() ? [] : [MyType.From(methodInfo.ReturnParameter)];

        MyType[] parameterTypes = methodInfo
            .GetParameters()
            .Select(MyType.From)
            .ToArray();

        MyType[] allParams = [..returnTypes, ..parameterTypes];

        var functionParams = string.Join(", ", allParams.Select(GetJSType));

        return $"JSMarshalAs<JSType.Function<{functionParams}>>";
    }

    private static string GetJSType(MyType type)
    {
        return 0 switch
        {
            _ when type.Type == typeof(bool) => "JSType.Boolean",
            _ when type.Type == typeof(int) => "JSType.Number",
            _ when type.Type == typeof(long) => "JSType.Number",
            _ when type.Type == typeof(double) => "JSType.Number",
            _ when type.Type == typeof(string) => "JSType.String",
            _ when type.Type == typeof(object) => "JSType.Any",
            _ when type.Type == typeof(JSObject) => "JSType.Object",
            _ when type.Type == typeof(ObjectForJS) => "JSType.Any",
            _ => throw new Exception($"Type {type} is not supported.")
        };
    }
}