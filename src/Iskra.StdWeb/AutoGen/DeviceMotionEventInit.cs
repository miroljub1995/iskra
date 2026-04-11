// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class DeviceMotionEventInit: global::Iskra.StdWeb.EventInit
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public DeviceMotionEventInit(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public DeviceMotionEventInit(): base()
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.DeviceMotionEventAccelerationInit Acceleration
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.DeviceMotionEventAccelerationInit, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "acceleration");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.DeviceMotionEventAccelerationInit, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "acceleration", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.DeviceMotionEventAccelerationInit AccelerationIncludingGravity
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.DeviceMotionEventAccelerationInit, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "accelerationIncludingGravity");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.DeviceMotionEventAccelerationInit, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "accelerationIncludingGravity", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.DeviceMotionEventRotationRateInit RotationRate
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.DeviceMotionEventRotationRateInit, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "rotationRate");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.DeviceMotionEventRotationRateInit, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "rotationRate", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double Interval
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "interval");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "interval", value);
    }
}

#nullable disable