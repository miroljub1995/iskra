// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class WebTransportSendStream: global::Iskra.StdWeb.WritableStream
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public WebTransportSendStream(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.WebTransportSendGroup? SendGroup
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.WebTransportSendGroup?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "sendGroup");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.WebTransportSendGroup?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "sendGroup", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public long SendOrder
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<long, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "sendOrder");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<long, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "sendOrder", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.Promise<global::Iskra.StdWeb.WebTransportSendStreamStats, global::Iskra.StdWeb.PropertyAccessor> GetStats()
    {
        using global::Iskra.JSCore.FunctionResPool.Owner ___resOwner_1 = global::Iskra.JSCore.FunctionResPool.Shared.Rent();

        global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallEmptyNonVoidFunctionProperty(JSObject, "getStats", JSObject, ___resOwner_1.JSObject);

        // Return Value
        return global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.Promise<global::Iskra.StdWeb.WebTransportSendStreamStats, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(___resOwner_1.JSObject, "value");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.WebTransportWriter GetWriter()
    {
        using global::Iskra.JSCore.FunctionResPool.Owner ___resOwner_1 = global::Iskra.JSCore.FunctionResPool.Shared.Rent();

        global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallEmptyNonVoidFunctionProperty(JSObject, "getWriter", JSObject, ___resOwner_1.JSObject);

        // Return Value
        return global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.WebTransportWriter, global::Iskra.StdWeb.PropertyAccessor>(___resOwner_1.JSObject, "value");
    }
}

#nullable disable