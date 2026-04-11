// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class NavigationCurrentEntryChangeEventInit: global::Iskra.StdWeb.EventInit
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public NavigationCurrentEntryChangeEventInit(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public NavigationCurrentEntryChangeEventInit(): base()
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.NavigationType? NavigationType
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.NavigationType?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "navigationType");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.NavigationType?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "navigationType", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public required global::Iskra.StdWeb.NavigationHistoryEntry From
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.NavigationHistoryEntry, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "from");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.NavigationHistoryEntry, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "from", value);
    }
}

#nullable disable