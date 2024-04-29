namespace Iskra.App;

public record RenderNodeComponent<TComponent, TProps>(
    object? Key,
    TProps Props
) : RenderNode(
    Key: Key
)
    where TComponent : class, IIskraComponent<TProps>;