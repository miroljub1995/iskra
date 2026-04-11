// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class InterventionReportBody: global::Iskra.StdWeb.ReportBody
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public InterventionReportBody(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public InterventionReportBody(): base()
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string Id
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "id");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "id", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string Message
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "message");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "message", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? SourceFile
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "sourceFile");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "sourceFile", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public uint? LineNumber
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<uint?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "lineNumber");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<uint?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "lineNumber", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public uint? ColumnNumber
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<uint?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "columnNumber");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<uint?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "columnNumber", value);
    }
}

#nullable disable