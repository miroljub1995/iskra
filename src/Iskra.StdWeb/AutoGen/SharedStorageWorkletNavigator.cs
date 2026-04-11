// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class SharedStorageWorkletNavigator: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public SharedStorageWorkletNavigator(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.LockManager Locks
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.LockManager, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "locks");
    }
}

#nullable disable