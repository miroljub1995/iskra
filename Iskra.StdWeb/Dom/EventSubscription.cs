using System.Runtime.InteropServices.JavaScript;
using Iskra.Utils;

namespace Iskra.StdWeb.Dom;

public class EventSubscription(
    JSObject obj,
    object?[] args
) : JSObjectWrapper(obj), IDisposable
{
    public void Dispose()
    {
        JSFunction func = JSObject.GetPropertyAsJSFunction("removeEventListener")
                          ?? throw new("removeEventListener not defined.");

        func.Call(args);
    }
}