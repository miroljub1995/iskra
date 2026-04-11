// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class ProximitySensor: global::Iskra.StdWeb.Sensor
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ProximitySensor(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatformAttribute("browser")]
    public static global::Iskra.StdWeb.ProximitySensor New()
    {
        global::System.Runtime.InteropServices.JavaScript.JSObject ___res_2 = global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "ProximitySensor");
        return new global::Iskra.StdWeb.ProximitySensor(___res_2);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatformAttribute("browser")]
    public static global::Iskra.StdWeb.ProximitySensor New(global::Iskra.StdWeb.SensorOptions sensorOptions)
    {
        int ___argsArrayLength_3 = 1;

        using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_3);

        // Argument 1
        global::System.Runtime.InteropServices.JavaScript.JSObject ___marshalledValue_4;
        ___marshalledValue_4 = sensorOptions.JSObject;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2(___argsArray_0.JSObject, 0, ___marshalledValue_4);

        global::System.Runtime.InteropServices.JavaScript.JSObject ___res_2 = global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectNonEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "ProximitySensor", ___argsArray_0.JSObject);
        return new global::Iskra.StdWeb.ProximitySensor(___res_2);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double? Distance
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "distance");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double? Max
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "max");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool? Near
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "near");
    }
}

#nullable disable