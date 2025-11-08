namespace Iskra.App.Elements;

public record ElementProps(
    string? Id = null,
    string? Class = null,
    SequenceEqualList<RenderNode>? ChildNodes = null
);