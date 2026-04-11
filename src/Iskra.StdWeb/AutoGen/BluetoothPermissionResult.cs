// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class BluetoothPermissionResult: global::Iskra.StdWeb.PermissionStatus
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public BluetoothPermissionResult(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.FrozenArray<global::Iskra.StdWeb.BluetoothDevice, global::Iskra.StdWeb.PropertyAccessor> Devices
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.FrozenArray<global::Iskra.StdWeb.BluetoothDevice, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "devices");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.JSCore.Generics.FrozenArray<global::Iskra.StdWeb.BluetoothDevice, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "devices", value);
    }
}

#nullable disable