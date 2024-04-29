using Iskra.App.Elements;
using Iskra.StdWeb.Dom;

namespace Iskra.App;

public record RenderNodeElement<TElement, TElementProps>(
    object? Key,
    TElementProps Props
) : RenderNode(
    Key: Key
)
    where TElement : Element
    where TElementProps : IElementProps<TElement>;