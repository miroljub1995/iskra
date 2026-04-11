// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class GPUOutOfMemoryError: global::Iskra.StdWeb.GPUError
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public GPUOutOfMemoryError(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatformAttribute("browser")]
    public static global::Iskra.StdWeb.GPUOutOfMemoryError New(string message)
    {
        int ___argsArrayLength_3 = 1;

        using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_3);

        // Argument 1
        string ___marshalledValue_4;
        ___marshalledValue_4 = message;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsStringV2(___argsArray_0.JSObject, 0, ___marshalledValue_4);

        global::System.Runtime.InteropServices.JavaScript.JSObject ___res_2 = global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectNonEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "GPUOutOfMemoryError", ___argsArray_0.JSObject);
        return new global::Iskra.StdWeb.GPUOutOfMemoryError(___res_2);
    }
}

#nullable disable