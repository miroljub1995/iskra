using System.Runtime.InteropServices.JavaScript;
using Iskra.Reactivity;
using Iskra.Reactivity.Effects;
using Iskra.StdWeb.Dom;

namespace Iskra.App;

public class IskraComponentLife<TComponent, TComponentProps>(
    TComponent component,
    Renderer renderer
) : IIskraComponentLife, IEffect
    where TComponent : IIskraComponent<TComponentProps>
{
    private double? _updateTimer;

    public void Start(Element container, object props)
    {
        if (props is not TComponentProps componentProps)
        {
            throw new($"Props are not {typeof(TComponent)}.");
        }

        RenderCallback render = component.Setup(componentProps);

        IEffect? oldActive = Effect.Active;
        Effect.Active = this;
        try
        {
            DepsTracking.RemoveEffect(this);
            RenderNode renderNode = render();
            renderer.Render(container, renderNode);
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
        if (_updateTimer is null)
        {
            new Window(JSHost.GlobalThis)
                .SetTimeout(() =>
                {
                    Console.WriteLine("Component app updated.");
                    _updateTimer = null;
                }, 0);
        }
    }
}