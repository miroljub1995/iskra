using System.Runtime.InteropServices.JavaScript;

namespace Iskra.StdWeb.Utils;

public static class JSObjectExtensions
{
    public static bool IsNullOrUndefined(this JSObject obj, string propertyName)
    {
        var propertyType = obj.GetTypeOfProperty(propertyName);
        if (propertyType is "undefined")
        {
            return true;
        }

        if (propertyType is "object")
        {
            return obj.GetPropertyAsJSObject(propertyName) is null;
        }

        return false;
    }
}