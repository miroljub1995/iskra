using Iskra.App.Elements;
using Iskra.StdWeb.Dom;

namespace Iskra.App;

public class VirtualNodeDomElement<TElement, TElementProps> : VirtualNodeDomNode
    where TElement : Element
    where TElementProps : IElementProps<TElement>
{
    public required TElement Element { get; set; }
    public required RenderNodeElement<TElement, TElementProps> RenderNode { get; set; }
    public List<VirtualNode> ChildNodes { get; set; } = [];

    public override Node Node => Element;
}