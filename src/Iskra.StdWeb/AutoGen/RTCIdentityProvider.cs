// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class RTCIdentityProvider: global::Iskra.JSCore.JSObjectProxy
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public RTCIdentityProvider(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public RTCIdentityProvider(): base(global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "Object"))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public required global::Iskra.StdWeb.GenerateAssertionCallback GenerateAssertion
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.GenerateAssertionCallback, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "generateAssertion");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.GenerateAssertionCallback, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "generateAssertion", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public required global::Iskra.StdWeb.ValidateAssertionCallback ValidateAssertion
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.ValidateAssertionCallback, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "validateAssertion");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.ValidateAssertionCallback, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "validateAssertion", value);
    }
}

#nullable disable