// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class RTCIceCandidate: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public RTCIceCandidate(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatformAttribute("browser")]
    public static global::Iskra.StdWeb.RTCIceCandidate New()
    {
        global::System.Runtime.InteropServices.JavaScript.JSObject ___res_2 = global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "RTCIceCandidate");
        return new global::Iskra.StdWeb.RTCIceCandidate(___res_2);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatformAttribute("browser")]
    public static global::Iskra.StdWeb.RTCIceCandidate New(global::Iskra.StdWeb.RTCLocalIceCandidateInit candidateInitDict)
    {
        int ___argsArrayLength_3 = 1;

        using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_3);

        // Argument 1
        global::System.Runtime.InteropServices.JavaScript.JSObject ___marshalledValue_4;
        ___marshalledValue_4 = candidateInitDict.JSObject;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2(___argsArray_0.JSObject, 0, ___marshalledValue_4);

        global::System.Runtime.InteropServices.JavaScript.JSObject ___res_2 = global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectNonEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "RTCIceCandidate", ___argsArray_0.JSObject);
        return new global::Iskra.StdWeb.RTCIceCandidate(___res_2);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string Candidate
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "candidate");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? SdpMid
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "sdpMid");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ushort? SdpMLineIndex
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<ushort?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "sdpMLineIndex");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? Foundation
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "foundation");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.RTCIceComponent? Component
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.RTCIceComponent?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "component");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public uint? Priority
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<uint?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "priority");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? Address
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "address");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.RTCIceProtocol? Protocol
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.RTCIceProtocol?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "protocol");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ushort? Port
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<ushort?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "port");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.RTCIceCandidateType? Type
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.RTCIceCandidateType?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "type");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.RTCIceTcpCandidateType? TcpType
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.RTCIceTcpCandidateType?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "tcpType");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? RelatedAddress
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "relatedAddress");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ushort? RelatedPort
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<ushort?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "relatedPort");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? UsernameFragment
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "usernameFragment");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.RTCIceServerTransportProtocol? RelayProtocol
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.RTCIceServerTransportProtocol?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "relayProtocol");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? Url
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "url");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.RTCIceCandidateInit ToJSON()
    {
        using global::Iskra.JSCore.FunctionResPool.Owner ___resOwner_1 = global::Iskra.JSCore.FunctionResPool.Shared.Rent();

        global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallEmptyNonVoidFunctionProperty(JSObject, "toJSON", JSObject, ___resOwner_1.JSObject);

        // Return Value
        return global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.RTCIceCandidateInit, global::Iskra.StdWeb.PropertyAccessor>(___resOwner_1.JSObject, "value");
    }
}

#nullable disable