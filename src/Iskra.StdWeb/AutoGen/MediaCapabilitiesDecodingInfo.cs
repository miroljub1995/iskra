// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class MediaCapabilitiesDecodingInfo: global::Iskra.StdWeb.MediaCapabilitiesInfo
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public MediaCapabilitiesDecodingInfo(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public MediaCapabilitiesDecodingInfo(): base()
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public required global::Iskra.StdWeb.MediaKeySystemAccess? KeySystemAccess
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.MediaKeySystemAccess?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "keySystemAccess");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.MediaKeySystemAccess?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "keySystemAccess", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public required global::Iskra.StdWeb.MediaDecodingConfiguration Configuration
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.MediaDecodingConfiguration, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "configuration");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.MediaDecodingConfiguration, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "configuration", value);
    }
}

#nullable disable