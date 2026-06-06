using System.Runtime.Versioning;
using Iskra.Browser.Features;
using Iskra.Core;
using Iskra.Core.Features;
using Iskra.StdWeb;

namespace Iskra.Browser;

public static class IskraHostBuilderBrowserExtensions
{
    [SupportedOSPlatform("browser")]
    public static IskraHostBuilder UseRootElement(this IskraHostBuilder builder, Element element)
    {
        return builder.UseRootRenderer(new Iskra.Core.RenderRoot.DomRenderRoot(element));
    }

    [SupportedOSPlatform("browser")]
    public static IskraHostBuilder UseTeleport(this IskraHostBuilder builder)
    {
        return builder.SetFeature<ITeleportFeatureFactory>(new BrowserTeleportFeatureFactory());
    }
}
