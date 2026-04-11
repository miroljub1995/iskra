// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class GPURenderPassLayout: global::Iskra.StdWeb.GPUObjectDescriptorBase
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public GPURenderPassLayout(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public GPURenderPassLayout(): base()
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public required global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.GPUTextureFormat?, global::Iskra.StdWeb.PropertyAccessorNullable> ColorFormats
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.GPUTextureFormat?, global::Iskra.StdWeb.PropertyAccessorNullable>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "colorFormats");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.GPUTextureFormat?, global::Iskra.StdWeb.PropertyAccessorNullable>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "colorFormats", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.GPUTextureFormat DepthStencilFormat
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.GPUTextureFormat, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "depthStencilFormat");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.GPUTextureFormat, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "depthStencilFormat", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public uint SampleCount
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<uint, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "sampleCount");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<uint, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "sampleCount", value);
    }
}

#nullable disable