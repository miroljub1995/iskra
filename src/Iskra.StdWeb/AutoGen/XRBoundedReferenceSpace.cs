// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class XRBoundedReferenceSpace: global::Iskra.StdWeb.XRReferenceSpace
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public XRBoundedReferenceSpace(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.FrozenArray<global::Iskra.StdWeb.DOMPointReadOnly, global::Iskra.StdWeb.PropertyAccessor> BoundsGeometry
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.FrozenArray<global::Iskra.StdWeb.DOMPointReadOnly, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "boundsGeometry");
    }
}

#nullable disable