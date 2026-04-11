// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class FontFaceVariationAxis: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public FontFaceVariationAxis(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string Name
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "name");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string AxisTag
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "axisTag");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double MinimumValue
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "minimumValue");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double MaximumValue
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "maximumValue");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double DefaultValue
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "defaultValue");
    }
}

#nullable disable