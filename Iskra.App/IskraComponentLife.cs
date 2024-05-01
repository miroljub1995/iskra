using System.Runtime.InteropServices.JavaScript;
using Iskra.App.Elements;
using Iskra.Reactivity;
using Iskra.Reactivity.Effects;
using Iskra.StdWeb.Dom;

namespace Iskra.App;

public class IskraComponentLife<TComponent, TComponentProps>(
    TComponent component,
    Renderer renderer
) : IIskraComponentLife, IEffect
    where TComponent : IIskraComponent<TComponentProps>
    where TComponentProps : notnull
{
    private double? _updateTimer;
    private VirtualNode? _virtualNode;
    private RenderCallback? _renderCallback;
    private Element? _container;

    public void Start(Element container, object props)
    {
        if (props is not TComponentProps componentProps)
        {
            throw new($"Props are not {typeof(TComponent)}.");
        }

        _renderCallback = component.Setup(componentProps);
        _container = container;
        Render();
    }

    private void Render()
    {
        if (_renderCallback is null)
        {
            throw new("Render callback is null.");
        }

        if (_container is null)
        {
            throw new("Container is null.");
        }

        IEffect? oldActive = Effect.Active;
        Effect.Active = this;
        try
        {
            DepsTracking.RemoveEffect(this);
            RenderNode renderNode = _renderCallback();
            _virtualNode = renderer.Render(_virtualNode, _container, renderNode);
        }
        finally
        {
            Effect.Active = oldActive;
        }
    }

    public void End()
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public void Trigger()
    {
        Console.WriteLine("ComponentLife trigger");
        if (_updateTimer is null)
        {
            _updateTimer = new Window(JSHost.GlobalThis)
                .SetTimeout(() =>
                {
                    Console.WriteLine("Component app updated.");
                    Render();
                    _updateTimer = null;
                }, 0);
        }
    }
}