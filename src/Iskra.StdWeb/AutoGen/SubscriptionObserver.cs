// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class SubscriptionObserver: global::Iskra.JSCore.JSObjectProxy
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public SubscriptionObserver(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public SubscriptionObserver(): base(global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "Object"))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.ObservableSubscriptionCallback Next
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.ObservableSubscriptionCallback, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "next");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.ObservableSubscriptionCallback, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "next", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.ObservableSubscriptionCallback Error
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.ObservableSubscriptionCallback, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "error");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.ObservableSubscriptionCallback, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "error", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.VoidFunction Complete
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.VoidFunction, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "complete");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.VoidFunction, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "complete", value);
    }
}

#nullable disable