// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class Highlight: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public Highlight(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatformAttribute("browser")]
    public static global::Iskra.StdWeb.Highlight New(params global::Iskra.StdWeb.AbstractRange[] initialRanges)
    {
        int ___argsArrayLength_3 = initialRanges.Length + 0;

        using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_3);

        // Argument 1
        for (int ___i_4 = 0; ___i_4 < initialRanges.Length; ___i_4++)
        {
        global::Iskra.StdWeb.AbstractRange ___elem_5 = initialRanges[___i_4];
            global::System.Runtime.InteropServices.JavaScript.JSObject ___marshalledValue_6;
            ___marshalledValue_6 = ___elem_5.JSObject;
            global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2(___argsArray_0.JSObject, 0 + ___i_4, ___marshalledValue_6);
        }

        global::System.Runtime.InteropServices.JavaScript.JSObject ___res_2 = global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectNonEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "Highlight", ___argsArray_0.JSObject);
        return new global::Iskra.StdWeb.Highlight(___res_2);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public int Priority
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<int, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "priority");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<int, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "priority", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.HighlightType Type
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.HighlightType, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "type");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.HighlightType, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "type", value);
    }
}

#nullable disable