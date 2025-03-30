using System.Runtime.InteropServices.JavaScript;
using Iskra.StdWebGenerator.Extensions;

namespace Iskra.StdWebGenerator;

public static class JSObjectGetCallGenerator
{
    public static JSObjectMethodCallInfo Execute(
        IReadOnlyList<MyType> parameters,
        MyType? returnParam,
        GeneratorContext context
    )
    {
        var jsLevelParams = parameters.Select(ToJSLevelType).ToList();
        var jsLevelReturnParam = returnParam is null ? null : ToJSLevelType(returnParam);

        return context.ObjectMethods.GetMethodCallInfo(jsLevelParams, jsLevelReturnParam);
    }

    private static MyType ToJSLevelType(MyType type)
        => type switch
        {
            _ when type.Type.IsJSObjectWrapper() => new MyType(typeof(JSObject), type.IsNullable, null, []),
            _ when type.Type == typeof(bool) => type,
            _ when type.Type == typeof(int) => type,
            _ when type.Type == typeof(long) => type,
            _ when type.Type == typeof(double) => type,
            _ when type.Type == typeof(string) => type,
            _ when type.Type == typeof(JSObject) => type,
            _ => throw new Exception($"Unsupported type {type}")
        };
}