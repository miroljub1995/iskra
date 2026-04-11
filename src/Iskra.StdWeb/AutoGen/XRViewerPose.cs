// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class XRViewerPose: global::Iskra.StdWeb.XRPose
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public XRViewerPose(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.FrozenArray<global::Iskra.StdWeb.XRView, global::Iskra.StdWeb.PropertyAccessor> Views
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.FrozenArray<global::Iskra.StdWeb.XRView, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "views");
    }
}

#nullable disable