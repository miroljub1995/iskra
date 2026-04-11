// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class WorkletAnimation: global::Iskra.StdWeb.Animation
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public WorkletAnimation(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatformAttribute("browser")]
    public static global::Iskra.StdWeb.WorkletAnimation New(string animatorName)
    {
        int ___argsArrayLength_3 = 1;

        using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_3);

        // Argument 1
        string ___marshalledValue_4;
        ___marshalledValue_4 = animatorName;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsStringV2(___argsArray_0.JSObject, 0, ___marshalledValue_4);

        global::System.Runtime.InteropServices.JavaScript.JSObject ___res_2 = global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectNonEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "WorkletAnimation", ___argsArray_0.JSObject);
        return new global::Iskra.StdWeb.WorkletAnimation(___res_2);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatformAttribute("browser")]
    public static global::Iskra.StdWeb.WorkletAnimation New(string animatorName, global::Iskra.JSCore.Generics.Union<global::Iskra.StdWeb.AnimationEffect, global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.AnimationEffect, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.GenericMarshaller.Union>? effects)
    {
        int ___argsArrayLength_3 = 2;

        using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_3);

        // Argument 1
        string ___marshalledValue_4;
        ___marshalledValue_4 = animatorName;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsStringV2(___argsArray_0.JSObject, 0, ___marshalledValue_4);

        // Argument 2
        global::System.Runtime.InteropServices.JavaScript.JSObject? ___propObject_5;
        if (effects is null)
        {
            ___propObject_5 = null;
        }
        else
        {
            ___propObject_5 = effects.JSObject;
        }

        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsUnionAsNullable(___argsArray_0.JSObject, 1, ___propObject_5);

        global::System.Runtime.InteropServices.JavaScript.JSObject ___res_2 = global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectNonEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "WorkletAnimation", ___argsArray_0.JSObject);
        return new global::Iskra.StdWeb.WorkletAnimation(___res_2);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatformAttribute("browser")]
    public static global::Iskra.StdWeb.WorkletAnimation New(string animatorName, global::Iskra.JSCore.Generics.Union<global::Iskra.StdWeb.AnimationEffect, global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.AnimationEffect, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.GenericMarshaller.Union>? effects, global::Iskra.StdWeb.AnimationTimeline? timeline)
    {
        int ___argsArrayLength_3 = 3;

        using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_3);

        // Argument 1
        string ___marshalledValue_4;
        ___marshalledValue_4 = animatorName;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsStringV2(___argsArray_0.JSObject, 0, ___marshalledValue_4);

        // Argument 2
        global::System.Runtime.InteropServices.JavaScript.JSObject? ___propObject_5;
        if (effects is null)
        {
            ___propObject_5 = null;
        }
        else
        {
            ___propObject_5 = effects.JSObject;
        }

        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsUnionAsNullable(___argsArray_0.JSObject, 1, ___propObject_5);

        // Argument 3
        global::System.Runtime.InteropServices.JavaScript.JSObject? ___marshalledValue_6;
        if (timeline is null)
        {
            ___marshalledValue_6 = null;
        }
        else
        {
            global::Iskra.StdWeb.AnimationTimeline ___notNullable_7 = (global::Iskra.StdWeb.AnimationTimeline)timeline;
            ___marshalledValue_6 = ___notNullable_7.JSObject;
        }
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2AsNullable(___argsArray_0.JSObject, 2, ___marshalledValue_6);

        global::System.Runtime.InteropServices.JavaScript.JSObject ___res_2 = global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectNonEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "WorkletAnimation", ___argsArray_0.JSObject);
        return new global::Iskra.StdWeb.WorkletAnimation(___res_2);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatformAttribute("browser")]
    public static global::Iskra.StdWeb.WorkletAnimation New(string animatorName, global::Iskra.JSCore.Generics.Union<global::Iskra.StdWeb.AnimationEffect, global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.AnimationEffect, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.GenericMarshaller.Union>? effects, global::Iskra.StdWeb.AnimationTimeline? timeline, global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>? options)
    {
        int ___argsArrayLength_3 = 4;

        using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_3);

        // Argument 1
        string ___marshalledValue_4;
        ___marshalledValue_4 = animatorName;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsStringV2(___argsArray_0.JSObject, 0, ___marshalledValue_4);

        // Argument 2
        global::System.Runtime.InteropServices.JavaScript.JSObject? ___propObject_5;
        if (effects is null)
        {
            ___propObject_5 = null;
        }
        else
        {
            ___propObject_5 = effects.JSObject;
        }

        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsUnionAsNullable(___argsArray_0.JSObject, 1, ___propObject_5);

        // Argument 3
        global::System.Runtime.InteropServices.JavaScript.JSObject? ___marshalledValue_6;
        if (timeline is null)
        {
            ___marshalledValue_6 = null;
        }
        else
        {
            global::Iskra.StdWeb.AnimationTimeline ___notNullable_7 = (global::Iskra.StdWeb.AnimationTimeline)timeline;
            ___marshalledValue_6 = ___notNullable_7.JSObject;
        }
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2AsNullable(___argsArray_0.JSObject, 2, ___marshalledValue_6);

        // Argument 4
        global::System.Runtime.InteropServices.JavaScript.JSObject? ___propObject_8;
        if (options is null)
        {
            ___propObject_8 = null;
        }
        else
        {
            ___propObject_8 = options.JSObject;
        }

        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsUnionAsNullable(___argsArray_0.JSObject, 3, ___propObject_8);

        global::System.Runtime.InteropServices.JavaScript.JSObject ___res_2 = global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectNonEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "WorkletAnimation", ___argsArray_0.JSObject);
        return new global::Iskra.StdWeb.WorkletAnimation(___res_2);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string AnimatorName
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "animatorName");
    }
}

#nullable disable