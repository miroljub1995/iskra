using Iskra.Core.Instances;

namespace Iskra.Core;

public interface IClientComponent<out TComponent, in TPropsInit, TExpose, in TFallthrough>
{
    static abstract ClientComponent<TExpose> SetupClientComponent(TPropsInit props, TFallthrough fallthrough);
}