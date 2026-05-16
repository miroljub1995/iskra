using System.Text.Json.Nodes;

namespace Iskra.Core.Features.HydrationState;

/// <summary>
/// Feature that carries application state between server and client during hydration.
///
/// On the server: <see cref="Value"/> starts as an empty <see cref="JsonObject"/> and
/// components mutate it in-place (e.g. <c>feature.Value["key"] = "val"</c>).
/// The <see cref="HydrationStateScript"/> component then serializes it into a
/// <c>&lt;script type="application/json"&gt;</c> element embedded in the SSR output.
///
/// On the client: <see cref="HydrationStateScript"/> reads that element from the DOM
/// and deserializes its content back into <see cref="Value"/> before the rest of the
/// component tree mounts.
/// </summary>
public interface IHydrationStateFeature
{
    JsonObject Value { get; }
}
