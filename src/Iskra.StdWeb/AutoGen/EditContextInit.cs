// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class EditContextInit: global::Iskra.JSCore.JSObjectProxy
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public EditContextInit(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public EditContextInit(): base(global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "Object"))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string Text
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "text");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "text", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public uint SelectionStart
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<uint, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "selectionStart");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<uint, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "selectionStart", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public uint SelectionEnd
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<uint, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "selectionEnd");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<uint, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "selectionEnd", value);
    }
}

#nullable disable