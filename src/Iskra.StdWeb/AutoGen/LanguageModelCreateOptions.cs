// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class LanguageModelCreateOptions: global::Iskra.StdWeb.LanguageModelCreateCoreOptions
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public LanguageModelCreateOptions(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public LanguageModelCreateOptions(): base()
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.AbortSignal Signal
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.AbortSignal, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "signal");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.AbortSignal, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "signal", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.CreateMonitorCallback Monitor
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.CreateMonitorCallback, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "monitor");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.CreateMonitorCallback, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "monitor", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.LanguageModelMessage, global::Iskra.StdWeb.PropertyAccessor> InitialPrompts
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.LanguageModelMessage, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "initialPrompts");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.LanguageModelMessage, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "initialPrompts", value);
    }
}

#nullable disable