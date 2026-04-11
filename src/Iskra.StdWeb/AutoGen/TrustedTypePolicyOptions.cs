// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class TrustedTypePolicyOptions: global::Iskra.JSCore.JSObjectProxy
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public TrustedTypePolicyOptions(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public TrustedTypePolicyOptions(): base(global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "Object"))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.CreateHTMLCallback CreateHTML
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.CreateHTMLCallback, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "createHTML");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.CreateHTMLCallback, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "createHTML", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.CreateScriptCallback CreateScript
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.CreateScriptCallback, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "createScript");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.CreateScriptCallback, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "createScript", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.CreateScriptURLCallback CreateScriptURL
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.CreateScriptURLCallback, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "createScriptURL");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.CreateScriptURLCallback, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "createScriptURL", value);
    }
}

#nullable disable