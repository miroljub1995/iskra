// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class CredentialCreationOptions: global::Iskra.JSCore.JSObjectProxy
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public CredentialCreationOptions(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public CredentialCreationOptions(): base(global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "Object"))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.CredentialMediationRequirement Mediation
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.CredentialMediationRequirement, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "mediation");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.CredentialMediationRequirement, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "mediation", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.AbortSignal Signal
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.AbortSignal, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "signal");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.AbortSignal, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "signal", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.Union<global::Iskra.StdWeb.PasswordCredentialData, global::Iskra.StdWeb.HTMLFormElement, global::Iskra.StdWeb.GenericMarshaller.Union> Password
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.Union<global::Iskra.StdWeb.PasswordCredentialData, global::Iskra.StdWeb.HTMLFormElement, global::Iskra.StdWeb.GenericMarshaller.Union>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "password");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.JSCore.Generics.Union<global::Iskra.StdWeb.PasswordCredentialData, global::Iskra.StdWeb.HTMLFormElement, global::Iskra.StdWeb.GenericMarshaller.Union>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "password", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.FederatedCredentialInit Federated
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.FederatedCredentialInit, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "federated");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.FederatedCredentialInit, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "federated", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.PublicKeyCredentialCreationOptions PublicKey
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.PublicKeyCredentialCreationOptions, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "publicKey");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.PublicKeyCredentialCreationOptions, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "publicKey", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.DigitalCredentialCreationOptions Digital
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.DigitalCredentialCreationOptions, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "digital");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.DigitalCredentialCreationOptions, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "digital", value);
    }
}

#nullable disable