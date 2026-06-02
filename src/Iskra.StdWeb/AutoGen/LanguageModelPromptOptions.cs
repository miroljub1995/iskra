// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class LanguageModelPromptOptions: global::Iskra.JSCore.JSObjectProxy
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public LanguageModelPromptOptions(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public LanguageModelPromptOptions(): base(global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "Object"))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::System.Runtime.InteropServices.JavaScript.JSObject ResponseConstraint
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::System.Runtime.InteropServices.JavaScript.JSObject, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "responseConstraint");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::System.Runtime.InteropServices.JavaScript.JSObject, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "responseConstraint", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool OmitResponseConstraintInput
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "omitResponseConstraintInput");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "omitResponseConstraintInput", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.AbortSignal Signal
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.AbortSignal, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "signal");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.AbortSignal, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "signal", value);
    }
}

#nullable disable