using Iskra.Core.Components;
using Iskra.Core.Features;
using Iskra.Core.RenderRoot;
using Iskra.Signals;

namespace Iskra.Core.Features.Routing;

/// <summary>
/// Wraps a matched route's rendered components, setting up the feature
/// layer (route values, outlet) during <see cref="Mount"/> so that child
/// components see the correct <see cref="AppFeatures.Current"/>.
/// </summary>
internal class RouteScope : IComponent
{
    private static readonly IReadOnlyDictionary<string, string> EmptyRouteValues =
        new Dictionary<string, string>();

    public required Route Route { get; init; }
    public required Computed<RouteMatch?> MatchedRoute { get; init; }

    private ComposedComponent? _composed;

    public void Mount(IRenderSlot slot)
    {
        var parentFeatures = AppFeatures.Current
            ?? throw new InvalidOperationException(
                "AppFeatures.Current must be set before mounting RouteScope.");

        var childFeatures = new FeatureCollection(parentFeatures);

        // Route values are reactive — when the same route matches
        // with different parameters (e.g. /users/1 → /users/2),
        // the component stays mounted and sees the updated values.
        var routeValues = new Computed<IReadOnlyDictionary<string, string>>(
            () => MatchedRoute.Value?.RouteValues ?? EmptyRouteValues);

        // If this route has children, derive the child match and
        // recursively build the next level of If components.
        IComponent[] outletContent = [];
        if (Route.Children is not null)
        {
            var childMatch = new Computed<RouteMatch?>(
                () => MatchedRoute.Value?.ChildMatch);
            var childRoutes = Route.Children;
            outletContent = Routes.BuildRouteBranches(childRoutes, childMatch);
        }

        childFeatures.Set<IRouteFeature>(
            new RouteFeature(Route.Pattern, routeValues, outletContent));

        var prevFeatures = AppFeatures.Current;
        AppFeatures.Current = childFeatures;
        try
        {
            _composed = new ComposedComponent(Route.Render());
            _composed.Mount(slot);
        }
        finally
        {
            AppFeatures.Current = prevFeatures;
        }
    }

    public void Unmount()
    {
        _composed?.Unmount();
        _composed = null;
    }
}
