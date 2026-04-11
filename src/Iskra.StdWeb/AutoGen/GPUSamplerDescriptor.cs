// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class GPUSamplerDescriptor: global::Iskra.StdWeb.GPUObjectDescriptorBase
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public GPUSamplerDescriptor(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public GPUSamplerDescriptor(): base()
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.GPUAddressMode AddressModeU
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.GPUAddressMode, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "addressModeU");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.GPUAddressMode, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "addressModeU", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.GPUAddressMode AddressModeV
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.GPUAddressMode, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "addressModeV");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.GPUAddressMode, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "addressModeV", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.GPUAddressMode AddressModeW
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.GPUAddressMode, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "addressModeW");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.GPUAddressMode, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "addressModeW", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.GPUFilterMode MagFilter
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.GPUFilterMode, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "magFilter");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.GPUFilterMode, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "magFilter", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.GPUFilterMode MinFilter
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.GPUFilterMode, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "minFilter");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.GPUFilterMode, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "minFilter", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.GPUMipmapFilterMode MipmapFilter
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.GPUMipmapFilterMode, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "mipmapFilter");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.GPUMipmapFilterMode, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "mipmapFilter", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public float LodMinClamp
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<float, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "lodMinClamp");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<float, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "lodMinClamp", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public float LodMaxClamp
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<float, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "lodMaxClamp");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<float, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "lodMaxClamp", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.GPUCompareFunction Compare
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.GPUCompareFunction, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "compare");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.GPUCompareFunction, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "compare", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ushort MaxAnisotropy
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<ushort, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "maxAnisotropy");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<ushort, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "maxAnisotropy", value);
    }
}

#nullable disable