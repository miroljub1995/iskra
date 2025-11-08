using Microsoft.Extensions.DependencyInjection;

namespace Iskra.Core;

public class App
{
    private readonly ServiceCollection _services = [];

    private Func<IKeyedServiceProvider, ComponentInstance>? _rootComponentSetup;

    public App()
    {
        // _services.AddTransient<Renderer>();
        // _services.AddTransient(typeof(IskraComponentLife<,>));
    }

    public App WithRootAnchor<TAnchor>(TAnchor anchor)
    {
        _services.AddSingleton(() => anchor);

        return this;
    }

    public App WithRootComponent(Func<IKeyedServiceProvider, ComponentInstance> rootComponentSetup)
    {
        _rootComponentSetup = rootComponentSetup;

        return this;
    }

    // public IskraApp WithRootContainer(string elementId)
    // {
    //     Element? rootElement = new Window(JSHost.GlobalThis)
    //         .Document
    //         .GetElementById(elementId);
    //
    //     if (rootElement is null)
    //     {
    //         throw new Exception("Root container not found.");
    //     }
    //
    //     _rootContainer = rootElement;
    //     return this;
    // }

    // public IskraApp WithRootComponent<TComponent, TProps>(TProps props)
    //     where TComponent : class, IIskraComponent<TProps>
    //     => WithRootRenderNode(new RenderNodeComponent<TComponent, TProps>(
    //         Key: null,
    //         Props: props
    //     ));
    //
    // public IskraApp WithRootRenderNode(RenderNode root)
    // {
    //     _rootRenderNode = root;
    //
    //     return this;
    // }

    public void Start()
    {
        ServiceProvider provider = _services.BuildServiceProvider(new ServiceProviderOptions()
        {
            ValidateScopes = true,
            ValidateOnBuild = true,
        });

        // if (_rootRenderNode is null)
        // {
        //     throw new Exception("Root component is not set.");
        // }
        //
        // if (_rootContainer is null)
        // {
        //     throw new Exception("Root container is not set.");
        // }
        //
        // Renderer renderer = provider.GetRequiredService<Renderer>();
        // renderer.Render(null, _rootContainer, _rootRenderNode);
        _rootComponentSetup(provider);
    }
}