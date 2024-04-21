using System.Runtime.InteropServices.JavaScript;
using Iskra.Utils;

namespace Iskra.StdWeb.Dom;

public class Event(JSObject obj) : JSObjectWrapper(obj)
{
    public EventTarget? Target =>
        JSObject.GetPropertyAsJSObject("target") is { } target ? new EventTarget(target) : null;
}