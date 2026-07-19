// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class XRGPULayerInit: global::Iskra.JSCore.JSObjectProxy
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public XRGPULayerInit(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public XRGPULayerInit(): base(global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "Object"))
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
    public required global::Iskra.StdWeb.XRSpace Space
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.XRSpace, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "space");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.XRSpace, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "space", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public uint MipLevels
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<uint, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "mipLevels");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<uint, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "mipLevels", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public required uint ViewPixelWidth
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<uint, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "viewPixelWidth");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<uint, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "viewPixelWidth", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public required uint ViewPixelHeight
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<uint, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "viewPixelHeight");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<uint, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "viewPixelHeight", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.XRLayerLayout Layout
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.XRLayerLayout, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "layout");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.XRLayerLayout, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "layout", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool IsStatic
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "isStatic");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "isStatic", value);
    }
}

#nullable disable