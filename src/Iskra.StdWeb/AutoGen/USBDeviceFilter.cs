// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class USBDeviceFilter: global::Iskra.JSCore.JSObjectProxy
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public USBDeviceFilter(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public USBDeviceFilter(): base(global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "Object"))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ushort VendorId
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<ushort, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "vendorId");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<ushort, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "vendorId", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ushort ProductId
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<ushort, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "productId");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<ushort, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "productId", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public byte ClassCode
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<byte, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "classCode");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<byte, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "classCode", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public byte SubclassCode
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<byte, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "subclassCode");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<byte, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "subclassCode", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public byte ProtocolCode
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<byte, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "protocolCode");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<byte, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "protocolCode", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string SerialNumber
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "serialNumber");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "serialNumber", value);
    }
}

#nullable disable