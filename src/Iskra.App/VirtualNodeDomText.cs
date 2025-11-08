using Iskra.StdWeb.Dom;

namespace Iskra.App;

public class VirtualNodeDomText : VirtualNodeDomNode
{
    public required Text Text { get; set; }
    public required RenderNodeText RenderNode { get; set; }

    public override Node Node => Text;
}