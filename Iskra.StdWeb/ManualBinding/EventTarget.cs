using System.Runtime.InteropServices.JavaScript;
using Iskra.StdWeb.Utils;

namespace Iskra.StdWeb;

public partial class EventTarget
{
    public void AddEventListener(string type, Action<Event> listener, bool useCapture)
    {
        JSObject jsCb = JSObjectsCache.GetOrAdd(listener, () =>
        {
            Action<object?> genericAction = obj =>
            {
                if (obj is not JSObject jsObject)
                {
                    throw new("e is not JSObject.");
                }

                var ev = WrapperFactory.GetWrapper<Event>(jsObject);

                listener(ev);
            };

            JSObject jsCb = genericAction.ToJSObject();

            return jsCb;
        });

        JSObject jsFunc = JSObject.GetPropertyAsJSObject("addEventListener")
                          ?? throw new("addEventListener not defined.");

        object?[] args = [type, jsCb, useCapture];

        Reflect.Apply(jsFunc, JSObject, args);
    }

    public void RemoveEventListener(string type, Action<Event> listener, bool useCapture)
    {
        if (JSObjectsCache.TryGetValue(listener, out var jsCb))
        {
            JSObject jsFunc = JSObject.GetPropertyAsJSObject("removeEventListener")
                              ?? throw new("removeEventListener not defined.");

            object?[] args = [type, jsCb, useCapture];

            Reflect.Apply(jsFunc, JSObject, args);
        }
    }
}