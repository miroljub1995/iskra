using System.Text.Json.Nodes;

namespace Iskra.Browser.Abstractions.Features.HydrationState;

/// <summary>
/// Client-side feature that exposes application state deserialized from the SSR output
/// during hydration.
///
/// The server-side hydration script component reads/writes the <c>&lt;script type="application/json"&gt;</c>
/// element from the DOM and populates <see cref="Value"/> before the rest of the
/// component tree mounts.
/// </summary>
public interface IClientHydrationStateFeature
{
    JsonObject Value { get; }
}
