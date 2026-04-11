// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class XRView: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public XRView(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool IsFirstPersonObserver
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "isFirstPersonObserver");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.XRCamera? Camera
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.XRCamera?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "camera");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.XREye Eye
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.XREye, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "eye");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public uint Index
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<uint, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "index");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double? RecommendedViewportScale
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "recommendedViewportScale");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public void RequestViewportScale(double? scale)
    {
        int ___argsArrayLength_2 = 1;

        using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_2);

        // Argument 1
        double? ___marshalledValue_3;
        if (scale is null)
        {
            ___marshalledValue_3 = null;
        }
        else
        {
            double ___notNullable_4 = (double)scale;
            ___marshalledValue_3 = ___notNullable_4;
        }
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsDoubleV2AsNullable(___argsArray_0.JSObject, 0, ___marshalledValue_3);

        global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallNonEmptyVoidFunctionProperty(JSObject, "requestViewportScale", JSObject, ___argsArray_0.JSObject);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Float32Array ProjectionMatrix
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Float32Array, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "projectionMatrix");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.XRRigidTransform Transform
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.XRRigidTransform, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "transform");
    }
}

#nullable disable