using Iskra.Core.RenderRoot;
using Iskra.Signals;

namespace Iskra.Core.Instances;

public class ComponentInstance<TComponent, TPropsInit, TExpose, TFallthrough> : BaseInstance
    where TComponent : IClientComponent<TComponent, TPropsInit, TExpose, TFallthrough>
{
    private readonly EffectScope _effectScope = new();

    public ComponentInstance(TPropsInit props, TFallthrough fallthrough)
    {
        Component = TComponent.SetupClientComponent(props, fallthrough);
    }

    public ClientComponent<TExpose> Component { get; }

    public override void Mount(IRenderSlot slot)
    {
        _effectScope.Run(() =>
        {
            var instances = Component.Render();

            // Mount instances
            foreach (var instance in instances)
            {
                instance.Mount(slot);
            }

            new Effect(onCleanup => onCleanup(() =>
            {
                // Unmount instances
                foreach (var instance in instances)
                {
                    instance.Unmount();
                }
            }));
        });
    }

    public override void Unmount()
    {
        _effectScope.Dispose();
    }
}