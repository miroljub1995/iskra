// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class PictureInPictureWindow: global::Iskra.StdWeb.EventTarget
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public PictureInPictureWindow(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public int Width
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<int, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "width");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public int Height
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<int, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "height");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.EventHandlerNonNull? Onresize
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.EventHandlerNonNull?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "onresize");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.EventHandlerNonNull?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "onresize", value);
    }
}

#nullable disable