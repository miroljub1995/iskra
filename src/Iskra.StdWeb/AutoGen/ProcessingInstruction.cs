// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class ProcessingInstruction: global::Iskra.StdWeb.CharacterData
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ProcessingInstruction(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string Target
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "target");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.CSSStyleSheet? Sheet
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.CSSStyleSheet?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "sheet");
    }
}

#nullable disable