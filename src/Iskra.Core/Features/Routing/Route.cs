using Iskra.Core.Components;

namespace Iskra.Core.Features.Routing;

/// <summary>
/// Defines a single route mapping: a URL pattern and the components to render
/// when that pattern matches the current path. This is a data class —
/// <see cref="Routes"/> handles matching and mount/unmount via <see cref="If"/> components.
/// </summary>
public sealed class Route
{
    private RouteTemplateMatcher? _matcher;

    /// <summary>
    /// The route template pattern (e.g. <c>/users/{id}</c>).
    /// Follows ASP.NET Core route template syntax.
    /// </summary>
    public required string Pattern { get; init; }

    /// <summary>
    /// Factory that produces the components to render when this route matches.
    /// </summary>
    public required Func<IComponent[]> Render { get; init; }

    /// <summary>
    /// Optional child routes for nested routing.
    /// The parent route's <see cref="Render"/> should include an <see cref="Outlet"/>
    /// component where child content will be rendered.
    /// </summary>
    public Route[]? Children { get; init; }

    /// <summary>
    /// The pre-parsed matcher for this route's <see cref="Pattern"/>.
    /// Lazily initialized on first access.
    /// </summary>
    internal RouteTemplateMatcher Matcher => _matcher ??= RouteTemplateMatcher.Parse(Pattern);
}
