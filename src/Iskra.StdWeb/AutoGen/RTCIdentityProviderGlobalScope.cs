// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class RTCIdentityProviderGlobalScope: global::Iskra.StdWeb.WorkerGlobalScope
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public RTCIdentityProviderGlobalScope(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.RTCIdentityProviderRegistrar RtcIdentityProvider
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.RTCIdentityProviderRegistrar, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "rtcIdentityProvider");
    }
}

#nullable disable