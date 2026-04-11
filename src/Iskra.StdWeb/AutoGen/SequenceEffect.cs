// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class SequenceEffect: global::Iskra.StdWeb.GroupEffect
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public SequenceEffect(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatformAttribute("browser")]
    public static global::Iskra.StdWeb.SequenceEffect New(global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.AnimationEffect, global::Iskra.StdWeb.PropertyAccessor>? children)
    {
        int ___argsArrayLength_3 = 1;

        using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_3);

        // Argument 1
        global::System.Runtime.InteropServices.JavaScript.JSObject? ___propObject_4;
        if (children is null)
        {
            ___propObject_4 = null;
        }
        else
        {
            ___propObject_4 = children.JSObject;
        }

        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2AsNullable(___argsArray_0.JSObject, 0, ___propObject_4);

        global::System.Runtime.InteropServices.JavaScript.JSObject ___res_2 = global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectNonEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "SequenceEffect", ___argsArray_0.JSObject);
        return new global::Iskra.StdWeb.SequenceEffect(___res_2);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatformAttribute("browser")]
    public static global::Iskra.StdWeb.SequenceEffect New(global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.AnimationEffect, global::Iskra.StdWeb.PropertyAccessor>? children, global::Iskra.JSCore.Generics.Union<double, global::Iskra.StdWeb.EffectTiming, global::Iskra.StdWeb.GenericMarshaller.Union> timing)
    {
        int ___argsArrayLength_3 = 2;

        using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_3);

        // Argument 1
        global::System.Runtime.InteropServices.JavaScript.JSObject? ___propObject_4;
        if (children is null)
        {
            ___propObject_4 = null;
        }
        else
        {
            ___propObject_4 = children.JSObject;
        }

        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2AsNullable(___argsArray_0.JSObject, 0, ___propObject_4);

        // Argument 2
        global::System.Runtime.InteropServices.JavaScript.JSObject ___propObject_5 = timing.JSObject;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsUnion(___argsArray_0.JSObject, 1, ___propObject_5);

        global::System.Runtime.InteropServices.JavaScript.JSObject ___res_2 = global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectNonEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "SequenceEffect", ___argsArray_0.JSObject);
        return new global::Iskra.StdWeb.SequenceEffect(___res_2);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SequenceEffect Clone()
    {
        using global::Iskra.JSCore.FunctionResPool.Owner ___resOwner_1 = global::Iskra.JSCore.FunctionResPool.Shared.Rent();

        global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallEmptyNonVoidFunctionProperty(JSObject, "clone", JSObject, ___resOwner_1.JSObject);

        // Return Value
        return global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SequenceEffect, global::Iskra.StdWeb.PropertyAccessor>(___resOwner_1.JSObject, "value");
    }
}

#nullable disable