// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class GPUBindGroupEntry: global::Iskra.JSCore.JSObjectProxy
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public GPUBindGroupEntry(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public GPUBindGroupEntry(): base(global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "Object"))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public required uint Binding
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<uint, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "binding");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<uint, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "binding", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public required global::Iskra.JSCore.Generics.Union<global::Iskra.StdWeb.GPUSampler, global::Iskra.StdWeb.GPUTexture, global::Iskra.StdWeb.GPUTextureView, global::Iskra.StdWeb.GPUBuffer, global::Iskra.StdWeb.GPUBufferBinding, global::Iskra.StdWeb.GPUExternalTexture, global::Iskra.StdWeb.GenericMarshaller.Union> Resource
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.Union<global::Iskra.StdWeb.GPUSampler, global::Iskra.StdWeb.GPUTexture, global::Iskra.StdWeb.GPUTextureView, global::Iskra.StdWeb.GPUBuffer, global::Iskra.StdWeb.GPUBufferBinding, global::Iskra.StdWeb.GPUExternalTexture, global::Iskra.StdWeb.GenericMarshaller.Union>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "resource");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.JSCore.Generics.Union<global::Iskra.StdWeb.GPUSampler, global::Iskra.StdWeb.GPUTexture, global::Iskra.StdWeb.GPUTextureView, global::Iskra.StdWeb.GPUBuffer, global::Iskra.StdWeb.GPUBufferBinding, global::Iskra.StdWeb.GPUExternalTexture, global::Iskra.StdWeb.GenericMarshaller.Union>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "resource", value);
    }
}

#nullable disable