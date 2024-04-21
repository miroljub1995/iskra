using System.Runtime.InteropServices.JavaScript;
using Iskra.Utils;

namespace Iskra.StdWeb.Dom;

public delegate void EventListener(Event e);

public class EventTarget(JSObject obj) : JSObjectWrapper(obj)
{
    public void AddEventListener(string type, EventListener listener, bool? options = null)
    {
        JSFunction func = JSObject.GetPropertyAsJSFunction("addEventListener")
                          ?? throw new("addEventListener not defined.");

        Action<object?> genericAction = obj =>
        {
            if (obj is not JSObject jsObject)
            {
                throw new("e is not JSObject.");
            }

            if (!jsObject.InstanceOf(out Event? ev))
            {
                throw new("e is not Event.");
            }

            listener(ev);
        };

        JSObject jsCb = genericAction.ToJSObject();

        func.Call(type, jsCb, options);
    }
}