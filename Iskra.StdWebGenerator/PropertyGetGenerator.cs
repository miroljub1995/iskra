using System.Reflection;
using System.Runtime.InteropServices.JavaScript;
using Iskra.StdWebApi.Api;
using Iskra.StdWebGenerator.Extensions;
using Iskra.StdWebGenerator.Marshalling;

namespace Iskra.StdWebGenerator;

public record PropertyGetGeneratorRes(
    string Output,
    string OutputVar
);

public static class PropertyGetGenerator
{
    public static PropertyGetGeneratorRes Execute(
        TypeWithNullabilityInfo type,
        string inputVar,
        string propertyName,
        GeneratorContext context
    )
    {
        var propertyResName = context.GetNextVariableName();

        var marshallingOutRes = MarshallingOut.Execute(type, propertyResName, context);
        var propertyMethodName = GeneratePropertyMethodName(marshallingOutRes.FromType);
        context.ObjectMethods.AddMethod(propertyMethodName, type);

        var propertyMethodType = TypeNameGenerator.Execute(
            marshallingOutRes.FromType.Type,
            marshallingOutRes.FromType.NullabilityInfo,
            marshallingOutRes.FromType.IsFromReadState
        );

        var propertyMethodRes = $$"""
                                  {{propertyMethodType}} {{propertyResName}} = {{inputVar}}.{{propertyMethodName}}("{{propertyName}}");
                                  """;

        string output;
        if (marshallingOutRes.Output is null)
        {
            output = $$"""
                       {{propertyMethodRes}}
                       """;
        }
        else
        {
            output = $$"""
                       {{propertyMethodRes}}
                       {{marshallingOutRes.Output}}
                       """;
        }

        return new(
            Output: output,
            OutputVar: marshallingOutRes.OutputVar
        );
    }

    private static string GeneratePropertyMethodName(TypeWithNullabilityInfo type)
    {
        return "GetProperty" + GetReturnTypeSuffix(type);
    }

    private static string GetReturnTypeSuffix(TypeWithNullabilityInfo type)
    {
        var nullabilityState = type.IsFromReadState ? type.NullabilityInfo.ReadState : type.NullabilityInfo.WriteState;
        var isNullable = nullabilityState == NullabilityState.Nullable;

        var asNullableSuffix = isNullable ? "AsNullable" : "";
        var asArraySuffix = type.Type.IsArray ? "AsArray" : "";

        var asType = type switch
        {
            _ when type.Type == typeof(bool) => "AsBoolean",
            _ when type.Type == typeof(bool?) => "AsBoolean",
            _ when type.Type == typeof(int) => "AsInt32",
            _ when type.Type == typeof(int?) => "AsInt32",
            _ when type.Type == typeof(long) => "AsInt64",
            _ when type.Type == typeof(long?) => "AsInt64",
            _ when type.Type == typeof(double) => "AsDouble",
            _ when type.Type == typeof(double?) => "AsDouble",
            _ when type.Type == typeof(string) => "AsStringV2",
            _ when type.Type == typeof(JSObject) => "AsJSObjectV2",
            _ when type.Type.IsOneOf() => "AsOneOf",
            // _ when IsOneOf(type) => HandleOneOf(type, nullabilityInfo, isFromReadState),
            // _ when type.Type.IsGenericType => GetReturnGenericTypeSuffix(type, nullabilityInfo),
            _ => throw new($"Property of type {type} is not supported."),
        };

        return $"{asType}{asNullableSuffix}{asArraySuffix}";
    }

    private static bool IsOneOf(Type type)
    {
        var genericTypeDefinition = type.GetGenericTypeDefinition();

        return genericTypeDefinition == typeof(OneOf<,>)
               || genericTypeDefinition == typeof(OneOf<,,>)
               || genericTypeDefinition == typeof(OneOf<,,,>)
               || genericTypeDefinition == typeof(OneOf<,,,,>);
    }

    // private static string HandleOneOf(Type type, NullabilityInfo nullabilityInfo, bool isFromReadState)
    // {
    //     var genericTypeArguments = type.GetGenericArguments();
    // }

    // private static string GetReturnGenericTypeSuffix(TypeWithNullabilityInfo type)
    // {
    //     var genericTypeDefinition = type.GetGenericTypeDefinition();
    //     var genericTypeArguments = type.GetGenericArguments();
    //
    //     var genericTypeArgumentNames = string.Join("_and_", genericTypeArguments.Select((t, i) =>
    //         GetReturnTypeSuffix(t, nullabilityInfo.GenericTypeArguments[i], true)));
    //
    //     if (genericTypeDefinition == typeof(OneOf<,>) || genericTypeDefinition == typeof(OneOf<,,>))
    //     {
    //         return
    //             $"AsOneOf_lt_{genericTypeArgumentNames}_gt_";
    //     }
    //
    //     throw new($"Property of type {type} is not supported.");
    // }

    public static string Execute(
        MyType type,
        string objVar,
        string outputVar,
        string propertyName,
        GeneratorContext context
    )
    {
        var getPropertyMethodRes = JSObjectGetPropertyGenerator.Execute(type);

        var propVar = context.GetNextVariableName();

        var marshall = Marshallers.Instance
            .GetNext(getPropertyMethodRes.ReturnType, type)
            .Marshall(getPropertyMethodRes.ReturnType, propVar, type, outputVar, context);

        return $$"""
                 {{TypeNameGenerator.Execute(getPropertyMethodRes.ReturnType)}} {{propVar}} = {{objVar}}.{{getPropertyMethodRes.Name}}("{{propertyName}}");
                 {{marshall}}
                 """;
    }
}