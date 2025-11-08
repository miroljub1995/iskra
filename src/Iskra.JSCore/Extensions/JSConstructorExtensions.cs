using System.Runtime.InteropServices.JavaScript;

namespace Iskra.JSCore.Extensions;

public static partial class JSConstructorExtensions
{
    public static JSObject ConstructObjectEmpty(
        this JSObject obj,
        string constructorName
    ) => ConstructObjectEmpty_Bridge(obj, constructorName);

    [JSImport("constructObjectEmpty", "iskra")]
    private static partial JSObject ConstructObjectEmpty_Bridge(
        JSObject obj,
        string propertyName
    );  

    public static JSObject ConstructObjectNonEmpty(
        this JSObject obj,
        string constructorName,
        JSObject args
    ) => ConstructObjectNonEmpty_Bridge(obj, constructorName, args);

    [JSImport("constructObjectNonEmpty", "iskra")]
    private static partial JSObject ConstructObjectNonEmpty_Bridge(
        JSObject obj,
        string propertyName,
        JSObject args
    );
}