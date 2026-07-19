// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class CrossOriginStorageRequestFileHandleOptions: global::Iskra.JSCore.JSObjectProxy
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public CrossOriginStorageRequestFileHandleOptions(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public CrossOriginStorageRequestFileHandleOptions(): base(global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "Object"))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool Create
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "create");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "create", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.Union<string, global::Iskra.JSCore.Generics.JSArray<string, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.GenericMarshaller.Union> Origins
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.Union<string, global::Iskra.JSCore.Generics.JSArray<string, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.GenericMarshaller.Union>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "origins");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.JSCore.Generics.Union<string, global::Iskra.JSCore.Generics.JSArray<string, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.GenericMarshaller.Union>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "origins", value);
    }
}

#nullable disable