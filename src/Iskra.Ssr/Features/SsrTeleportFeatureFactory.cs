using Iskra.Core.Features;

namespace Iskra.Ssr.Features;

public sealed class SsrTeleportFeatureFactory : ITeleportFeatureFactory
{
    public ITeleportFeature Create() => new TeleportFeature(false);
}
