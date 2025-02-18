using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebApi.Api;

[GenerateBindings]
[AddToGlobalFactory]
public class EventTarget
{
    public EventTarget() => throw new();

    public void AddEventListener(string type, EventListener listener, bool useCapture) => throw new();

    public void RemoveEventListener(string type, EventListener listener, bool useCapture) => throw new();

    public bool DispatchEvent(Event e) => throw new();
}