using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebApi.Api;

[GenerateBindings]
[AddToGlobalFactory]
public class MouseEvent : UIEvent
{
    public MouseEvent(string type, EventOptions? options = null) : base(type, options) => throw new();
}