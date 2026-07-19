// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class SVGRect: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public SVGRect(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public float X
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<float, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "x");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<float, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "x", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public float Y
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<float, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "y");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<float, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "y", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public float Width
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<float, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "width");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<float, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "width", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public float Height
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<float, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "height");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<float, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "height", value);
    }
}

#nullable disable