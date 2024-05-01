using Microsoft.Extensions.DependencyInjection;

namespace Iskra.App;

public abstract record RenderNodeComponent(
    object? Key,
    object PropsObject
) : RenderNode(
    Key: Key
)
{
    public abstract IIskraComponentLife GetIskraComponentLife(IServiceProvider provider);
}

public record RenderNodeComponent<TComponent, TProps>(
    object? Key,
    TProps Props
) : RenderNodeComponent(
    Key: Key,
    PropsObject: Props
)
    where TComponent : class, IIskraComponent<TProps>
    where TProps : notnull
{
    public override IIskraComponentLife GetIskraComponentLife(IServiceProvider provider)
        => provider.GetRequiredService<IskraComponentLife<TComponent, TProps>>();
}