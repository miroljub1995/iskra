using Iskra.Core.Components;
using Iskra.StdWeb;
using System.Runtime.Versioning;

namespace Iskra.Core;

[SupportedOSPlatform("browser")]
public sealed class IskraHostBuilder
{
    private Func<IComponent>? _rootComponentFactory;
    private Element? _rootElement;

    public IskraHostBuilder UseRootComponent(Func<IComponent> factory)
    {
        _rootComponentFactory = factory;
        return this;
    }

    public IskraHostBuilder UseRootElement(Element element)
    {
        _rootElement = element;
        return this;
    }

    public IskraHost Build()
    {
        if (_rootComponentFactory is null)
            throw new InvalidOperationException("Root component must be configured via UseRootComponent.");
        if (_rootElement is null)
            throw new InvalidOperationException("Root element must be configured via UseRootElement.");

        return new IskraHost(_rootComponentFactory, _rootElement);
    }
}
