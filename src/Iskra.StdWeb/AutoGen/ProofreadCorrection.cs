// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class ProofreadCorrection: global::Iskra.JSCore.JSObjectProxy
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ProofreadCorrection(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ProofreadCorrection(): base(global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "Object"))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ulong StartIndex
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<ulong, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "startIndex");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<ulong, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "startIndex", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ulong EndIndex
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<ulong, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "endIndex");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<ulong, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "endIndex", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string Correction
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "correction");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "correction", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.CorrectionType, global::Iskra.StdWeb.PropertyAccessor> Types
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.CorrectionType, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "types");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.CorrectionType, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "types", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string Explanation
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "explanation");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "explanation", value);
    }
}

#nullable disable