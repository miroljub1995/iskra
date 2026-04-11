// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class PushSubscriptionChangeEventInit: global::Iskra.StdWeb.ExtendableEventInit
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public PushSubscriptionChangeEventInit(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public PushSubscriptionChangeEventInit(): base()
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.PushSubscription NewSubscription
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.PushSubscription, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "newSubscription");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.PushSubscription, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "newSubscription", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.PushSubscription OldSubscription
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.PushSubscription, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "oldSubscription");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.PushSubscription, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "oldSubscription", value);
    }
}

#nullable disable