// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class GPUCopyExternalImageSourceInfo: global::Iskra.JSCore.JSObjectProxy
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public GPUCopyExternalImageSourceInfo(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public GPUCopyExternalImageSourceInfo(): base(global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "Object"))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public required global::Iskra.JSCore.Generics.Union<global::Iskra.StdWeb.ImageBitmap, global::Iskra.StdWeb.ImageData, global::Iskra.StdWeb.HTMLImageElement, global::Iskra.StdWeb.HTMLVideoElement, global::Iskra.StdWeb.VideoFrame, global::Iskra.StdWeb.HTMLCanvasElement, global::Iskra.StdWeb.OffscreenCanvas, global::Iskra.StdWeb.GenericMarshaller.Union> Source
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.Union<global::Iskra.StdWeb.ImageBitmap, global::Iskra.StdWeb.ImageData, global::Iskra.StdWeb.HTMLImageElement, global::Iskra.StdWeb.HTMLVideoElement, global::Iskra.StdWeb.VideoFrame, global::Iskra.StdWeb.HTMLCanvasElement, global::Iskra.StdWeb.OffscreenCanvas, global::Iskra.StdWeb.GenericMarshaller.Union>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "source");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.JSCore.Generics.Union<global::Iskra.StdWeb.ImageBitmap, global::Iskra.StdWeb.ImageData, global::Iskra.StdWeb.HTMLImageElement, global::Iskra.StdWeb.HTMLVideoElement, global::Iskra.StdWeb.VideoFrame, global::Iskra.StdWeb.HTMLCanvasElement, global::Iskra.StdWeb.OffscreenCanvas, global::Iskra.StdWeb.GenericMarshaller.Union>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "source", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.Union<global::Iskra.JSCore.Generics.JSArray<uint, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.GPUOrigin2DDict, global::Iskra.StdWeb.GenericMarshaller.Union> Origin
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.Union<global::Iskra.JSCore.Generics.JSArray<uint, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.GPUOrigin2DDict, global::Iskra.StdWeb.GenericMarshaller.Union>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "origin");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.JSCore.Generics.Union<global::Iskra.JSCore.Generics.JSArray<uint, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.GPUOrigin2DDict, global::Iskra.StdWeb.GenericMarshaller.Union>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "origin", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool FlipY
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "flipY");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "flipY", value);
    }
}

#nullable disable