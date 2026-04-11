// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class AuthenticatorAssertionResponse: global::Iskra.StdWeb.AuthenticatorResponse
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public AuthenticatorAssertionResponse(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.ArrayBuffer AuthenticatorData
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.ArrayBuffer, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "authenticatorData");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.ArrayBuffer Signature
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.ArrayBuffer, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "signature");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.ArrayBuffer? UserHandle
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.ArrayBuffer?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "userHandle");
    }
}

#nullable disable