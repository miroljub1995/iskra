// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class VideoPlaybackQuality: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public VideoPlaybackQuality(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double CreationTime
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "creationTime");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public uint DroppedVideoFrames
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<uint, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "droppedVideoFrames");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public uint TotalVideoFrames
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<uint, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "totalVideoFrames");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public uint CorruptedVideoFrames
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<uint, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "corruptedVideoFrames");
    }
}

#nullable disable