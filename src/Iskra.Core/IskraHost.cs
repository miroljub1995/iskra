using Iskra.Core.Components;
using Iskra.Core.RenderRoot;
using Iskra.StdWeb;
using System.Runtime.Versioning;

namespace Iskra.Core;

[SupportedOSPlatform("browser")]
public sealed class IskraHost
{
    private readonly Func<IComponent> _rootComponentFactory;
    private readonly Element _rootElement;

    internal IskraHost(Func<IComponent> rootComponentFactory, Element rootElement)
    {
        _rootComponentFactory = rootComponentFactory;
        _rootElement = rootElement;
    }

    public IDisposable Mount()
    {
        var renderRoot = new DomRenderRoot(_rootElement);
        var scope = new Signals.EffectScope();
        scope.Run(() => _rootComponentFactory().Mount(renderRoot.GetNextSlot()));
        return scope;
    }

    public async Task RunAsync(CancellationToken cancellationToken = default)
    {
        await StdWebProxyFactory.InitializeAsync();

        using var _ = Mount();

        await Task.Delay(Timeout.Infinite, cancellationToken);
    }
}
