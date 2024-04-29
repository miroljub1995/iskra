using Iskra.StdWeb.Dom;

namespace Iskra.App;

public class VirtualNode
{
    public required Node ContainerNode { get; set; }
    public required RenderNode RenderNode { get; set; }
}