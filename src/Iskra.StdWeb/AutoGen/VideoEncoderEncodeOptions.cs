// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class VideoEncoderEncodeOptions: global::Iskra.JSCore.JSObjectProxy
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public VideoEncoderEncodeOptions(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public VideoEncoderEncodeOptions(): base(global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "Object"))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.VideoEncoderEncodeOptionsForAvc Avc
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.VideoEncoderEncodeOptionsForAvc, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "avc");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.VideoEncoderEncodeOptionsForAvc, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "avc", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool KeyFrame
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "keyFrame");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "keyFrame", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.VideoEncoderEncodeOptionsForAv1 Av1
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.VideoEncoderEncodeOptionsForAv1, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "av1");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.VideoEncoderEncodeOptionsForAv1, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "av1", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.VideoEncoderEncodeOptionsForHevc Hevc
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.VideoEncoderEncodeOptionsForHevc, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "hevc");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.VideoEncoderEncodeOptionsForHevc, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "hevc", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.VideoEncoderEncodeOptionsForVp9 Vp9
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.VideoEncoderEncodeOptionsForVp9, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "vp9");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.VideoEncoderEncodeOptionsForVp9, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "vp9", value);
    }
}

#nullable disable