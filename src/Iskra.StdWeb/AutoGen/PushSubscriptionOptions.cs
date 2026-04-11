// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class PushSubscriptionOptions: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public PushSubscriptionOptions(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool UserVisibleOnly
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "userVisibleOnly");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.ArrayBuffer? ApplicationServerKey
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.ArrayBuffer?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "applicationServerKey");
    }
}

#nullable disable