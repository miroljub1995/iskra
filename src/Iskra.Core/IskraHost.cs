using Iskra.Core.Components;
using Iskra.Core.RenderRoot;
using System.Runtime.Versioning;

namespace Iskra.Core;

[SupportedOSPlatform("browser")]
public sealed class IskraHost
{
    private readonly Func<IComponent> _rootComponentFactory;
    private readonly IRenderRoot _renderRoot;

    internal IskraHost(Func<IComponent> rootComponentFactory, IRenderRoot renderRoot)
    {
        _rootComponentFactory = rootComponentFactory;
        _renderRoot = renderRoot;
    }

    public IDisposable Mount()
    {
        var scope = new Signals.EffectScope();
        scope.Run(() => _rootComponentFactory().Mount(_renderRoot.GetNextSlot()));
        return scope;
    }
}
