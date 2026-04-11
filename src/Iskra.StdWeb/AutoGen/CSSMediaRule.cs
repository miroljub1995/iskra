// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class CSSMediaRule: global::Iskra.StdWeb.CSSConditionRule
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public CSSMediaRule(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.MediaList Media
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.MediaList, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "media");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool Matches
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "matches");
    }
}

#nullable disable