// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class DeviceOrientationEventInit: global::Iskra.StdWeb.EventInit
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public DeviceOrientationEventInit(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public DeviceOrientationEventInit(): base()
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double? Alpha
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "alpha");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<double?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "alpha", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double? Beta
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "beta");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<double?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "beta", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double? Gamma
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "gamma");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<double?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "gamma", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool Absolute
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "absolute");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "absolute", value);
    }
}

#nullable disable