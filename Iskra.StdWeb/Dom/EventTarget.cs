using System.Runtime.InteropServices.JavaScript;
using Iskra.Utils;

namespace Iskra.StdWeb.Dom;

public class EventTarget(JSObject obj) : JSObjectWrapper(obj)
{
    public EventSubscription AddEventListener(string type, EventListener listener, bool? useCapture = null)
    {
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

        JSFunction func = JSObject.GetPropertyAsJSFunction("addEventListener")
                          ?? throw new("addEventListener not defined.");

        object?[] args = [type, jsCb, useCapture];

        func.Call(args);

        return new(JSObject, args);
    }
}