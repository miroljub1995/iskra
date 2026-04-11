// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class CSSFontFeatureValuesRule: global::Iskra.StdWeb.CSSRule
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public CSSFontFeatureValuesRule(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string FontFamily
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "fontFamily");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "fontFamily", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.CSSFontFeatureValuesMap Annotation
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.CSSFontFeatureValuesMap, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "annotation");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.CSSFontFeatureValuesMap Ornaments
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.CSSFontFeatureValuesMap, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "ornaments");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.CSSFontFeatureValuesMap Stylistic
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.CSSFontFeatureValuesMap, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "stylistic");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.CSSFontFeatureValuesMap Swash
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.CSSFontFeatureValuesMap, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "swash");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.CSSFontFeatureValuesMap CharacterVariant
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.CSSFontFeatureValuesMap, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "characterVariant");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.CSSFontFeatureValuesMap Styleset
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.CSSFontFeatureValuesMap, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "styleset");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.CSSFontFeatureValuesMap HistoricalForms
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.CSSFontFeatureValuesMap, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "historicalForms");
    }
}

#nullable disable