using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;

namespace Iskra.JSFunction;

[SupportedOSPlatform("browser")]
public static class JSObjectExtensions
{
    public static JSFunction? GetPropertyAsJSFunction(this JSObject obj, string propertyName)
        => obj.GetPropertyAsJSObject(propertyName) is { } function ? new(obj, function) : null;

    public static JSFunction AsJSFunction(this JSObject obj)
    {
        if (obj.HasProperty("call"))
        {
            return new(null, obj);
        }

        throw new ArgumentException("Object is not a function.");
    }
}