// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class MediaDecodingConfiguration: global::Iskra.StdWeb.MediaConfiguration
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public MediaDecodingConfiguration(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public MediaDecodingConfiguration(): base()
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public required global::Iskra.StdWeb.MediaDecodingType Type
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.MediaDecodingType, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "type");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.MediaDecodingType, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "type", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.MediaCapabilitiesKeySystemConfiguration KeySystemConfiguration
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.MediaCapabilitiesKeySystemConfiguration, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "keySystemConfiguration");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.MediaCapabilitiesKeySystemConfiguration, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "keySystemConfiguration", value);
    }
}

#nullable disable