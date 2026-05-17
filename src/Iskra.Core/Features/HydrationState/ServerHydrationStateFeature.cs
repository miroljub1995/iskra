using System.Text.Json.Nodes;

namespace Iskra.Core.Features.HydrationState;

/// <summary>
/// Server-side <see cref="IServerHydrationStateFeature"/> implementation.
/// Create one instance per request and register it on the <see cref="IskraHostBuilder"/>
/// before mounting. Components call <see cref="RegisterDehydrateCallback"/> during their setup phase
/// to contribute state; <see cref="HydrationStateScript"/> calls <see cref="Dehydrate"/>
/// to serialize the result into the SSR output.
/// </summary>
public sealed class ServerHydrationStateFeature : IServerHydrationStateFeature
{
    private Action<JsonObject>? _callbacks;

    public JsonObject Dehydrate()
    {
        var obj = new JsonObject();
        _callbacks?.Invoke(obj);
        return obj;
    }

    public void RegisterDehydrateCallback(Action<JsonObject> callback) => _callbacks += callback;

    public void DeregisterDehydrateCallback(Action<JsonObject> callback) => _callbacks -= callback;
}
