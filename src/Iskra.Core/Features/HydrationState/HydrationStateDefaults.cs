namespace Iskra.Core.Features.HydrationState;

public static class HydrationStateDefaults
{
    /// <summary>
    /// The default <c>id</c> attribute value used for the hydration state
    /// <c>&lt;script&gt;</c> element. Used by both <see cref="HydrationStateScript"/>
    /// (server) and <see cref="ClientHydrationStateFeature"/> (client).
    /// </summary>
    public const string ScriptElementId = "6e8c1a4b-d3f2-4a1c-8e7b-5f2d9a3c6b1e";
}
