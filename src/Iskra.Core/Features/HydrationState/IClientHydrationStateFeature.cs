using System.Text.Json.Nodes;

namespace Iskra.Core.Features.HydrationState;

/// <summary>
/// Client-side feature that exposes application state deserialized from the SSR output
/// during hydration.
///
/// <see cref="HydrationStateScript"/> reads the <c>&lt;script type="application/json"&gt;</c>
/// element from the DOM and populates <see cref="Value"/> before the rest of the
/// component tree mounts.
/// </summary>
public interface IClientHydrationStateFeature
{
    JsonObject Value { get; }
}
