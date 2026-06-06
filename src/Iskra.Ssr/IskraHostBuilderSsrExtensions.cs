using Iskra.Core.Features;
using Iskra.Core;
using Iskra.Ssr.Features;

namespace Iskra.Ssr;

public static class IskraHostBuilderSsrExtensions
{
    public static IskraHostBuilder UseTeleport(this IskraHostBuilder builder)
    {
        return builder.SetFeature<ITeleportFeatureFactory>(new SsrTeleportFeatureFactory());
    }
}
