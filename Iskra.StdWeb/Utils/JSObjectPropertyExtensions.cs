using System.Runtime.InteropServices.JavaScript;

namespace Iskra.StdWeb.Utils;

public static class JSObjectPropertyExtensions
{
    public static bool? GetPropertyAsBooleanAsNullable(this JSObject obj, string propertyName)
    {
        if (obj.IsNullOrUndefined(propertyName))
        {
            return null;
        }

        return obj.GetPropertyAsBoolean(propertyName);
    }

    public static double? GetPropertyAsDoubleAsNullable(this JSObject obj, string propertyName)
    {
        if (obj.IsNullOrUndefined(propertyName))
        {
            return null;
        }

        return obj.GetPropertyAsDouble(propertyName);
    }

    public static long GetPropertyAsInt64(this JSObject obj, string propertyName)
    {
        double doubleValue = obj.GetPropertyAsDouble(propertyName);
        return Convert.ToInt64(doubleValue);
    }

    public static long? GetPropertyAsInt64AsNullable(this JSObject obj, string propertyName)
    {
        double? doubleValue = obj.GetPropertyAsDoubleAsNullable(propertyName);
        if (doubleValue is null)
        {
            return null;
        }

        return Convert.ToInt64(doubleValue);
    }

    public static string GetPropertyAsStringV2(this JSObject obj, string propertyName)
    {
        var value = obj.GetPropertyAsString(propertyName);
        if (value is null)
        {
            throw new($"Property {propertyName} is null or undefined.");
        }

        return value;
    }

    public static string? GetPropertyAsStringV2AsNullable(this JSObject obj, string propertyName)
    {
        return obj.GetPropertyAsString(propertyName);
    }

    public static JSObject GetPropertyAsJSObjectV2(this JSObject obj, string propertyName)
    {
        var value = obj.GetPropertyAsJSObject(propertyName);
        if (value is null)
        {
            throw new($"Property {propertyName} is null or undefined.");
        }

        return value;
    }

    public static JSObject? GetPropertyAsJSObjectV2AsNullable(this JSObject obj, string propertyName)
    {
        return obj.GetPropertyAsJSObject(propertyName);
    }

    public static object GetPropertyAsOneOf(this JSObject obj, string propertyName)
    {
        var propertyType = obj.GetTypeOfProperty(propertyName);
        return propertyType switch
        {
            "boolean" => obj.GetPropertyAsBoolean(propertyName),
            "number" => obj.GetPropertyAsDouble(propertyName),
            "string" => obj.GetPropertyAsStringV2(propertyName),
            "object" => obj.GetPropertyAsJSObjectV2(propertyName),
            _ => throw new($"Property {propertyName} is not supported.")
        };
    }

    public static object? GetPropertyAsOneOfAsNullable(this JSObject obj, string propertyName)
    {
        var propertyType = obj.GetTypeOfProperty(propertyName);
        return propertyType switch
        {
            "undefined" => null,
            "boolean" => obj.GetPropertyAsBoolean(propertyName),
            "number" => obj.GetPropertyAsDouble(propertyName),
            "string" => obj.GetPropertyAsStringV2(propertyName),
            "object" => obj.GetPropertyAsJSObjectV2AsNullable(propertyName),
            _ => throw new($"Property {propertyName} is not supported.")
        };
    }

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

    public static void SetPropertyAsOneOf(this JSObject obj, string propertyName, OneOf? value)
    {
        if (value is null)
        {
            obj.SetProperty(propertyName, null as JSObject);
        }
        else
        {
            switch (value.Value)
            {
                case bool boolValue:
                    obj.SetProperty(propertyName, boolValue);
                    break;
                case int intValue:
                    obj.SetProperty(propertyName, intValue);
                    break;
                case long longValue:
                    obj.SetProperty(propertyName, longValue);
                    break;
                case double doubleValue:
                    obj.SetProperty(propertyName, doubleValue);
                    break;
                case string stringValue:
                    obj.SetProperty(propertyName, stringValue);
                    break;
                case JSObject jsObjectValue:
                    obj.SetProperty(propertyName, jsObjectValue);
                    break;
                default:
                    throw new($"Can not set value of type {value.Value.GetType()}.");
            }
        }
    }
}