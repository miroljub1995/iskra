// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class GPUUncapturedErrorEvent: global::Iskra.StdWeb.Event
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public GPUUncapturedErrorEvent(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatformAttribute("browser")]
    public static global::Iskra.StdWeb.GPUUncapturedErrorEvent New(string type, global::Iskra.StdWeb.GPUUncapturedErrorEventInit gpuUncapturedErrorEventInitDict)
    {
        int ___argsArrayLength_3 = 2;

        using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_3);

        // Argument 1
        string ___marshalledValue_4;
        ___marshalledValue_4 = type;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsStringV2(___argsArray_0.JSObject, 0, ___marshalledValue_4);

        // Argument 2
        global::System.Runtime.InteropServices.JavaScript.JSObject ___marshalledValue_5;
        ___marshalledValue_5 = gpuUncapturedErrorEventInitDict.JSObject;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2(___argsArray_0.JSObject, 1, ___marshalledValue_5);

        global::System.Runtime.InteropServices.JavaScript.JSObject ___res_2 = global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectNonEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "GPUUncapturedErrorEvent", ___argsArray_0.JSObject);
        return new global::Iskra.StdWeb.GPUUncapturedErrorEvent(___res_2);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.GPUError Error
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.GPUError, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "error");
    }
}

#nullable disable