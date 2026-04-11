// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class NavigationActivation: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public NavigationActivation(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.NavigationHistoryEntry? From
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.NavigationHistoryEntry?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "from");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.NavigationHistoryEntry Entry
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.NavigationHistoryEntry, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "entry");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.NavigationType NavigationType
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.NavigationType, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "navigationType");
    }
}

#nullable disable