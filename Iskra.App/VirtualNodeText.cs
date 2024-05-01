using Iskra.StdWeb.Dom;

namespace Iskra.App;

public class VirtualNodeText : VirtualNode
{
    public required Text Text { get; set; }
    public required RenderNodeText RenderNode { get; set; }
}