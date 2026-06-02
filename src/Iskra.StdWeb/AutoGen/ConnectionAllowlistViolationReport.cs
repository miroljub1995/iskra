// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class ConnectionAllowlistViolationReport: global::Iskra.StdWeb.ReportBody
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ConnectionAllowlistViolationReport(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ConnectionAllowlistViolationReport(): base()
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string Url
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "url");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "url", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string Connection
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "connection");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "connection", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.JSArray<string, global::Iskra.StdWeb.PropertyAccessor> Allowlist
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.JSArray<string, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "allowlist");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.JSCore.Generics.JSArray<string, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "allowlist", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.ConnectionAllowlistDisposition Disposition
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.ConnectionAllowlistDisposition, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "disposition");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.ConnectionAllowlistDisposition, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "disposition", value);
    }
}

#nullable disable