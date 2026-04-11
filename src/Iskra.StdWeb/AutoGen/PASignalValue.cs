// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class PASignalValue: global::Iskra.JSCore.JSObjectProxy
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public PASignalValue(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public PASignalValue(): base(global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "Object"))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public required string BaseValue
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "baseValue");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "baseValue", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double Scale
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "scale");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "scale", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.Union<global::System.Numerics.BigInteger, int, global::Iskra.StdWeb.GenericMarshaller.Union> Offset
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.Union<global::System.Numerics.BigInteger, int, global::Iskra.StdWeb.GenericMarshaller.Union>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "offset");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.JSCore.Generics.Union<global::System.Numerics.BigInteger, int, global::Iskra.StdWeb.GenericMarshaller.Union>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "offset", value);
    }
}

#nullable disable