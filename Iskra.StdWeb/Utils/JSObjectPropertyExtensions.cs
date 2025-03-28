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

    public static JSObject GetPropertyAsOneOf(this JSObject obj, string propertyName)
    {
    }
}