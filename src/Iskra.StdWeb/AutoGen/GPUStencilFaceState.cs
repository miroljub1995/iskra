// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class GPUStencilFaceState: global::Iskra.JSCore.JSObjectProxy
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public GPUStencilFaceState(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public GPUStencilFaceState(): base(global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "Object"))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.GPUCompareFunction Compare
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.GPUCompareFunction, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "compare");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.GPUCompareFunction, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "compare", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.GPUStencilOperation FailOp
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.GPUStencilOperation, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "failOp");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.GPUStencilOperation, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "failOp", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.GPUStencilOperation DepthFailOp
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.GPUStencilOperation, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "depthFailOp");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.GPUStencilOperation, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "depthFailOp", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.GPUStencilOperation PassOp
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.GPUStencilOperation, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "passOp");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.GPUStencilOperation, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "passOp", value);
    }
}

#nullable disable