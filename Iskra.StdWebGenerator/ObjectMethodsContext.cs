using System.Reflection;
using System.Runtime.InteropServices.JavaScript;
using Iskra.StdWebApi.Api;

namespace Iskra.StdWebGenerator;

public class ObjectMethodsContext
{
    private readonly Dictionary<string, TypeWithNullabilityInfo> _propertyMethods1 = new();

    public void AddMethod(string name, TypeWithNullabilityInfo type)
    {
        _propertyMethods1[name] = type;
    }

    public IReadOnlyDictionary<string, TypeWithNullabilityInfo> PropertyMethods => _propertyMethods1.AsReadOnly();

    private static readonly HashSet<string> ExistingGetMethods =
    [
        "GetPropertyAsBoolean",
        "GetPropertyAsInt32",
        "GetPropertyAsDouble",
        "GetPropertyAsString",
        "GetPropertyAsJSObject",
        "GetPropertyAsByteArray",
    ];

    private static readonly HashSet<Type> ExistingSetMethodTypes =
    [
        typeof(bool),
        typeof(int),
        typeof(double),
        typeof(string),
        typeof(JSObject),
        typeof(byte[]),
    ];

    private readonly Dictionary<string, (Type, NullabilityInfo, bool)> _propertyMethods = [];

    public IReadOnlyDictionary<string, (Type, NullabilityInfo, bool)> PropertyMethods1 => _propertyMethods.AsReadOnly();

    public string GetterPropertyMethodName(Type type, NullabilityInfo nullabilityInfo, bool isFromReadState)
    {
        var propertyMethodName = GeneratePropertyMethodName(type, nullabilityInfo, isFromReadState);
        _propertyMethods[propertyMethodName] = (type, nullabilityInfo, isFromReadState);
        return propertyMethodName;
    }

    private static string GeneratePropertyMethodName(Type type, NullabilityInfo nullabilityInfo, bool isFromReadState)
    {
        return "GetProperty" + GetReturnTypeSuffix(type, nullabilityInfo, isFromReadState);
    }

    private static string GetReturnTypeSuffix(Type type, NullabilityInfo nullabilityInfo, bool isFromReadState)
    {
        var nullabilityState = isFromReadState ? nullabilityInfo.ReadState : nullabilityInfo.WriteState;
        var isNullable = nullabilityState == NullabilityState.Nullable;

        var asNullableSuffix = isNullable ? "AsNullable" : "";
        var asArraySuffix = type.IsArray ? "AsArray" : "";

        var asType = type switch
        {
            _ when type == typeof(bool) => "AsBoolean",
            _ when type == typeof(bool?) => "AsBoolean",
            _ when type == typeof(int) => "AsInt32",
            _ when type == typeof(int?) => "AsInt32",
            _ when type == typeof(long) => "AsInt64",
            _ when type == typeof(long?) => "AsInt64",
            _ when type == typeof(double) => "AsDouble",
            _ when type == typeof(double?) => "AsDouble",
            _ when type == typeof(string) => "AsStringV2",
            _ when type == typeof(JSObject) => "AsJSObjectV2",
            // _ when IsOneOf(type) => HandleOneOf(type, nullabilityInfo, isFromReadState),
            _ when type.IsGenericType => GetReturnGenericTypeSuffix(type, nullabilityInfo),
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

    private static string GetReturnGenericTypeSuffix(Type type, NullabilityInfo nullabilityInfo)
    {
        var genericTypeDefinition = type.GetGenericTypeDefinition();
        var genericTypeArguments = type.GetGenericArguments();

        var genericTypeArgumentNames = string.Join("_and_", genericTypeArguments.Select((t, i) =>
            GetReturnTypeSuffix(t, nullabilityInfo.GenericTypeArguments[i], true)));

        if (genericTypeDefinition == typeof(OneOf<,>) || genericTypeDefinition == typeof(OneOf<,,>))
        {
            return
                $"AsOneOf_lt_{genericTypeArgumentNames}_gt_";
        }

        throw new($"Property of type {type} is not supported.");
    }
}