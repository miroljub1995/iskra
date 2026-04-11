// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class XRMediaQuadLayerInit: global::Iskra.StdWeb.XRMediaLayerInit
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public XRMediaQuadLayerInit(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public XRMediaQuadLayerInit(): base()
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.XRRigidTransform? Transform
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.XRRigidTransform?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "transform");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.XRRigidTransform?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "transform", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public float? Width
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<float?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "width");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<float?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "width", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public float? Height
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<float?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "height");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<float?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "height", value);
    }
}

#nullable disable