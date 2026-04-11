// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class LayoutShiftAttribution: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public LayoutShiftAttribution(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.Node? Node
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.Node?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "node");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.DOMRectReadOnly PreviousRect
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.DOMRectReadOnly, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "previousRect");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.DOMRectReadOnly CurrentRect
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.DOMRectReadOnly, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "currentRect");
    }
}

#nullable disable