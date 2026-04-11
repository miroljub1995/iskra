// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class XRSubImage: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public XRSubImage(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.XRViewport Viewport
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.XRViewport, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "viewport");
    }
}

#nullable disable