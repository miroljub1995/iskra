// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class BluetoothAdvertisingEvent: global::Iskra.StdWeb.Event
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public BluetoothAdvertisingEvent(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatformAttribute("browser")]
    public static global::Iskra.StdWeb.BluetoothAdvertisingEvent New(string type, global::Iskra.StdWeb.BluetoothAdvertisingEventInit init)
    {
        int ___argsArrayLength_3 = 2;

        using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_3);

        // Argument 1
        string ___marshalledValue_4;
        ___marshalledValue_4 = type;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsStringV2(___argsArray_0.JSObject, 0, ___marshalledValue_4);

        // Argument 2
        global::System.Runtime.InteropServices.JavaScript.JSObject ___marshalledValue_5;
        ___marshalledValue_5 = init.JSObject;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2(___argsArray_0.JSObject, 1, ___marshalledValue_5);

        global::System.Runtime.InteropServices.JavaScript.JSObject ___res_2 = global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectNonEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "BluetoothAdvertisingEvent", ___argsArray_0.JSObject);
        return new global::Iskra.StdWeb.BluetoothAdvertisingEvent(___res_2);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.BluetoothDevice Device
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.BluetoothDevice, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "device");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.FrozenArray<string, global::Iskra.StdWeb.PropertyAccessor> Uuids
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.FrozenArray<string, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "uuids");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? Name
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "name");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ushort? Appearance
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<ushort?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "appearance");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public sbyte? TxPower
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<sbyte?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "txPower");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public sbyte? Rssi
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<sbyte?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "rssi");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.BluetoothManufacturerDataMap ManufacturerData
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.BluetoothManufacturerDataMap, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "manufacturerData");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.BluetoothServiceDataMap ServiceData
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.BluetoothServiceDataMap, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "serviceData");
    }
}

#nullable disable