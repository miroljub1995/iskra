using System.Text.Json.Nodes;

namespace Iskra.Ssr.Abstractions.Features.HydrationState;

/// <summary>
/// Feature that collects application state on the server during SSR.
///
/// Components call <see cref="RegisterDehydrateCallback"/> during their setup phase to contribute
/// state entries. The server-side hydration script component calls <see cref="Dehydrate"/>
/// when serializing state into the SSR output.
/// </summary>
public interface IServerHydrationStateFeature
{
    /// <summary>
    /// Builds the dehydrated state by creating a fresh <see cref="JsonObject"/> and
    /// invoking all registered callbacks against it in registration order.
    /// </summary>
    JsonObject Dehydrate();

    /// <summary>
    /// Registers a callback that will be invoked by <see cref="Dehydrate"/> to
    /// mutate the <see cref="JsonObject"/> in-place.
    /// </summary>
    void RegisterDehydrateCallback(Action<JsonObject> callback);

    /// <summary>
    /// Removes a previously registered dehydrate callback.
    /// </summary>
    void DeregisterDehydrateCallback(Action<JsonObject> callback);
}
