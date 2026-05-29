using Iskra.Core.Components;
using Iskra.Signals;

namespace Iskra.Core.Features.Routing;

internal sealed class RouteFeature : IRouteFeature
{
    public RouteFeature(
        string pattern,
        IReadOnlySignal<IReadOnlyDictionary<string, string>> routeValues,
        IComponent[] outletContent)
    {
        Pattern = pattern;
        RouteValues = routeValues;
        OutletContent = outletContent;
    }

    public IReadOnlySignal<IReadOnlyDictionary<string, string>> RouteValues { get; }
    public string Pattern { get; }
    public IComponent[] OutletContent { get; }
}
