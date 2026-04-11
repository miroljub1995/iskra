// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class ScrollIntoViewOptions: global::Iskra.StdWeb.ScrollOptions
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ScrollIntoViewOptions(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ScrollIntoViewOptions(): base()
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.ScrollLogicalPosition Block
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.ScrollLogicalPosition, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "block");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.ScrollLogicalPosition, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "block", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.ScrollLogicalPosition Inline
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.ScrollLogicalPosition, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "inline");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.ScrollLogicalPosition, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "inline", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.ScrollIntoViewContainer Container
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.ScrollIntoViewContainer, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "container");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.ScrollIntoViewContainer, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "container", value);
    }
}

#nullable disable