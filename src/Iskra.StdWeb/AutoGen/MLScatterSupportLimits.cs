// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class MLScatterSupportLimits: global::Iskra.JSCore.JSObjectProxy
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public MLScatterSupportLimits(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public MLScatterSupportLimits(): base(global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "Object"))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.MLTensorLimits Input
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.MLTensorLimits, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "input");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.MLTensorLimits, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "input", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.MLTensorLimits Indices
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.MLTensorLimits, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "indices");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.MLTensorLimits, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "indices", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.MLTensorLimits Updates
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.MLTensorLimits, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "updates");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.MLTensorLimits, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "updates", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.MLTensorLimits Output
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.MLTensorLimits, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "output");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.MLTensorLimits, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "output", value);
    }
}

#nullable disable