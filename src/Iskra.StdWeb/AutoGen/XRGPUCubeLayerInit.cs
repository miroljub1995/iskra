// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class XRGPUCubeLayerInit: global::Iskra.StdWeb.XRGPULayerInit
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public XRGPUCubeLayerInit(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public XRGPUCubeLayerInit(): base()
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.DOMPointReadOnly? Orientation
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.DOMPointReadOnly?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "orientation");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.DOMPointReadOnly?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "orientation", value);
    }
}

#nullable disable