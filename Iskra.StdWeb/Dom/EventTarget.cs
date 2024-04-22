using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;
using Iskra.Utils;

namespace Iskra.StdWeb.Dom;

public class EventTarget(JSObject obj) : JSObjectWrapper(obj)
{
    private static readonly ConditionalWeakTable<EventListener, JSObject> ListenerToJSListener = new();

    public void AddEventListener(string type, EventListener listener, bool? useCapture = null)
    {
        JSObject jsCb = ListenerToJSListener.GetValue(listener, (l) =>
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

                l(ev);
            };

            return genericAction.ToJSObject();
        });

        JSFunction func = JSObject.GetPropertyAsJSFunction("addEventListener")
                          ?? throw new("addEventListener not defined.");

        object?[] args = [type, jsCb, useCapture];

        func.Call(args);
    }

    public void RemoveEventListener(string type, EventListener listener, bool? useCapture = null)
    {
        if (ListenerToJSListener.TryGetValue(listener, out JSObject? jsListener))
        {
            JSFunction func = JSObject.GetPropertyAsJSFunction("removeEventListener")
                              ?? throw new("removeEventListener not defined.");

            object?[] args = [type, jsListener, useCapture];

            func.Call(args);
        }
    }
}