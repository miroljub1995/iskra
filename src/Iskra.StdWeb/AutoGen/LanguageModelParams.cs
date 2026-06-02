// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class LanguageModelParams: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public LanguageModelParams(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public uint DefaultTopK
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<uint, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "defaultTopK");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public uint MaxTopK
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<uint, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "maxTopK");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public float DefaultTemperature
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<float, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "defaultTemperature");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public float MaxTemperature
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<float, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "maxTemperature");
    }
}

#nullable disable