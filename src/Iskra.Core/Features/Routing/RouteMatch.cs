namespace Iskra.Core.Features.Routing;

internal sealed record RouteMatch(
    Route Route,
    IReadOnlyDictionary<string, string> RouteValues,
    RouteMatch? ChildMatch
);
