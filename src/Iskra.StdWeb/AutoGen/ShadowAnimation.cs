// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class ShadowAnimation: global::Iskra.StdWeb.Animation
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ShadowAnimation(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatformAttribute("browser")]
    public static global::Iskra.StdWeb.ShadowAnimation New(global::Iskra.StdWeb.Animation source, global::Iskra.JSCore.Generics.Union<global::Iskra.StdWeb.Element, global::Iskra.StdWeb.CSSPseudoElement, global::Iskra.StdWeb.GenericMarshaller.Union> newTarget)
    {
        int ___argsArrayLength_3 = 2;

        using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_3);

        // Argument 1
        global::System.Runtime.InteropServices.JavaScript.JSObject ___marshalledValue_4;
        ___marshalledValue_4 = source.JSObject;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2(___argsArray_0.JSObject, 0, ___marshalledValue_4);

        // Argument 2
        global::System.Runtime.InteropServices.JavaScript.JSObject ___propObject_5 = newTarget.JSObject;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsUnion(___argsArray_0.JSObject, 1, ___propObject_5);

        global::System.Runtime.InteropServices.JavaScript.JSObject ___res_2 = global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectNonEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "ShadowAnimation", ___argsArray_0.JSObject);
        return new global::Iskra.StdWeb.ShadowAnimation(___res_2);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.Animation SourceAnimation
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.Animation, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "sourceAnimation");
    }
}

#nullable disable