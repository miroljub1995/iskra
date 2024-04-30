using Iskra.App.Elements;
using Iskra.StdWeb.Dom;

namespace Iskra.App;

public class VirtualNodeElement<TElement, TElementProps> : VirtualNode
    where TElement : Element
    where TElementProps : IElementProps<TElement>
{
    public required RenderNodeElement<TElement, TElementProps> RenderNode { get; set; }
    public List<VirtualNode> ChildNodes { get; set; } = [];
}