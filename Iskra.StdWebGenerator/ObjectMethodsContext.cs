using System.Reflection;
using System.Runtime.InteropServices.JavaScript;
using Iskra.StdWebApi.Api;

namespace Iskra.StdWebGenerator;

public class ObjectMethodsContext
{
    private readonly List<JSObjectMethodCallInfo> _methods = [];

    public IReadOnlyList<JSObjectMethodCallInfo> Methods => _methods;

    public JSObjectMethodCallInfo GetMethodCallInfo(
        IReadOnlyList<MyType> parameters,
        MyType? returnParam
    )
    {
        JSObjectMethodCallInfo? info =
            _methods.SingleOrDefault(x => x.Parameters.SequenceEqual(parameters) && x.ReturnParam == returnParam);

        if (info is null)
        {
            info = new(
                Name: $"CustomMethodCall_{_methods.Count}",
                Parameters: parameters,
                ReturnParam: returnParam
            );
            _methods.Add(info);
        }

        return info;
    }

    // private static string GetReturnTypeSuffix(MyType type)
    // {
    //     var asNullableSuffix = type.IsNullable ? "AsNullable" : "";
    //
    //     var asType = type switch
    //     {
    //         _ when type.Type.IsArray => "AsJSObjectV2",
    //         _ when type.Type == typeof(bool) => "AsBoolean",
    //         _ when type.Type == typeof(int) => "AsInt32",
    //         _ when type.Type == typeof(long) => "AsInt64",
    //         _ when type.Type == typeof(double) => "AsDouble",
    //         _ when type.Type == typeof(string) => "AsStringV2",
    //         _ when type.Type == typeof(JSObject) => "AsJSObjectV2",
    //         // _ when IsOneOf(type) => HandleOneOf(type, nullabilityInfo, isFromReadState),
    //         _ when type.Type.IsGenericType => GetReturnGenericTypeSuffix(type),
    //         _ => throw new($"Property of type {type} is not supported."),
    //     };
    //
    //     return $"{asType}{asNullableSuffix}";
    // }
    //
    // private static bool IsOneOf(Type type)
    // {
    //     var genericTypeDefinition = type.GetGenericTypeDefinition();
    //
    //     return genericTypeDefinition == typeof(OneOf<,>)
    //            || genericTypeDefinition == typeof(OneOf<,,>)
    //            || genericTypeDefinition == typeof(OneOf<,,,>)
    //            || genericTypeDefinition == typeof(OneOf<,,,,>);
    // }
    //
    // // private static string HandleOneOf(Type type, NullabilityInfo nullabilityInfo, bool isFromReadState)
    // // {
    // //     var genericTypeArguments = type.GetGenericArguments();
    // // }
    //
    // private static string GetReturnGenericTypeSuffix(MyType type)
    // {
    //     var genericTypeDefinition = type.Type.GetGenericTypeDefinition();
    //     var genericTypeArguments = type.Type.GetGenericArguments();
    //
    //     var genericTypeArgumentNames = string.Join("_and_", genericTypeArguments.Select((t, i) =>
    //         GetReturnTypeSuffix(type.GenericTypeArguments[i])));
    //
    //     if (genericTypeDefinition == typeof(OneOf<,>) || genericTypeDefinition == typeof(OneOf<,,>))
    //     {
    //         return $"AsOneOf_lt_{genericTypeArgumentNames}_gt_";
    //     }
    //
    //     throw new($"Property of type {type} is not supported.");
    // }
}