// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class ProofreaderCreateCoreOptions: global::Iskra.JSCore.JSObjectProxy
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ProofreaderCreateCoreOptions(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ProofreaderCreateCoreOptions(): base(global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "Object"))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool IncludeCorrectionTypes
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "includeCorrectionTypes");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "includeCorrectionTypes", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool IncludeCorrectionExplanations
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "includeCorrectionExplanations");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "includeCorrectionExplanations", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.JSArray<string, global::Iskra.StdWeb.PropertyAccessor> ExpectedInputLanguages
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.JSArray<string, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "expectedInputLanguages");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.JSCore.Generics.JSArray<string, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "expectedInputLanguages", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string CorrectionExplanationLanguage
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "correctionExplanationLanguage");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "correctionExplanationLanguage", value);
    }
}

#nullable disable