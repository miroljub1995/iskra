using Iskra.Core.Instances;

namespace Iskra.Core.Sfc;

public interface
    ISfcClientComponent<out TComponent, in TPropsInit, in TProps, TExpose, in TFallthrough> :
    IClientComponent<TComponent, TPropsInit, TExpose, TFallthrough>
    where TComponent : ISfcClientComponent<TComponent, TPropsInit, TProps, TExpose, TFallthrough>
    where TProps : ISetupProps<TPropsInit, TProps>
{
    static abstract Func<BaseInstance[]> SetupClient(TProps props, TFallthrough fallthrough, out TExpose expose);
}