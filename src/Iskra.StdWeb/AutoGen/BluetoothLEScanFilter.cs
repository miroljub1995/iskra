// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class BluetoothLEScanFilter: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public BluetoothLEScanFilter(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatformAttribute("browser")]
    public static global::Iskra.StdWeb.BluetoothLEScanFilter New()
    {
        global::System.Runtime.InteropServices.JavaScript.JSObject ___res_2 = global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "BluetoothLEScanFilter");
        return new global::Iskra.StdWeb.BluetoothLEScanFilter(___res_2);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatformAttribute("browser")]
    public static global::Iskra.StdWeb.BluetoothLEScanFilter New(global::Iskra.StdWeb.BluetoothLEScanFilterInit init)
    {
        int ___argsArrayLength_3 = 1;

        using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_3);

        // Argument 1
        global::System.Runtime.InteropServices.JavaScript.JSObject ___marshalledValue_4;
        ___marshalledValue_4 = init.JSObject;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2(___argsArray_0.JSObject, 0, ___marshalledValue_4);

        global::System.Runtime.InteropServices.JavaScript.JSObject ___res_2 = global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectNonEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "BluetoothLEScanFilter", ___argsArray_0.JSObject);
        return new global::Iskra.StdWeb.BluetoothLEScanFilter(___res_2);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? Name
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "name");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? NamePrefix
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "namePrefix");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.FrozenArray<string, global::Iskra.StdWeb.PropertyAccessor> Services
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.FrozenArray<string, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "services");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.BluetoothManufacturerDataFilter ManufacturerData
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.BluetoothManufacturerDataFilter, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "manufacturerData");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.BluetoothServiceDataFilter ServiceData
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.BluetoothServiceDataFilter, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "serviceData");
    }
}

#nullable disable