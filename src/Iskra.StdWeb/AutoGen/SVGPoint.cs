// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class SVGPoint: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public SVGPoint(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public float X
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<float, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "x");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<float, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "x", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public float Y
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<float, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "y");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<float, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "y", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SVGPoint MatrixTransform(global::Iskra.StdWeb.SVGMatrix matrix)
    {
        int ___argsArrayLength_2 = 1;

        using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_2);

        // Argument 1
        global::System.Runtime.InteropServices.JavaScript.JSObject ___marshalledValue_3;
        ___marshalledValue_3 = matrix.JSObject;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2(___argsArray_0.JSObject, 0, ___marshalledValue_3);

        using global::Iskra.JSCore.FunctionResPool.Owner ___resOwner_1 = global::Iskra.JSCore.FunctionResPool.Shared.Rent();

        global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallNonEmptyNonVoidFunctionProperty(JSObject, "matrixTransform", JSObject, ___argsArray_0.JSObject, ___resOwner_1.JSObject);

        // Return Value
        return global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SVGPoint, global::Iskra.StdWeb.PropertyAccessor>(___resOwner_1.JSObject, "value");
    }
}

#nullable disable