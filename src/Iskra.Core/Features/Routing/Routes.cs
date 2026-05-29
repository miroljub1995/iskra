using Iskra.Core.Components;
using Iskra.Core.Features;
using Iskra.Core.RenderRoot;
using Iskra.Signals;

namespace Iskra.Core.Features.Routing;

/// <summary>
/// Routing component that builds a tree of <see cref="If"/> components — one per
/// <see cref="Route"/> at every nesting level. Each <see cref="If"/> condition is a
/// <see cref="Computed{T}"/> that tracks which route matches at that level. Because
/// <see cref="If"/> handles mount/unmount, routes that still match on navigation are
/// never re-mounted; only the first level that changes swaps its branch.
/// </summary>
public class Routes : IComponent
{
    public required Func<Route[]> Default { get; init; }

    private ComposedComponent? _composed;

    public void Mount(IRenderSlot slot)
    {
        var parentFeatures = AppFeatures.Current
            ?? throw new InvalidOperationException(
                "AppFeatures.Current must be set before mounting Routes.");

        var navigation = parentFeatures.Get<INavigationFeature>()
            ?? throw new InvalidOperationException(
                "INavigationFeature must be registered before mounting Routes. " +
                "Call builder.SetFeature<INavigationFeature>(...) during host setup.");

        var routes = Default();

        // Single reactive computation that walks the entire route tree
        // and returns a linked chain of RouteMatch, or null if no
        // complete match exists.
        var matchedRoute = new Computed<RouteMatch?>(() =>
        {
            var pathSegments = ParsePathSegments(navigation.CurrentPath.Value);
            return MatchRouteTree(routes, pathSegments);
        });

        var ifComponents = BuildRouteBranches(routes, matchedRoute);
        _composed = new ComposedComponent(ifComponents);
        _composed.Mount(slot);
    }

    public void Unmount()
    {
        _composed?.Unmount();
        _composed = null;
    }

    /// <summary>
    /// Builds one <see cref="If"/> component per route at this nesting level.
    /// Each <see cref="If"/>'s condition checks whether <paramref name="matchedRoute"/>
    /// selected this route.
    /// </summary>
    internal static IComponent[] BuildRouteBranches(
        Route[] routes,
        Computed<RouteMatch?> matchedRoute)
    {
        var components = new IComponent[routes.Length];
        for (int i = 0; i < routes.Length; i++)
        {
            var route = routes[i];
            var condition = new Computed<bool>(() => matchedRoute.Value?.Route == route);

            components[i] = new If
            {
                Condition = condition,
                Then = () =>
                [
                    new RouteScope
                    {
                        Route = route,
                        MatchedRoute = matchedRoute,
                    }
                ]
            };
        }

        return components;
    }

    /// <summary>
    /// Recursively walks the route tree and returns a linked chain of
    /// <see cref="RouteMatch"/> — or <c>null</c> if no route can fully
    /// resolve <paramref name="remainingSegments"/>.
    /// </summary>
    private static RouteMatch? MatchRouteTree(
        Route[] routes, ReadOnlyMemory<string> remainingSegments)
    {
        var span = remainingSegments.Span;

        for (int i = 0; i < routes.Length; i++)
        {
            var route = routes[i];

            if (!route.Matcher.TryMatchPrefix(span, out var values))
            {
                continue;
            }

            if (route.Children is null)
            {
                // Leaf route: all segments must be consumed
                // (or a catch-all handles the rest).
                if (!route.Matcher.HasCatchAll && route.Matcher.SegmentCount < remainingSegments.Length)
                {
                    continue;
                }

                return new RouteMatch(route, values, null);
            }

            var childRoutes = route.Children;
            var childMatch = MatchRouteTree(
                childRoutes,
                remainingSegments[route.Matcher.SegmentCount..]
            );

            if (childMatch is not null)
            {
                return new RouteMatch(route, values, childMatch);
            }
        }

        return null;
    }

    private static string[] ParsePathSegments(string path) =>
        path.Trim('/').Split('/', StringSplitOptions.RemoveEmptyEntries);
}
