using Iskra.Core.Components;
using Iskra.Core.Features;
using Iskra.Core.RenderRoot;
using Iskra.StdWeb;
using System.Runtime.Versioning;

namespace Iskra.Core;

public sealed class IskraHostBuilder
{
    private Func<IComponent>? _rootComponentFactory;
    private IRenderRoot? _renderRoot;
    private readonly FeatureCollection _features = new();

    /// <summary>
    /// Application-wide features visible to every component in the tree.
    /// </summary>
    public IFeatureCollection Features => _features;

    /// <summary>
    /// Convenience for <c>Features.Set&lt;TFeature&gt;(instance)</c>.
    /// </summary>
    public IskraHostBuilder SetFeature<TFeature>(TFeature instance)
    {
        _features.Set(instance);
        return this;
    }

    public IskraHostBuilder UseRootComponent(Func<IComponent> factory)
    {
        _rootComponentFactory = factory;
        return this;
    }

    [SupportedOSPlatform("browser")]
    public IskraHostBuilder UseRootElement(Element element)
    {
        _renderRoot = new DomRenderRoot(element);
        return this;
    }

    public IskraHostBuilder UseRootRenderer(IRenderRoot renderRoot)
    {
        _renderRoot = renderRoot;
        return this;
    }

    public IskraHost Build()
    {
        if (_rootComponentFactory is null)
            throw new InvalidOperationException("Root component must be configured via UseRootComponent.");
        if (_renderRoot is null)
            throw new InvalidOperationException("Root renderer must be configured via UseRootElement or UseRootRenderer.");

        return new IskraHost(_rootComponentFactory, _renderRoot, _features);
    }
}
