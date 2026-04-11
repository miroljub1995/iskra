// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class VideoColorSpaceInit: global::Iskra.JSCore.JSObjectProxy
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public VideoColorSpaceInit(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public VideoColorSpaceInit(): base(global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "Object"))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.VideoColorPrimaries? Primaries
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.VideoColorPrimaries?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "primaries");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.VideoColorPrimaries?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "primaries", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.VideoTransferCharacteristics? Transfer
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.VideoTransferCharacteristics?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "transfer");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.VideoTransferCharacteristics?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "transfer", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.VideoMatrixCoefficients? Matrix
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.VideoMatrixCoefficients?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "matrix");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.VideoMatrixCoefficients?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "matrix", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool? FullRange
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "fullRange");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<bool?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "fullRange", value);
    }
}

#nullable disable