// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class VideoFrame: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public VideoFrame(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatformAttribute("browser")]
    public static global::Iskra.StdWeb.VideoFrame New(global::Iskra.JSCore.Generics.Union<global::Iskra.StdWeb.HTMLImageElement, global::Iskra.StdWeb.SVGImageElement, global::Iskra.StdWeb.HTMLVideoElement, global::Iskra.StdWeb.HTMLCanvasElement, global::Iskra.StdWeb.ImageBitmap, global::Iskra.StdWeb.OffscreenCanvas, global::Iskra.StdWeb.VideoFrame, global::Iskra.StdWeb.GenericMarshaller.Union> image)
    {
        int ___argsArrayLength_3 = 1;

        using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_3);

        // Argument 1
        global::System.Runtime.InteropServices.JavaScript.JSObject ___propObject_4 = image.JSObject;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsUnion(___argsArray_0.JSObject, 0, ___propObject_4);

        global::System.Runtime.InteropServices.JavaScript.JSObject ___res_2 = global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectNonEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "VideoFrame", ___argsArray_0.JSObject);
        return new global::Iskra.StdWeb.VideoFrame(___res_2);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatformAttribute("browser")]
    public static global::Iskra.StdWeb.VideoFrame New(global::Iskra.JSCore.Generics.Union<global::Iskra.StdWeb.HTMLImageElement, global::Iskra.StdWeb.SVGImageElement, global::Iskra.StdWeb.HTMLVideoElement, global::Iskra.StdWeb.HTMLCanvasElement, global::Iskra.StdWeb.ImageBitmap, global::Iskra.StdWeb.OffscreenCanvas, global::Iskra.StdWeb.VideoFrame, global::Iskra.StdWeb.GenericMarshaller.Union> image, global::Iskra.StdWeb.VideoFrameInit init)
    {
        int ___argsArrayLength_3 = 2;

        using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_3);

        // Argument 1
        global::System.Runtime.InteropServices.JavaScript.JSObject ___propObject_4 = image.JSObject;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsUnion(___argsArray_0.JSObject, 0, ___propObject_4);

        // Argument 2
        global::System.Runtime.InteropServices.JavaScript.JSObject ___marshalledValue_5;
        ___marshalledValue_5 = init.JSObject;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2(___argsArray_0.JSObject, 1, ___marshalledValue_5);

        global::System.Runtime.InteropServices.JavaScript.JSObject ___res_2 = global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectNonEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "VideoFrame", ___argsArray_0.JSObject);
        return new global::Iskra.StdWeb.VideoFrame(___res_2);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatformAttribute("browser")]
    public static global::Iskra.StdWeb.VideoFrame New(global::Iskra.JSCore.Generics.Union<global::Iskra.JSCore.ArrayBuffer, global::Iskra.JSCore.SharedArrayBuffer, global::Iskra.JSCore.Int8Array, global::Iskra.JSCore.Int16Array, global::Iskra.JSCore.Int32Array, global::Iskra.JSCore.Uint8Array, global::Iskra.JSCore.Uint16Array, global::Iskra.JSCore.Uint32Array, global::Iskra.JSCore.Uint8ClampedArray, global::Iskra.JSCore.BigInt64Array, global::Iskra.JSCore.BigUint64Array, global::Iskra.JSCore.Float16Array, global::Iskra.JSCore.Float32Array, global::Iskra.JSCore.Float64Array, global::Iskra.JSCore.DataView, global::Iskra.StdWeb.GenericMarshaller.Union> data, global::Iskra.StdWeb.VideoFrameBufferInit init)
    {
        int ___argsArrayLength_3 = 2;

        using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_3);

        // Argument 1
        global::System.Runtime.InteropServices.JavaScript.JSObject ___propObject_4 = data.JSObject;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsUnion(___argsArray_0.JSObject, 0, ___propObject_4);

        // Argument 2
        global::System.Runtime.InteropServices.JavaScript.JSObject ___marshalledValue_5;
        ___marshalledValue_5 = init.JSObject;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2(___argsArray_0.JSObject, 1, ___marshalledValue_5);

        global::System.Runtime.InteropServices.JavaScript.JSObject ___res_2 = global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectNonEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "VideoFrame", ___argsArray_0.JSObject);
        return new global::Iskra.StdWeb.VideoFrame(___res_2);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.VideoPixelFormat? Format
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.VideoPixelFormat?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "format");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public uint CodedWidth
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<uint, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "codedWidth");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public uint CodedHeight
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<uint, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "codedHeight");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.DOMRectReadOnly? CodedRect
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.DOMRectReadOnly?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "codedRect");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.DOMRectReadOnly? VisibleRect
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.DOMRectReadOnly?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "visibleRect");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double Rotation
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "rotation");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool Flip
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "flip");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public uint DisplayWidth
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<uint, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "displayWidth");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public uint DisplayHeight
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<uint, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "displayHeight");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ulong? Duration
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<ulong?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "duration");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public long Timestamp
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<long, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "timestamp");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.VideoColorSpace ColorSpace
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.VideoColorSpace, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "colorSpace");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.VideoFrameMetadata Metadata()
    {
        using global::Iskra.JSCore.FunctionResPool.Owner ___resOwner_1 = global::Iskra.JSCore.FunctionResPool.Shared.Rent();

        global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallEmptyNonVoidFunctionProperty(JSObject, "metadata", JSObject, ___resOwner_1.JSObject);

        // Return Value
        return global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.VideoFrameMetadata, global::Iskra.StdWeb.PropertyAccessor>(___resOwner_1.JSObject, "value");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public uint AllocationSize()
    {
        using global::Iskra.JSCore.FunctionResPool.Owner ___resOwner_1 = global::Iskra.JSCore.FunctionResPool.Shared.Rent();

        global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallEmptyNonVoidFunctionProperty(JSObject, "allocationSize", JSObject, ___resOwner_1.JSObject);

        // Return Value
        return global::Iskra.JSCore.Generics.PropertyAccessor.Get<uint, global::Iskra.StdWeb.PropertyAccessor>(___resOwner_1.JSObject, "value");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public uint AllocationSize(global::Iskra.StdWeb.VideoFrameCopyToOptions options)
    {
        int ___argsArrayLength_2 = 1;

        using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_2);

        // Argument 1
        global::System.Runtime.InteropServices.JavaScript.JSObject ___marshalledValue_3;
        ___marshalledValue_3 = options.JSObject;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2(___argsArray_0.JSObject, 0, ___marshalledValue_3);

        using global::Iskra.JSCore.FunctionResPool.Owner ___resOwner_1 = global::Iskra.JSCore.FunctionResPool.Shared.Rent();

        global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallNonEmptyNonVoidFunctionProperty(JSObject, "allocationSize", JSObject, ___argsArray_0.JSObject, ___resOwner_1.JSObject);

        // Return Value
        return global::Iskra.JSCore.Generics.PropertyAccessor.Get<uint, global::Iskra.StdWeb.PropertyAccessor>(___resOwner_1.JSObject, "value");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.Promise<global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.PlaneLayout, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor> CopyTo(global::Iskra.JSCore.Generics.Union<global::Iskra.JSCore.ArrayBuffer, global::Iskra.JSCore.SharedArrayBuffer, global::Iskra.JSCore.Int8Array, global::Iskra.JSCore.Int16Array, global::Iskra.JSCore.Int32Array, global::Iskra.JSCore.Uint8Array, global::Iskra.JSCore.Uint16Array, global::Iskra.JSCore.Uint32Array, global::Iskra.JSCore.Uint8ClampedArray, global::Iskra.JSCore.BigInt64Array, global::Iskra.JSCore.BigUint64Array, global::Iskra.JSCore.Float16Array, global::Iskra.JSCore.Float32Array, global::Iskra.JSCore.Float64Array, global::Iskra.JSCore.DataView, global::Iskra.StdWeb.GenericMarshaller.Union> destination)
    {
        int ___argsArrayLength_2 = 1;

        using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_2);

        // Argument 1
        global::System.Runtime.InteropServices.JavaScript.JSObject ___propObject_3 = destination.JSObject;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsUnion(___argsArray_0.JSObject, 0, ___propObject_3);

        using global::Iskra.JSCore.FunctionResPool.Owner ___resOwner_1 = global::Iskra.JSCore.FunctionResPool.Shared.Rent();

        global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallNonEmptyNonVoidFunctionProperty(JSObject, "copyTo", JSObject, ___argsArray_0.JSObject, ___resOwner_1.JSObject);

        // Return Value
        return global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.Promise<global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.PlaneLayout, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(___resOwner_1.JSObject, "value");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.Promise<global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.PlaneLayout, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor> CopyTo(global::Iskra.JSCore.Generics.Union<global::Iskra.JSCore.ArrayBuffer, global::Iskra.JSCore.SharedArrayBuffer, global::Iskra.JSCore.Int8Array, global::Iskra.JSCore.Int16Array, global::Iskra.JSCore.Int32Array, global::Iskra.JSCore.Uint8Array, global::Iskra.JSCore.Uint16Array, global::Iskra.JSCore.Uint32Array, global::Iskra.JSCore.Uint8ClampedArray, global::Iskra.JSCore.BigInt64Array, global::Iskra.JSCore.BigUint64Array, global::Iskra.JSCore.Float16Array, global::Iskra.JSCore.Float32Array, global::Iskra.JSCore.Float64Array, global::Iskra.JSCore.DataView, global::Iskra.StdWeb.GenericMarshaller.Union> destination, global::Iskra.StdWeb.VideoFrameCopyToOptions options)
    {
        int ___argsArrayLength_2 = 2;

        using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_2);

        // Argument 1
        global::System.Runtime.InteropServices.JavaScript.JSObject ___propObject_3 = destination.JSObject;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsUnion(___argsArray_0.JSObject, 0, ___propObject_3);

        // Argument 2
        global::System.Runtime.InteropServices.JavaScript.JSObject ___marshalledValue_4;
        ___marshalledValue_4 = options.JSObject;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2(___argsArray_0.JSObject, 1, ___marshalledValue_4);

        using global::Iskra.JSCore.FunctionResPool.Owner ___resOwner_1 = global::Iskra.JSCore.FunctionResPool.Shared.Rent();

        global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallNonEmptyNonVoidFunctionProperty(JSObject, "copyTo", JSObject, ___argsArray_0.JSObject, ___resOwner_1.JSObject);

        // Return Value
        return global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.Promise<global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.PlaneLayout, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(___resOwner_1.JSObject, "value");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.VideoFrame Clone()
    {
        using global::Iskra.JSCore.FunctionResPool.Owner ___resOwner_1 = global::Iskra.JSCore.FunctionResPool.Shared.Rent();

        global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallEmptyNonVoidFunctionProperty(JSObject, "clone", JSObject, ___resOwner_1.JSObject);

        // Return Value
        return global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.VideoFrame, global::Iskra.StdWeb.PropertyAccessor>(___resOwner_1.JSObject, "value");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public void Close()
    {
        global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallEmptyVoidFunctionProperty(JSObject, "close", JSObject);
    }
}

#nullable disable