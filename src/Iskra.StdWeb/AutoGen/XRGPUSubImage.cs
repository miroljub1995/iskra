// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class XRGPUSubImage: global::Iskra.StdWeb.XRSubImage
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public XRGPUSubImage(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.GPUTexture ColorTexture
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.GPUTexture, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "colorTexture");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.GPUTexture? DepthStencilTexture
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.GPUTexture?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "depthStencilTexture");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.GPUTexture? MotionVectorTexture
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.GPUTexture?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "motionVectorTexture");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.GPUTextureViewDescriptor GetViewDescriptor()
    {
        using global::Iskra.JSCore.FunctionResPool.Owner ___resOwner_1 = global::Iskra.JSCore.FunctionResPool.Shared.Rent();

        global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallEmptyNonVoidFunctionProperty(JSObject, "getViewDescriptor", JSObject, ___resOwner_1.JSObject);

        // Return Value
        return global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.GPUTextureViewDescriptor, global::Iskra.StdWeb.PropertyAccessor>(___resOwner_1.JSObject, "value");
    }
}

#nullable disable