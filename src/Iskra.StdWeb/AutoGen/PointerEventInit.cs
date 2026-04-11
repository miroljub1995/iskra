// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class PointerEventInit: global::Iskra.StdWeb.MouseEventInit
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public PointerEventInit(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public PointerEventInit(): base()
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public int PointerId
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<int, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "pointerId");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<int, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "pointerId", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double Width
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "width");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "width", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double Height
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "height");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "height", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public float Pressure
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<float, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "pressure");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<float, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "pressure", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public float TangentialPressure
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<float, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "tangentialPressure");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<float, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "tangentialPressure", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public int TiltX
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<int, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "tiltX");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<int, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "tiltX", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public int TiltY
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<int, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "tiltY");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<int, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "tiltY", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public int Twist
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<int, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "twist");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<int, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "twist", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double AltitudeAngle
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "altitudeAngle");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "altitudeAngle", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double AzimuthAngle
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "azimuthAngle");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "azimuthAngle", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string PointerType
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "pointerType");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "pointerType", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool IsPrimary
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "isPrimary");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "isPrimary", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public int PersistentDeviceId
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<int, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "persistentDeviceId");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<int, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "persistentDeviceId", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.PointerEvent, global::Iskra.StdWeb.PropertyAccessor> CoalescedEvents
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.PointerEvent, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "coalescedEvents");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.PointerEvent, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "coalescedEvents", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.PointerEvent, global::Iskra.StdWeb.PropertyAccessor> PredictedEvents
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.PointerEvent, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "predictedEvents");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.PointerEvent, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "predictedEvents", value);
    }
}

#nullable disable