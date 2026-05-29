using Iskra.Core.Components;
using Iskra.Core.Features;
using Iskra.Core.RenderRoot;

namespace Iskra.Core.Features.Routing;

/// <summary>
/// Renders the child route <see cref="If"/> components built by <see cref="Routes"/>.
/// Must be used inside a parent route's <see cref="Route.Render"/> when
/// that route has <see cref="Route.Children"/>.
/// </summary>
public class Outlet : IComponent
{
    private ComposedComponent? _composed;

    public void Mount(IRenderSlot slot)
    {
        var features = AppFeatures.Current
            ?? throw new InvalidOperationException(
                "AppFeatures.Current must be set before mounting Outlet.");

        var routeFeature = features.Get<IRouteFeature>()
            ?? throw new InvalidOperationException(
                "IRouteFeature not found. Outlet must be used inside a route that has Children defined.");

        _composed = new ComposedComponent(routeFeature.OutletContent);
        _composed.Mount(slot);
    }

    public void Unmount()
    {
        _composed?.Unmount();
        _composed = null;
    }
}
