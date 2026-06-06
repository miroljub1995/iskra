using Iskra.Core.Features;

namespace Iskra.Browser.Features;

internal sealed class BrowserTeleportFeatureFactory : ITeleportFeatureFactory
{
    public ITeleportFeature Create() => new TeleportFeature(true);
}
