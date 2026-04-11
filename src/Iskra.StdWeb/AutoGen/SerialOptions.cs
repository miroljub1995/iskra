// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class SerialOptions: global::Iskra.JSCore.JSObjectProxy
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public SerialOptions(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public SerialOptions(): base(global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "Object"))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public required uint BaudRate
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<uint, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "baudRate");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<uint, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "baudRate", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public byte DataBits
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<byte, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "dataBits");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<byte, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "dataBits", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public byte StopBits
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<byte, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "stopBits");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<byte, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "stopBits", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.ParityType Parity
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.ParityType, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "parity");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.ParityType, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "parity", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public uint BufferSize
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<uint, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "bufferSize");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<uint, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "bufferSize", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.FlowControlType FlowControl
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.FlowControlType, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "flowControl");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.FlowControlType, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "flowControl", value);
    }
}

#nullable disable