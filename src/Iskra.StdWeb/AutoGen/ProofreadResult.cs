// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class ProofreadResult: global::Iskra.JSCore.JSObjectProxy
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ProofreadResult(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ProofreadResult(): base(global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "Object"))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string CorrectedInput
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "correctedInput");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "correctedInput", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.ProofreadCorrection, global::Iskra.StdWeb.PropertyAccessor> Corrections
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.ProofreadCorrection, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "corrections");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.ProofreadCorrection, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "corrections", value);
    }
}

#nullable disable