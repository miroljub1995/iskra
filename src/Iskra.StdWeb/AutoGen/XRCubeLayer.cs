// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class XRCubeLayer: global::Iskra.StdWeb.XRCompositionLayer
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public XRCubeLayer(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.XRSpace Space
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.XRSpace, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "space");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.XRSpace, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "space", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.DOMPointReadOnly Orientation
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.DOMPointReadOnly, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "orientation");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.DOMPointReadOnly, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "orientation", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.EventHandlerNonNull? Onredraw
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.EventHandlerNonNull?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "onredraw");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.EventHandlerNonNull?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "onredraw", value);
    }
}

#nullable disable