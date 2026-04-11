// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class SVGFEDistantLightElement: global::Iskra.StdWeb.SVGElement
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public SVGFEDistantLightElement(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SVGAnimatedNumber Azimuth
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SVGAnimatedNumber, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "azimuth");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SVGAnimatedNumber Elevation
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SVGAnimatedNumber, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "elevation");
    }
}

#nullable disable