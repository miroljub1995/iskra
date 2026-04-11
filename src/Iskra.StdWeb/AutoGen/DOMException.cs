// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class DOMException: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public DOMException(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatformAttribute("browser")]
    public static global::Iskra.StdWeb.DOMException New()
    {
        global::System.Runtime.InteropServices.JavaScript.JSObject ___res_2 = global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "DOMException");
        return new global::Iskra.StdWeb.DOMException(___res_2);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatformAttribute("browser")]
    public static global::Iskra.StdWeb.DOMException New(string message)
    {
        int ___argsArrayLength_3 = 1;

        using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_3);

        // Argument 1
        string ___marshalledValue_4;
        ___marshalledValue_4 = message;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsStringV2(___argsArray_0.JSObject, 0, ___marshalledValue_4);

        global::System.Runtime.InteropServices.JavaScript.JSObject ___res_2 = global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectNonEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "DOMException", ___argsArray_0.JSObject);
        return new global::Iskra.StdWeb.DOMException(___res_2);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatformAttribute("browser")]
    public static global::Iskra.StdWeb.DOMException New(string message, string name)
    {
        int ___argsArrayLength_3 = 2;

        using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_3);

        // Argument 1
        string ___marshalledValue_4;
        ___marshalledValue_4 = message;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsStringV2(___argsArray_0.JSObject, 0, ___marshalledValue_4);

        // Argument 2
        string ___marshalledValue_5;
        ___marshalledValue_5 = name;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsStringV2(___argsArray_0.JSObject, 1, ___marshalledValue_5);

        global::System.Runtime.InteropServices.JavaScript.JSObject ___res_2 = global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectNonEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "DOMException", ___argsArray_0.JSObject);
        return new global::Iskra.StdWeb.DOMException(___res_2);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string Name
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "name");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string Message
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "message");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ushort Code
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<ushort, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "code");
    }

    public const ushort INDEX_SIZE_ERR = 1;

    public const ushort DOMSTRING_SIZE_ERR = 2;

    public const ushort HIERARCHY_REQUEST_ERR = 3;

    public const ushort WRONG_DOCUMENT_ERR = 4;

    public const ushort INVALID_CHARACTER_ERR = 5;

    public const ushort NO_DATA_ALLOWED_ERR = 6;

    public const ushort NO_MODIFICATION_ALLOWED_ERR = 7;

    public const ushort NOT_FOUND_ERR = 8;

    public const ushort NOT_SUPPORTED_ERR = 9;

    public const ushort INUSE_ATTRIBUTE_ERR = 10;

    public const ushort INVALID_STATE_ERR = 11;

    public const ushort SYNTAX_ERR = 12;

    public const ushort INVALID_MODIFICATION_ERR = 13;

    public const ushort NAMESPACE_ERR = 14;

    public const ushort INVALID_ACCESS_ERR = 15;

    public const ushort VALIDATION_ERR = 16;

    public const ushort TYPE_MISMATCH_ERR = 17;

    public const ushort SECURITY_ERR = 18;

    public const ushort NETWORK_ERR = 19;

    public const ushort ABORT_ERR = 20;

    public const ushort URL_MISMATCH_ERR = 21;

    public const ushort QUOTA_EXCEEDED_ERR = 22;

    public const ushort TIMEOUT_ERR = 23;

    public const ushort INVALID_NODE_TYPE_ERR = 24;

    public const ushort DATA_CLONE_ERR = 25;
}

#nullable disable