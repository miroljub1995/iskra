using System.Runtime.InteropServices.JavaScript;

namespace Iskra.JSCore.Extensions;

public static partial class JSObjectPropertyExtensions
{
    public static bool? GetPropertyAsBooleanV2AsNullable(this JSObject obj, string propertyName) =>
        GetPropertyAsBooleanV2AsNullable_Bridge(obj, propertyName);

    public static bool GetPropertyAsBooleanV2(this JSObject obj, string propertyName) =>
        GetPropertyAsBooleanV2AsNullable_Bridge(obj, propertyName) ??
        throw new Exception($"Property {propertyName} is null or undefined.");

    [JSImport("globalThis.Reflect.get")]
    private static partial bool? GetPropertyAsBooleanV2AsNullable_Bridge(JSObject obj, string propertyName);

    public static double? GetPropertyAsDoubleV2AsNullable(this JSObject obj, string propertyName) =>
        GetPropertyAsDoubleV2AsNullable_Bridge(obj, propertyName);

    public static double GetPropertyAsDoubleV2(this JSObject obj, string propertyName) =>
        GetPropertyAsDoubleV2AsNullable_Bridge(obj, propertyName) ??
        throw new Exception($"Property {propertyName} is null or undefined.");

    [JSImport("globalThis.Reflect.get")]
    private static partial double? GetPropertyAsDoubleV2AsNullable_Bridge(JSObject obj, string propertyName);

    public static int GetPropertyAsInt32(this JSObject obj, string propertyName)
    {
        var doubleValue = obj.GetPropertyAsDoubleV2(propertyName);
        return Convert.ToInt32(doubleValue);
    }

    public static int? GetPropertyAsInt32AsNullable(this JSObject obj, string propertyName)
    {
        var doubleValue = obj.GetPropertyAsDoubleV2AsNullable(propertyName);
        if (doubleValue is null)
        {
            return null;
        }

        return Convert.ToInt32(doubleValue);
    }

    public static long GetPropertyAsInt64(this JSObject obj, string propertyName)
    {
        var doubleValue = obj.GetPropertyAsDoubleV2(propertyName);
        return Convert.ToInt64(doubleValue);
    }

    public static long? GetPropertyAsInt64AsNullable(this JSObject obj, string propertyName)
    {
        var doubleValue = obj.GetPropertyAsDoubleV2AsNullable(propertyName);
        if (doubleValue is null)
        {
            return null;
        }

        return Convert.ToInt64(doubleValue);
    }

    public static string GetPropertyAsStringV2(this JSObject obj, string propertyName) =>
        obj.GetPropertyAsString(propertyName) ??
        throw new Exception($"Property {propertyName} is null or undefined.");

    public static string? GetPropertyAsStringV2AsNullable(this JSObject obj, string propertyName) =>
        obj.GetPropertyAsString(propertyName);

    public static JSObject GetPropertyAsJSObjectV2(this JSObject obj, string propertyName) =>
        obj.GetPropertyAsJSObject(propertyName) ??
        throw new Exception($"Property {propertyName} is null or undefined.");

    public static JSObject? GetPropertyAsJSObjectV2AsNullable(this JSObject obj, string propertyName) =>
        obj.GetPropertyAsJSObject(propertyName);

    public static object GetPropertyAsObjectV2(this JSObject obj, string propertyName) =>
        GetPropertyAsObjectV2AsNullable_Bridge(obj, propertyName) ??
        throw new Exception($"Property {propertyName} is null or undefined.");

    public static object? GetPropertyAsObjectV2AsNullable(this JSObject obj, string propertyName) =>
        GetPropertyAsObjectV2AsNullable_Bridge(obj, propertyName);

    [JSImport("globalThis.Reflect.get")]
    [return: JSMarshalAs<JSType.Any>]
    private static partial object? GetPropertyAsObjectV2AsNullable_Bridge(JSObject obj, string propertyName);

    public static JSObject GetPropertyAsUnionV2(this JSObject obj, string propertyName) =>
        GetPropertyAsUnionV2AsNullable_Bridge(obj, propertyName) ??
        throw new Exception($"Property {propertyName} is null or undefined.");

    public static JSObject? GetPropertyAsUnionV2AsNullable(this JSObject obj, string propertyName) =>
        GetPropertyAsUnionV2AsNullable_Bridge(obj, propertyName);

    [JSImport("getPropertyAsUnion", "iskra")]
    [return: JSMarshalAs<JSType.Object>]
    private static partial JSObject? GetPropertyAsUnionV2AsNullable_Bridge(JSObject obj, string propertyName);

    // public static object GetPropertyAsOneOf(this JSObject obj, string propertyName)
    // {
    //     var propertyType = obj.GetTypeOfProperty(propertyName);
    //     return propertyType switch
    //     {
    //         "boolean" => obj.GetPropertyAsBoolean(propertyName),
    //         "number" => obj.GetPropertyAsDouble(propertyName),
    //         "string" => obj.GetPropertyAsStringV2(propertyName),
    //         "object" => obj.GetPropertyAsJSObjectV2(propertyName),
    //         _ => throw new($"Property {propertyName} is not supported.")
    //     };
    // }
    //
    // public static object? GetPropertyAsOneOfAsNullable(this JSObject obj, string propertyName)
    // {
    //     var propertyType = obj.GetTypeOfProperty(propertyName);
    //     return propertyType switch
    //     {
    //         "undefined" => null,
    //         "boolean" => obj.GetPropertyAsBoolean(propertyName),
    //         "number" => obj.GetPropertyAsDouble(propertyName),
    //         "string" => obj.GetPropertyAsStringV2(propertyName),
    //         "object" => obj.GetPropertyAsJSObjectV2AsNullable(propertyName),
    //         _ => throw new($"Property {propertyName} is not supported.")
    //     };
    // }

    public static void SetPropertyAsBooleanV2AsNullable(this JSObject obj, string propertyName, bool? value) =>
        SetPropertyAsBooleanV2AsNullable_Bridge(obj, propertyName, value);

    public static void SetPropertyAsBooleanV2(this JSObject obj, string propertyName, bool value) =>
        SetPropertyAsBooleanV2AsNullable_Bridge(obj, propertyName, value);

    [JSImport("globalThis.Reflect.set")]
    private static partial void SetPropertyAsBooleanV2AsNullable_Bridge(JSObject obj, string propertyName, bool? value);

    public static void SetPropertyAsDoubleV2AsNullable(this JSObject obj, string propertyName, double? value) =>
        SetPropertyAsDoubleV2AsNullable_Bridge(obj, propertyName, value);

    public static void SetPropertyAsDoubleV2(this JSObject obj, string propertyName, double value) =>
        SetPropertyAsDoubleV2AsNullable_Bridge(obj, propertyName, value);

    [JSImport("globalThis.Reflect.set")]
    private static partial void
        SetPropertyAsDoubleV2AsNullable_Bridge(JSObject obj, string propertyName, double? value);

    public static void SetPropertyAsStringV2AsNullable(this JSObject obj, string propertyName, string? value) =>
        SetPropertyAsStringV2AsNullable_Bridge(obj, propertyName, value);

    public static void SetPropertyAsStringV2(this JSObject obj, string propertyName, string value) =>
        SetPropertyAsStringV2AsNullable_Bridge(obj, propertyName, value);

    [JSImport("globalThis.Reflect.set")]
    private static partial void
        SetPropertyAsStringV2AsNullable_Bridge(JSObject obj, string propertyName, string? value);

    public static void SetPropertyAsJSObjectV2AsNullable(this JSObject obj, string propertyName, JSObject? value) =>
        SetPropertyAsJSObjectV2AsNullable_Bridge(obj, propertyName, value);

    public static void SetPropertyAsJSObjectV2(this JSObject obj, string propertyName, JSObject value) =>
        SetPropertyAsJSObjectV2AsNullable_Bridge(obj, propertyName, value);

    [JSImport("globalThis.Reflect.set")]
    private static partial void
        SetPropertyAsJSObjectV2AsNullable_Bridge(JSObject obj, string propertyName, JSObject? value);

    public static void SetPropertyAsObjectV2AsNullable(this JSObject obj, string propertyName, object? value) =>
        SetPropertyAsObjectV2AsNullable_Bridge(obj, propertyName, value);

    public static void SetPropertyAsObjectV2(this JSObject obj, string propertyName, object value) =>
        SetPropertyAsObjectV2AsNullable_Bridge(obj, propertyName, value);

    [JSImport("globalThis.Reflect.set")]
    private static partial void
        SetPropertyAsObjectV2AsNullable_Bridge(JSObject obj, string propertyName,
            [JSMarshalAs<JSType.Any>] object? value);

    public static void SetPropertyAsBooleanNullable(this JSObject obj, string propertyName, bool? value)
    {
        if (value is null)
        {
            obj.SetProperty(propertyName, null as JSObject);
        }
        else
        {
            obj.SetProperty(propertyName, value.Value);
        }
    }

    public static void SetPropertyAsInt32Nullable(this JSObject obj, string propertyName, int? value)
    {
        if (value is null)
        {
            obj.SetProperty(propertyName, null as JSObject);
        }
        else
        {
            obj.SetProperty(propertyName, value.Value);
        }
    }

    public static void SetPropertyAsInt64Nullable(this JSObject obj, string propertyName, long? value)
    {
        if (value is null)
        {
            obj.SetProperty(propertyName, null as JSObject);
        }
        else
        {
            obj.SetProperty(propertyName, value.Value);
        }
    }

    public static void SetPropertyAsDoubleNullable(this JSObject obj, string propertyName, double? value)
    {
        if (value is null)
        {
            obj.SetProperty(propertyName, null as JSObject);
        }
        else
        {
            obj.SetProperty(propertyName, value.Value);
        }
    }

    public static void SetPropertyAsUnion(this JSObject obj, string propertyName, JSObject value)
    {
        SetPropertyAsUnionV2AsNullable_Bridge(obj, propertyName, value);
    }

    public static void SetPropertyAsUnionAsNullable(this JSObject obj, string propertyName, JSObject? value)
    {
        SetPropertyAsUnionV2AsNullable_Bridge(obj, propertyName, value);
    }

    [JSImport("setPropertyAsUnion", "iskra")]
    private static partial void SetPropertyAsUnionV2AsNullable_Bridge(JSObject obj, string propertyName,
        JSObject? value);

    // public static void SetPropertyAsOneOf(this JSObject obj, string propertyName, OneOf? value)
    // {
    //     if (value is null)
    //     {
    //         obj.SetProperty(propertyName, null as JSObject);
    //     }
    //     else
    //     {
    //         switch (value.Value)
    //         {
    //             case bool boolValue:
    //                 obj.SetProperty(propertyName, boolValue);
    //                 break;
    //             case int intValue:
    //                 obj.SetProperty(propertyName, intValue);
    //                 break;
    //             case long longValue:
    //                 obj.SetProperty(propertyName, longValue);
    //                 break;
    //             case double doubleValue:
    //                 obj.SetProperty(propertyName, doubleValue);
    //                 break;
    //             case string stringValue:
    //                 obj.SetProperty(propertyName, stringValue);
    //                 break;
    //             case JSObject jsObjectValue:
    //                 obj.SetProperty(propertyName, jsObjectValue);
    //                 break;
    //             default:
    //                 throw new($"Can not set value of type {value.Value.GetType()}.");
    //         }
    //     }
    // }
}