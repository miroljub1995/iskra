// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class RTCError: global::Iskra.StdWeb.DOMException
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public RTCError(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatformAttribute("browser")]
    public static global::Iskra.StdWeb.RTCError New(global::Iskra.StdWeb.RTCErrorInit init)
    {
        int ___argsArrayLength_3 = 1;

        using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_3);

        // Argument 1
        global::System.Runtime.InteropServices.JavaScript.JSObject ___marshalledValue_4;
        ___marshalledValue_4 = init.JSObject;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2(___argsArray_0.JSObject, 0, ___marshalledValue_4);

        global::System.Runtime.InteropServices.JavaScript.JSObject ___res_2 = global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectNonEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "RTCError", ___argsArray_0.JSObject);
        return new global::Iskra.StdWeb.RTCError(___res_2);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatformAttribute("browser")]
    public static global::Iskra.StdWeb.RTCError New(global::Iskra.StdWeb.RTCErrorInit init, string message)
    {
        int ___argsArrayLength_3 = 2;

        using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_3);

        // Argument 1
        global::System.Runtime.InteropServices.JavaScript.JSObject ___marshalledValue_4;
        ___marshalledValue_4 = init.JSObject;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2(___argsArray_0.JSObject, 0, ___marshalledValue_4);

        // Argument 2
        string ___marshalledValue_5;
        ___marshalledValue_5 = message;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsStringV2(___argsArray_0.JSObject, 1, ___marshalledValue_5);

        global::System.Runtime.InteropServices.JavaScript.JSObject ___res_2 = global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectNonEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "RTCError", ___argsArray_0.JSObject);
        return new global::Iskra.StdWeb.RTCError(___res_2);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.RTCErrorDetailType ErrorDetail
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.RTCErrorDetailType, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "errorDetail");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public int? SdpLineNumber
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<int?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "sdpLineNumber");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public int? SctpCauseCode
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<int?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "sctpCauseCode");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public uint? ReceivedAlert
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<uint?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "receivedAlert");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public uint? SentAlert
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<uint?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "sentAlert");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public int? HttpRequestStatusCode
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<int?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "httpRequestStatusCode");
    }
}

#nullable disable