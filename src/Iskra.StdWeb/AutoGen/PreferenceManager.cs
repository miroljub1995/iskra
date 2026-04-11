// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class PreferenceManager: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public PreferenceManager(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.PreferenceObject ColorScheme
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.PreferenceObject, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "colorScheme");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.PreferenceObject Contrast
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.PreferenceObject, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "contrast");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.PreferenceObject ReducedMotion
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.PreferenceObject, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "reducedMotion");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.PreferenceObject ReducedTransparency
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.PreferenceObject, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "reducedTransparency");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.PreferenceObject ReducedData
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.PreferenceObject, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "reducedData");
    }
}

#nullable disable