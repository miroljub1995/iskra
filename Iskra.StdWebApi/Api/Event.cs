using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebApi.Api;

[GenerateBindings]
public class Event
{
    public Event(string type, EventOptions? options = null) => throw new();

    public EventTarget? Target
    {
        get => throw new();
    }
}