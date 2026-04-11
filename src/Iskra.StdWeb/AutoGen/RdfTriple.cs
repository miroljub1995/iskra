// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class RdfTriple: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public RdfTriple(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatformAttribute("browser")]
    public static global::Iskra.StdWeb.RdfTriple New()
    {
        global::System.Runtime.InteropServices.JavaScript.JSObject ___res_2 = global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "RdfTriple");
        return new global::Iskra.StdWeb.RdfTriple(___res_2);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string Subject
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "subject");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string Predicate
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "predicate");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.Union<string, global::Iskra.StdWeb.RdfLiteral, global::Iskra.StdWeb.GenericMarshaller.Union> Object
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.Union<string, global::Iskra.StdWeb.RdfLiteral, global::Iskra.StdWeb.GenericMarshaller.Union>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "object");
    }
}

#nullable disable