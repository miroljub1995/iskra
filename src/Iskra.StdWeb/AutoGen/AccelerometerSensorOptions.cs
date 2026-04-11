// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class AccelerometerSensorOptions: global::Iskra.StdWeb.SensorOptions
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public AccelerometerSensorOptions(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public AccelerometerSensorOptions(): base()
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.AccelerometerLocalCoordinateSystem ReferenceFrame
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.AccelerometerLocalCoordinateSystem, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "referenceFrame");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.AccelerometerLocalCoordinateSystem, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "referenceFrame", value);
    }
}

#nullable disable