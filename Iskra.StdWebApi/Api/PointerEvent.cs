using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebApi.Api;

[GenerateBindings]
[AddToGlobalFactory]
public class PointerEvent : UIEvent
{
    public PointerEvent(string type, EventOptions? options = null) : base(type, options) => throw new();
}