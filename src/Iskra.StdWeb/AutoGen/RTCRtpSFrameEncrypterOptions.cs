// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class RTCRtpSFrameEncrypterOptions: global::Iskra.StdWeb.SFrameTransformOptions
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public RTCRtpSFrameEncrypterOptions(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public RTCRtpSFrameEncrypterOptions(): base()
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SFrameType Type
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SFrameType, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "type");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.SFrameType, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "type", value);
    }
}

#nullable disable