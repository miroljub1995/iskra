// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class CSSLab: global::Iskra.StdWeb.CSSColorValue
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public CSSLab(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatformAttribute("browser")]
    public static global::Iskra.StdWeb.CSSLab New(global::Iskra.JSCore.Generics.Union<double, global::Iskra.StdWeb.CSSNumericValue, string, global::Iskra.StdWeb.CSSKeywordValue, global::Iskra.StdWeb.GenericMarshaller.Union> l, global::Iskra.JSCore.Generics.Union<double, global::Iskra.StdWeb.CSSNumericValue, string, global::Iskra.StdWeb.CSSKeywordValue, global::Iskra.StdWeb.GenericMarshaller.Union> a, global::Iskra.JSCore.Generics.Union<double, global::Iskra.StdWeb.CSSNumericValue, string, global::Iskra.StdWeb.CSSKeywordValue, global::Iskra.StdWeb.GenericMarshaller.Union> b)
    {
        int ___argsArrayLength_3 = 3;

        using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_3);

        // Argument 1
        global::System.Runtime.InteropServices.JavaScript.JSObject ___propObject_4 = l.JSObject;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsUnion(___argsArray_0.JSObject, 0, ___propObject_4);

        // Argument 2
        global::System.Runtime.InteropServices.JavaScript.JSObject ___propObject_5 = a.JSObject;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsUnion(___argsArray_0.JSObject, 1, ___propObject_5);

        // Argument 3
        global::System.Runtime.InteropServices.JavaScript.JSObject ___propObject_6 = b.JSObject;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsUnion(___argsArray_0.JSObject, 2, ___propObject_6);

        global::System.Runtime.InteropServices.JavaScript.JSObject ___res_2 = global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectNonEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "CSSLab", ___argsArray_0.JSObject);
        return new global::Iskra.StdWeb.CSSLab(___res_2);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatformAttribute("browser")]
    public static global::Iskra.StdWeb.CSSLab New(global::Iskra.JSCore.Generics.Union<double, global::Iskra.StdWeb.CSSNumericValue, string, global::Iskra.StdWeb.CSSKeywordValue, global::Iskra.StdWeb.GenericMarshaller.Union> l, global::Iskra.JSCore.Generics.Union<double, global::Iskra.StdWeb.CSSNumericValue, string, global::Iskra.StdWeb.CSSKeywordValue, global::Iskra.StdWeb.GenericMarshaller.Union> a, global::Iskra.JSCore.Generics.Union<double, global::Iskra.StdWeb.CSSNumericValue, string, global::Iskra.StdWeb.CSSKeywordValue, global::Iskra.StdWeb.GenericMarshaller.Union> b, global::Iskra.JSCore.Generics.Union<double, global::Iskra.StdWeb.CSSNumericValue, string, global::Iskra.StdWeb.CSSKeywordValue, global::Iskra.StdWeb.GenericMarshaller.Union> alpha)
    {
        int ___argsArrayLength_3 = 4;

        using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_3);

        // Argument 1
        global::System.Runtime.InteropServices.JavaScript.JSObject ___propObject_4 = l.JSObject;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsUnion(___argsArray_0.JSObject, 0, ___propObject_4);

        // Argument 2
        global::System.Runtime.InteropServices.JavaScript.JSObject ___propObject_5 = a.JSObject;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsUnion(___argsArray_0.JSObject, 1, ___propObject_5);

        // Argument 3
        global::System.Runtime.InteropServices.JavaScript.JSObject ___propObject_6 = b.JSObject;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsUnion(___argsArray_0.JSObject, 2, ___propObject_6);

        // Argument 4
        global::System.Runtime.InteropServices.JavaScript.JSObject ___propObject_7 = alpha.JSObject;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsUnion(___argsArray_0.JSObject, 3, ___propObject_7);

        global::System.Runtime.InteropServices.JavaScript.JSObject ___res_2 = global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectNonEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "CSSLab", ___argsArray_0.JSObject);
        return new global::Iskra.StdWeb.CSSLab(___res_2);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.Union<double, global::Iskra.StdWeb.CSSNumericValue, string, global::Iskra.StdWeb.CSSKeywordValue, global::Iskra.StdWeb.GenericMarshaller.Union> L
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.Union<double, global::Iskra.StdWeb.CSSNumericValue, string, global::Iskra.StdWeb.CSSKeywordValue, global::Iskra.StdWeb.GenericMarshaller.Union>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "l");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.JSCore.Generics.Union<double, global::Iskra.StdWeb.CSSNumericValue, string, global::Iskra.StdWeb.CSSKeywordValue, global::Iskra.StdWeb.GenericMarshaller.Union>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "l", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.Union<double, global::Iskra.StdWeb.CSSNumericValue, string, global::Iskra.StdWeb.CSSKeywordValue, global::Iskra.StdWeb.GenericMarshaller.Union> A
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.Union<double, global::Iskra.StdWeb.CSSNumericValue, string, global::Iskra.StdWeb.CSSKeywordValue, global::Iskra.StdWeb.GenericMarshaller.Union>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "a");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.JSCore.Generics.Union<double, global::Iskra.StdWeb.CSSNumericValue, string, global::Iskra.StdWeb.CSSKeywordValue, global::Iskra.StdWeb.GenericMarshaller.Union>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "a", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.Union<double, global::Iskra.StdWeb.CSSNumericValue, string, global::Iskra.StdWeb.CSSKeywordValue, global::Iskra.StdWeb.GenericMarshaller.Union> B
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.Union<double, global::Iskra.StdWeb.CSSNumericValue, string, global::Iskra.StdWeb.CSSKeywordValue, global::Iskra.StdWeb.GenericMarshaller.Union>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "b");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.JSCore.Generics.Union<double, global::Iskra.StdWeb.CSSNumericValue, string, global::Iskra.StdWeb.CSSKeywordValue, global::Iskra.StdWeb.GenericMarshaller.Union>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "b", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.Union<double, global::Iskra.StdWeb.CSSNumericValue, string, global::Iskra.StdWeb.CSSKeywordValue, global::Iskra.StdWeb.GenericMarshaller.Union> Alpha
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.Union<double, global::Iskra.StdWeb.CSSNumericValue, string, global::Iskra.StdWeb.CSSKeywordValue, global::Iskra.StdWeb.GenericMarshaller.Union>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "alpha");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.JSCore.Generics.Union<double, global::Iskra.StdWeb.CSSNumericValue, string, global::Iskra.StdWeb.CSSKeywordValue, global::Iskra.StdWeb.GenericMarshaller.Union>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "alpha", value);
    }
}

#nullable disable