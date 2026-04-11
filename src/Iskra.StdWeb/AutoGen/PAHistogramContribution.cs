// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class PAHistogramContribution: global::Iskra.JSCore.JSObjectProxy
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public PAHistogramContribution(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public PAHistogramContribution(): base(global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "Object"))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public required global::System.Numerics.BigInteger Bucket
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::System.Numerics.BigInteger, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "bucket");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::System.Numerics.BigInteger, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "bucket", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public required int Value
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<int, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "value");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<int, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "value", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::System.Numerics.BigInteger FilteringId
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::System.Numerics.BigInteger, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "filteringId");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::System.Numerics.BigInteger, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "filteringId", value);
    }
}

#nullable disable