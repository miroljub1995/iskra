using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebApi.Api;

[GenerateBindings]
[AddToGlobalFactory]
public class InputEvent : UIEvent
{
    public InputEvent(string type, EventOptions? options = null) : base(type, options) => throw new();
}