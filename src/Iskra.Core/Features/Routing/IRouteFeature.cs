using Iskra.Core.Components;
using Iskra.Signals;

namespace Iskra.Core.Features.Routing;

/// <summary>
/// Provides route information for the current matched route: extracted
/// route values, the matched pattern, and optional outlet content for
/// child routes.
/// </summary>
public interface IRouteFeature
{
    /// <summary>
    /// The route values extracted from the matched pattern
    /// (e.g. <c>{ "id", "42" }</c> for pattern <c>/users/{id}</c>).
    /// Reactive: updates without re-mounting when the same route matches
    /// with different parameter values (e.g. <c>/users/1</c> → <c>/users/2</c>).
    /// </summary>
    IReadOnlySignal<IReadOnlyDictionary<string, string>> RouteValues { get; }

    /// <summary>
    /// The route pattern that was matched (e.g. <c>/users/{id}</c>).
    /// </summary>
    string Pattern { get; }

    /// <summary>
    /// The <see cref="If"/> components to render inside an <see cref="Outlet"/>,
    /// or an empty array if this route has no children.
    /// </summary>
    IComponent[] OutletContent { get; }
}
