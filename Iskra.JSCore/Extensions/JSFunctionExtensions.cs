using System.Runtime.InteropServices.JavaScript;

namespace Iskra.JSCore.Extensions;

public static partial class JSFunctionExtensions
{
    private record ManagedRef(object Ref);

    #region Wrap Void Function

    public static JSObject WrapAsVoidFunction(this Action<JSObject> function) =>
        WrapAsVoidFunction_Bridge(function);

    [JSImport("wrapAsVoidFunction", "iskra")]
    private static partial JSObject WrapAsVoidFunction_Bridge(
        [JSMarshalAs<JSType.Function<JSType.Object>>]
        Action<JSObject> function
    );

    #endregion

    #region Wrap Non-Void Function

    public static JSObject WrapAsNonVoidFunction(this Action<JSObject, JSObject> function) =>
        WrapAsNonVoidFunction_Bridge(function);

    [JSImport("wrapAsNonVoidFunction", "iskra")]
    private static partial JSObject WrapAsNonVoidFunction_Bridge(
        [JSMarshalAs<JSType.Function<JSType.Object, JSType.Object>>]
        Action<JSObject, JSObject> function
    );

    #endregion

    #region Store/Get Manged Ref in JSObject

    public static void StoreManagedFunctionToProperty(
        this JSObject function,
        object managedRef
    ) => StoreManagedFunctionToProperty_Bridge(function, new ManagedRef(managedRef));

    [JSImport("storeManagedFunctionToProperty", "iskra")]
    private static partial void StoreManagedFunctionToProperty_Bridge(
        JSObject function,
        [JSMarshalAs<JSType.Any>] object managedRef
    );

    public static object? GetManagedFunctionFromProperty(
        this JSObject function
    ) => GetManagedFunctionFromProperty_Bridge(function) is ManagedRef managedRef ? managedRef.Ref : null;

    [JSImport("getManagedFunctionFromProperty", "iskra")]
    [return: JSMarshalAs<JSType.Any>]
    private static partial object? GetManagedFunctionFromProperty_Bridge(
        JSObject function
    );

    #endregion

    #region Call Empty Void Function

    public static void CallEmptyVoidFunction(
        this JSObject function,
        JSObject? thisArg
    ) => CallEmptyVoidFunction_Bridge(function, thisArg);

    [JSImport("callEmptyVoidFunction", "iskra")]
    private static partial void CallEmptyVoidFunction_Bridge(
        JSObject function,
        JSObject? thisArg
    );

    public static void CallEmptyVoidFunctionProperty(
        this JSObject obj,
        string propertyName,
        JSObject? thisArg
    ) => CallEmptyVoidFunctionProperty_Bridge(obj, propertyName, thisArg);

    [JSImport("callEmptyVoidFunctionProperty", "iskra")]
    private static partial void CallEmptyVoidFunctionProperty_Bridge(
        JSObject obj,
        string propertyName,
        JSObject? thisArg
    );

    public static void CallEmptyVoidFunctionProperty(
        this JSObject obj,
        int propertyIndex,
        JSObject? thisArg
    ) => CallEmptyVoidFunctionProperty_Bridge(obj, propertyIndex, thisArg);

    [JSImport("callEmptyVoidFunctionProperty", "iskra")]
    private static partial void CallEmptyVoidFunctionProperty_Bridge(
        JSObject obj,
        int propertyIndex,
        JSObject? thisArg
    );

    #endregion

    #region Call Empty Non-Void Function

    public static void CallEmptyNonVoidFunction(
        this JSObject function,
        JSObject? thisArg,
        JSObject res
    ) => CallEmptyNonVoidFunction_Bridge(function, thisArg, res);

    [JSImport("callEmptyNonVoidFunction", "iskra")]
    private static partial void CallEmptyNonVoidFunction_Bridge(
        JSObject function,
        JSObject? thisArg,
        JSObject res
    );

    public static void CallEmptyNonVoidFunctionProperty(
        this JSObject obj,
        string propertyName,
        JSObject? thisArg,
        JSObject res
    ) => CallEmptyNonVoidFunctionProperty_Bridge(obj, propertyName, thisArg, res);

    [JSImport("callEmptyNonVoidFunctionProperty", "iskra")]
    private static partial void CallEmptyNonVoidFunctionProperty_Bridge(
        JSObject obj,
        string propertyName,
        JSObject? thisArg,
        JSObject res
    );

    public static void CallEmptyNonVoidFunctionProperty(
        this JSObject obj,
        int propertyIndex,
        JSObject? thisArg,
        JSObject res
    ) => CallEmptyNonVoidFunctionProperty_Bridge(obj, propertyIndex, thisArg, res);

    [JSImport("callEmptyNonVoidFunctionProperty", "iskra")]
    private static partial void CallEmptyNonVoidFunctionProperty_Bridge(
        JSObject obj,
        int propertyIndex,
        JSObject? thisArg,
        JSObject res
    );

    #endregion

    #region Call Non-Empty Void Function

    public static void CallNonEmptyVoidFunction(
        this JSObject function,
        JSObject? thisArg,
        JSObject args
    ) => CallNonEmptyVoidFunction_Bridge(function, thisArg, args);

    [JSImport("callNonEmptyVoidFunction", "iskra")]
    private static partial void CallNonEmptyVoidFunction_Bridge(
        JSObject function,
        JSObject? thisArg,
        JSObject args
    );

    public static void CallNonEmptyVoidFunctionProperty(
        this JSObject obj,
        string propertyName,
        JSObject? thisArg,
        JSObject args
    ) => CallNonEmptyVoidFunctionProperty_Bridge(obj, propertyName, thisArg, args);

    [JSImport("callNonEmptyVoidFunctionProperty", "iskra")]
    private static partial void CallNonEmptyVoidFunctionProperty_Bridge(
        JSObject obj,
        string propertyName,
        JSObject? thisArg,
        JSObject args
    );

    public static void CallNonEmptyVoidFunctionProperty(
        this JSObject obj,
        int propertyIndex,
        JSObject? thisArg,
        JSObject args
    ) => CallNonEmptyVoidFunctionProperty_Bridge(obj, propertyIndex, thisArg, args);

    [JSImport("callNonEmptyVoidFunctionProperty", "iskra")]
    private static partial void CallNonEmptyVoidFunctionProperty_Bridge(JSObject obj, int propertyIndex,
        JSObject? thisArg,
        JSObject args);

    #endregion

    #region Call Non-Empty Non-Void Function

    public static void CallNonEmptyNonVoidFunction(
        this JSObject function,
        JSObject? thisArg,
        JSObject args,
        JSObject res
    ) => CallNonEmptyNonVoidFunction_Bridge(function, thisArg, args, res);

    [JSImport("callNonEmptyNonVoidFunction", "iskra")]
    private static partial void CallNonEmptyNonVoidFunction_Bridge(
        JSObject function,
        JSObject? thisArg,
        JSObject args,
        JSObject res
    );

    public static void CallNonEmptyNonVoidFunctionProperty(
        this JSObject obj,
        string propertyName,
        JSObject? thisArg,
        JSObject args,
        JSObject res
    ) => CallNonEmptyNonVoidFunctionProperty_Bridge(obj, propertyName, thisArg, args, res);

    [JSImport("callNonEmptyNonVoidFunctionProperty", "iskra")]
    private static partial void CallNonEmptyNonVoidFunctionProperty_Bridge(
        JSObject obj,
        string propertyName,
        JSObject? thisArg,
        JSObject args,
        JSObject res
    );

    public static void CallNonEmptyNonVoidFunctionProperty(
        this JSObject obj,
        int propertyIndex,
        JSObject? thisArg,
        JSObject args,
        JSObject res
    ) => CallNonEmptyNonVoidFunctionProperty_Bridge(obj, propertyIndex, thisArg, args, res);

    [JSImport("callNonEmptyNonVoidFunctionProperty", "iskra")]
    private static partial void CallNonEmptyNonVoidFunctionProperty_Bridge(
        JSObject obj,
        int propertyIndex,
        JSObject? thisArg,
        JSObject args,
        JSObject res
    );

    #endregion
}