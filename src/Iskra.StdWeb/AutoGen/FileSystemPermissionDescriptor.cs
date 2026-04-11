// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class FileSystemPermissionDescriptor: global::Iskra.StdWeb.PermissionDescriptor
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public FileSystemPermissionDescriptor(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public FileSystemPermissionDescriptor(): base()
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public required global::Iskra.StdWeb.FileSystemHandle Handle
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.FileSystemHandle, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "handle");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.FileSystemHandle, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "handle", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.FileSystemPermissionMode Mode
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.FileSystemPermissionMode, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "mode");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.FileSystemPermissionMode, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "mode", value);
    }
}

#nullable disable