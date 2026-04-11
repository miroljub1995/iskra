// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class PerformanceResourceTiming: global::Iskra.StdWeb.PerformanceEntry
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public PerformanceResourceTiming(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.FrozenArray<global::Iskra.StdWeb.PerformanceServerTiming, global::Iskra.StdWeb.PropertyAccessor> ServerTiming
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.FrozenArray<global::Iskra.StdWeb.PerformanceServerTiming, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "serverTiming");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string InitiatorType
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "initiatorType");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string DeliveryType
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "deliveryType");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string NextHopProtocol
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "nextHopProtocol");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double WorkerStart
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "workerStart");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double RedirectStart
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "redirectStart");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double RedirectEnd
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "redirectEnd");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double FetchStart
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "fetchStart");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double DomainLookupStart
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "domainLookupStart");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double DomainLookupEnd
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "domainLookupEnd");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double ConnectStart
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "connectStart");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double ConnectEnd
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "connectEnd");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double SecureConnectionStart
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "secureConnectionStart");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double RequestStart
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "requestStart");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double FinalResponseHeadersStart
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "finalResponseHeadersStart");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double FirstInterimResponseStart
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "firstInterimResponseStart");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double ResponseStart
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "responseStart");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double ResponseEnd
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "responseEnd");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double WorkerRouterEvaluationStart
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "workerRouterEvaluationStart");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double WorkerCacheLookupStart
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "workerCacheLookupStart");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string WorkerMatchedRouterSource
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "workerMatchedRouterSource");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string WorkerFinalRouterSource
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "workerFinalRouterSource");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ulong TransferSize
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<ulong, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "transferSize");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ulong EncodedBodySize
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<ulong, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "encodedBodySize");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ulong DecodedBodySize
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<ulong, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "decodedBodySize");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ushort ResponseStatus
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<ushort, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "responseStatus");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.RenderBlockingStatusType RenderBlockingStatus
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.RenderBlockingStatusType, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "renderBlockingStatus");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string ContentType
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "contentType");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string ContentEncoding
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "contentEncoding");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::System.Runtime.InteropServices.JavaScript.JSObject ToJSON()
    {
        using global::Iskra.JSCore.FunctionResPool.Owner ___resOwner_1 = global::Iskra.JSCore.FunctionResPool.Shared.Rent();

        global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallEmptyNonVoidFunctionProperty(JSObject, "toJSON", JSObject, ___resOwner_1.JSObject);

        // Return Value
        return global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::System.Runtime.InteropServices.JavaScript.JSObject, global::Iskra.StdWeb.PropertyAccessor>(___resOwner_1.JSObject, "value");
    }
}

#nullable disable