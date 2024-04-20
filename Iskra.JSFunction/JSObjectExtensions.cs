using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;

namespace Iskra.JSFunction;

[SupportedOSPlatform("browser")]
public static class JSObjectExtensions
{
    public static JSFunction AsJSFunction(this JSObject obj)
    {
        if (obj.HasProperty("call"))
        {
            return new(obj);
        }

        throw new ArgumentException("Object is not a function.");
    }
}