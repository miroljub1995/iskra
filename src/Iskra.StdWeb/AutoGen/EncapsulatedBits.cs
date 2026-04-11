// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class EncapsulatedBits: global::Iskra.JSCore.JSObjectProxy
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public EncapsulatedBits(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public EncapsulatedBits(): base(global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "Object"))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.ArrayBuffer SharedKey
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.ArrayBuffer, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "sharedKey");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.JSCore.ArrayBuffer, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "sharedKey", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.ArrayBuffer Ciphertext
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.ArrayBuffer, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "ciphertext");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.JSCore.ArrayBuffer, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "ciphertext", value);
    }
}

#nullable disable