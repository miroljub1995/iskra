// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class SVGAnimatedPreserveAspectRatio: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public SVGAnimatedPreserveAspectRatio(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SVGPreserveAspectRatio BaseVal
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SVGPreserveAspectRatio, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "baseVal");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SVGPreserveAspectRatio AnimVal
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SVGPreserveAspectRatio, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "animVal");
    }
}

#nullable disable