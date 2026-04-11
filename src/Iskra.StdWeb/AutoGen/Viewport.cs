// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class Viewport: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public Viewport(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.FrozenArray<global::Iskra.StdWeb.DOMRect, global::Iskra.StdWeb.PropertyAccessor>? Segments
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.FrozenArray<global::Iskra.StdWeb.DOMRect, global::Iskra.StdWeb.PropertyAccessor>?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "segments");
    }
}

#nullable disable