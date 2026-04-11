// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class MediaCapabilitiesEncodingInfo: global::Iskra.StdWeb.MediaCapabilitiesInfo
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public MediaCapabilitiesEncodingInfo(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public MediaCapabilitiesEncodingInfo(): base()
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public required global::Iskra.StdWeb.MediaEncodingConfiguration Configuration
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.MediaEncodingConfiguration, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "configuration");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.MediaEncodingConfiguration, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "configuration", value);
    }
}

#nullable disable