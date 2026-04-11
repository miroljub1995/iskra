// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class ChildBreakToken: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ChildBreakToken(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.BreakType BreakType
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.BreakType, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "breakType");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.LayoutChild Child
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.LayoutChild, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "child");
    }
}

#nullable disable