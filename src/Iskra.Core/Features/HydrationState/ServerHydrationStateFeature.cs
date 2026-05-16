using System.Text.Json.Nodes;

namespace Iskra.Core.Features.HydrationState;

/// <summary>
/// Server-side <see cref="IHydrationStateFeature"/> implementation.
/// Create one instance per request and register it on the <see cref="IskraHostBuilder"/>
/// before mounting. Components mutate <see cref="Value"/> in-place during their
/// <c>Setup</c> phase; the <see cref="HydrationStateScript"/> component serializes
/// the result into the SSR output.
/// </summary>
public sealed class ServerHydrationStateFeature : IHydrationStateFeature
{
    public JsonObject Value { get; } = [];
}
