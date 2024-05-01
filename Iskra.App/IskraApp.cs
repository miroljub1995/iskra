using System.Runtime.InteropServices.JavaScript;
using Iskra.StdWeb.Dom;
using Microsoft.Extensions.DependencyInjection;

namespace Iskra.App;

public class IskraApp
{
    private readonly ServiceCollection _services = [];

    private Element? _rootContainer;
    private RenderNode? _rootRenderNode;

    public IskraApp()
    {
        _services.AddTransient<Renderer>();
        _services.AddTransient(typeof(IskraComponentLife<,>));
    }

    public IskraApp WithRootContainer(string elementId)
    {
        Element? rootElement = new Window(JSHost.GlobalThis)
            .Document
            .GetElementById(elementId);

        if (rootElement is null)
        {
            throw new Exception("Root container not found.");
        }

        _rootContainer = rootElement;
        return this;
    }

    public IskraApp WithRootComponent<TComponent, TProps>(TProps props)
        where TComponent : class, IIskraComponent<TProps>
        => WithRootRenderNode(new RenderNodeComponent<TComponent, TProps>(
            Key: null,
            Props: props
        ));

    public IskraApp WithRootRenderNode(RenderNode root)
    {
        _rootRenderNode = root;

        return this;
    }

    public IskraApp AddComponent<TComponent, TProps>()
        where TComponent : class, IIskraComponent<TProps>
    {
        _services.AddTransient<TComponent>();
        return this;
    }

    public void Start()
    {
        ServiceProvider provider = _services.BuildServiceProvider(new ServiceProviderOptions()
        {
            ValidateScopes = true,
            ValidateOnBuild = true,
        });

        if (_rootRenderNode is null)
        {
            throw new Exception("Root component is not set.");
        }

        if (_rootContainer is null)
        {
            throw new Exception("Root container is not set.");
        }

        Renderer renderer = provider.GetRequiredService<Renderer>();
        renderer.Render(_rootContainer, _rootRenderNode);
    }
}