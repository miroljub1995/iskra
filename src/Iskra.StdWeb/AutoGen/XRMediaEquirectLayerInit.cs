// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class XRMediaEquirectLayerInit: global::Iskra.StdWeb.XRMediaLayerInit
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public XRMediaEquirectLayerInit(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public XRMediaEquirectLayerInit(): base()
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.XRRigidTransform? Transform
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.XRRigidTransform?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "transform");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.XRRigidTransform?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "transform", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public float Radius
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<float, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "radius");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<float, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "radius", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public float CentralHorizontalAngle
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<float, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "centralHorizontalAngle");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<float, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "centralHorizontalAngle", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public float UpperVerticalAngle
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<float, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "upperVerticalAngle");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<float, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "upperVerticalAngle", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public float LowerVerticalAngle
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<float, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "lowerVerticalAngle");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<float, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "lowerVerticalAngle", value);
    }
}

#nullable disable