using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebApi.Api;

[GenerateBindings]
[AddToGlobalFactory]
public class UIEvent : Event
{
    public UIEvent(string type, EventOptions? options = null) : base(type, options) => throw new();
}