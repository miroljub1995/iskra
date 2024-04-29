using Iskra.StdWeb.Dom;

namespace Iskra.App.Elements;

public record HtmlDivElementProps(
    string? Id = null,
    string? Class = null,
    SequenceEqualList<RenderNode>? ChildNodes = null
) : ElementProps(
    Id: Id,
    Class: Class,
    ChildNodes: ChildNodes
), IElementProps<HtmlDivElement>;