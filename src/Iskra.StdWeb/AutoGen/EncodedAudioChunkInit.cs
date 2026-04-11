// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class EncodedAudioChunkInit: global::Iskra.JSCore.JSObjectProxy
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public EncodedAudioChunkInit(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public EncodedAudioChunkInit(): base(global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "Object"))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public required global::Iskra.StdWeb.EncodedAudioChunkType Type
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.EncodedAudioChunkType, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "type");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.EncodedAudioChunkType, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "type", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public required long Timestamp
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<long, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "timestamp");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<long, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "timestamp", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ulong Duration
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<ulong, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "duration");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<ulong, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "duration", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public required global::Iskra.JSCore.Generics.Union<global::Iskra.JSCore.ArrayBuffer, global::Iskra.JSCore.SharedArrayBuffer, global::Iskra.JSCore.Int8Array, global::Iskra.JSCore.Int16Array, global::Iskra.JSCore.Int32Array, global::Iskra.JSCore.Uint8Array, global::Iskra.JSCore.Uint16Array, global::Iskra.JSCore.Uint32Array, global::Iskra.JSCore.Uint8ClampedArray, global::Iskra.JSCore.BigInt64Array, global::Iskra.JSCore.BigUint64Array, global::Iskra.JSCore.Float16Array, global::Iskra.JSCore.Float32Array, global::Iskra.JSCore.Float64Array, global::Iskra.JSCore.DataView, global::Iskra.StdWeb.GenericMarshaller.Union> Data
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.Union<global::Iskra.JSCore.ArrayBuffer, global::Iskra.JSCore.SharedArrayBuffer, global::Iskra.JSCore.Int8Array, global::Iskra.JSCore.Int16Array, global::Iskra.JSCore.Int32Array, global::Iskra.JSCore.Uint8Array, global::Iskra.JSCore.Uint16Array, global::Iskra.JSCore.Uint32Array, global::Iskra.JSCore.Uint8ClampedArray, global::Iskra.JSCore.BigInt64Array, global::Iskra.JSCore.BigUint64Array, global::Iskra.JSCore.Float16Array, global::Iskra.JSCore.Float32Array, global::Iskra.JSCore.Float64Array, global::Iskra.JSCore.DataView, global::Iskra.StdWeb.GenericMarshaller.Union>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "data");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.JSCore.Generics.Union<global::Iskra.JSCore.ArrayBuffer, global::Iskra.JSCore.SharedArrayBuffer, global::Iskra.JSCore.Int8Array, global::Iskra.JSCore.Int16Array, global::Iskra.JSCore.Int32Array, global::Iskra.JSCore.Uint8Array, global::Iskra.JSCore.Uint16Array, global::Iskra.JSCore.Uint32Array, global::Iskra.JSCore.Uint8ClampedArray, global::Iskra.JSCore.BigInt64Array, global::Iskra.JSCore.BigUint64Array, global::Iskra.JSCore.Float16Array, global::Iskra.JSCore.Float32Array, global::Iskra.JSCore.Float64Array, global::Iskra.JSCore.DataView, global::Iskra.StdWeb.GenericMarshaller.Union>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "data", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.JSArray<global::Iskra.JSCore.ArrayBuffer, global::Iskra.StdWeb.PropertyAccessor> Transfer
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.JSArray<global::Iskra.JSCore.ArrayBuffer, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "transfer");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.JSCore.Generics.JSArray<global::Iskra.JSCore.ArrayBuffer, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "transfer", value);
    }
}

#nullable disable