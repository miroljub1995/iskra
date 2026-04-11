// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class NavigationEventInit: global::Iskra.StdWeb.UIEventInit
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public NavigationEventInit(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public NavigationEventInit(): base()
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SpatialNavigationDirection Dir
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SpatialNavigationDirection, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "dir");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.SpatialNavigationDirection, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "dir", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.EventTarget? RelatedTarget
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.EventTarget?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "relatedTarget");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.EventTarget?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "relatedTarget", value);
    }
}

#nullable disable