// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class XRGPUProjectionLayerInit: global::Iskra.JSCore.JSObjectProxy
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public XRGPUProjectionLayerInit(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public XRGPUProjectionLayerInit(): base(global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "Object"))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public required global::Iskra.StdWeb.GPUTextureFormat ColorFormat
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.GPUTextureFormat, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "colorFormat");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.GPUTextureFormat, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "colorFormat", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.GPUTextureFormat? DepthStencilFormat
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.GPUTextureFormat?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "depthStencilFormat");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.GPUTextureFormat?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "depthStencilFormat", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public uint TextureUsage
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<uint, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "textureUsage");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<uint, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "textureUsage", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double ScaleFactor
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "scaleFactor");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "scaleFactor", value);
    }
}

#nullable disable