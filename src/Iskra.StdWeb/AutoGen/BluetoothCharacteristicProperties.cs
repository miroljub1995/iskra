// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class BluetoothCharacteristicProperties: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public BluetoothCharacteristicProperties(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool Broadcast
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "broadcast");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool Read
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "read");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool WriteWithoutResponse
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "writeWithoutResponse");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool Write
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "write");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool Notify
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "notify");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool Indicate
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "indicate");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool AuthenticatedSignedWrites
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "authenticatedSignedWrites");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool ReliableWrite
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "reliableWrite");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool WritableAuxiliaries
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "writableAuxiliaries");
    }
}

#nullable disable