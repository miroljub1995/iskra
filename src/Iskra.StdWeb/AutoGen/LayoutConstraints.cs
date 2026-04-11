// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class LayoutConstraints: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public LayoutConstraints(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double AvailableInlineSize
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "availableInlineSize");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double AvailableBlockSize
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "availableBlockSize");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double? FixedInlineSize
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "fixedInlineSize");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double? FixedBlockSize
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "fixedBlockSize");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double PercentageInlineSize
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "percentageInlineSize");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double PercentageBlockSize
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "percentageBlockSize");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double? BlockFragmentationOffset
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "blockFragmentationOffset");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.BlockFragmentationType BlockFragmentationType
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.BlockFragmentationType, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "blockFragmentationType");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>? Data
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "data");
    }
}

#nullable disable