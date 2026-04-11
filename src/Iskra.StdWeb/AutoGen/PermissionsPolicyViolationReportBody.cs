// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class PermissionsPolicyViolationReportBody: global::Iskra.StdWeb.ReportBody
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public PermissionsPolicyViolationReportBody(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public PermissionsPolicyViolationReportBody(): base()
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string FeatureId
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "featureId");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "featureId", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? SourceFile
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "sourceFile");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "sourceFile", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public int? LineNumber
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<int?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "lineNumber");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<int?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "lineNumber", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public int? ColumnNumber
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<int?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "columnNumber");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<int?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "columnNumber", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string Disposition
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "disposition");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "disposition", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? AllowAttribute
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "allowAttribute");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "allowAttribute", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? SrcAttribute
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "srcAttribute");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "srcAttribute", value);
    }
}

#nullable disable