using System.Runtime.InteropServices.JavaScript;

namespace Iskra.JSCore.Extensions;

public static partial class JSObjectPropertyExtensions
{
    #region Constructor

    public static JSObject GetPropertyAsConstructorProxy(this JSObject obj, string constructorName) =>
        GetConstructorProxy_Bridge(obj, constructorName);

    [JSImport("getPropertyAsConstructorProxy", "iskra")]
    private static partial JSObject GetConstructorProxy_Bridge(JSObject obj, string constructorName);

    #endregion

    #region Boolean Get

    public static bool? GetPropertyAsBooleanV2AsNullable(this JSObject obj, string propertyName) =>
        GetPropertyAsBooleanV2AsNullable_Bridge(obj, propertyName);

    public static bool? GetPropertyAsBooleanV2AsNullable(this JSObject obj, int propertyIndex) =>
        GetPropertyAsBooleanV2AsNullable_Bridge(obj, propertyIndex);

    public static bool GetPropertyAsBooleanV2(this JSObject obj, string propertyName) =>
        GetPropertyAsBooleanV2AsNullable_Bridge(obj, propertyName) ??
        throw new Exception($"Property {propertyName} is null or undefined.");

    public static bool GetPropertyAsBooleanV2(this JSObject obj, int propertyIndex) =>
        GetPropertyAsBooleanV2AsNullable_Bridge(obj, propertyIndex) ??
        throw new Exception($"Property {propertyIndex} is null or undefined.");

    [JSImport("globalThis.Reflect.get")]
    private static partial bool? GetPropertyAsBooleanV2AsNullable_Bridge(JSObject obj, string propertyName);

    [JSImport("globalThis.Reflect.get")]
    private static partial bool? GetPropertyAsBooleanV2AsNullable_Bridge(JSObject obj, int index);

    #endregion

    #region Double Get

    public static double? GetPropertyAsDoubleV2AsNullable(this JSObject obj, string propertyName) =>
        GetPropertyAsDoubleV2AsNullable_Bridge(obj, propertyName);

    public static double? GetPropertyAsDoubleV2AsNullable(this JSObject obj, int propertyIndex) =>
        GetPropertyAsDoubleV2AsNullable_Bridge(obj, propertyIndex);

    public static double GetPropertyAsDoubleV2(this JSObject obj, string propertyName) =>
        GetPropertyAsDoubleV2AsNullable_Bridge(obj, propertyName) ??
        throw new Exception($"Property {propertyName} is null or undefined.");

    public static double GetPropertyAsDoubleV2(this JSObject obj, int propertyIndex) =>
        GetPropertyAsDoubleV2AsNullable_Bridge(obj, propertyIndex) ??
        throw new Exception($"Property {propertyIndex} is null or undefined.");

    [JSImport("globalThis.Reflect.get")]
    private static partial double? GetPropertyAsDoubleV2AsNullable_Bridge(JSObject obj, string propertyName);

    [JSImport("globalThis.Reflect.get")]
    private static partial double? GetPropertyAsDoubleV2AsNullable_Bridge(JSObject obj, int propertyIndex);

    #endregion

    #region String Get

    public static string GetPropertyAsStringV2(this JSObject obj, string propertyName) =>
        GetPropertyAsStringV2AsNullable_Bridge(obj, propertyName) ??
        throw new Exception($"Property {propertyName} is null or undefined.");

    public static string GetPropertyAsStringV2(this JSObject obj, int propertyIndex) =>
        GetPropertyAsStringV2AsNullable_Bridge(obj, propertyIndex) ??
        throw new Exception($"Property {propertyIndex} is null or undefined.");

    public static string? GetPropertyAsStringV2AsNullable(this JSObject obj, string propertyName) =>
        GetPropertyAsStringV2AsNullable_Bridge(obj, propertyName);

    public static string? GetPropertyAsStringV2AsNullable(this JSObject obj, int propertyIndex) =>
        GetPropertyAsStringV2AsNullable_Bridge(obj, propertyIndex);

    [JSImport("globalThis.Reflect.get")]
    private static partial string? GetPropertyAsStringV2AsNullable_Bridge(JSObject obj, string propertyName);

    [JSImport("globalThis.Reflect.get")]
    private static partial string? GetPropertyAsStringV2AsNullable_Bridge(JSObject obj, int propertyIndex);

    #endregion

    #region JSObject Get

    public static JSObject GetPropertyAsJSObjectV2(this JSObject obj, string propertyName) =>
        GetPropertyAsJSObjectV2AsNullable_Bridge(obj, propertyName) ??
        throw new Exception($"Property {propertyName} is null or undefined.");

    public static JSObject GetPropertyAsJSObjectV2(this JSObject obj, int propertyIndex) =>
        GetPropertyAsJSObjectV2AsNullable_Bridge(obj, propertyIndex) ??
        throw new Exception($"Property {propertyIndex} is null or undefined.");

    public static JSObject? GetPropertyAsJSObjectV2AsNullable(this JSObject obj, string propertyName) =>
        GetPropertyAsJSObjectV2AsNullable_Bridge(obj, propertyName);

    public static JSObject? GetPropertyAsJSObjectV2AsNullable(this JSObject obj, int propertyIndex) =>
        GetPropertyAsJSObjectV2AsNullable_Bridge(obj, propertyIndex);

    [JSImport("globalThis.Reflect.get")]
    private static partial JSObject? GetPropertyAsJSObjectV2AsNullable_Bridge(JSObject obj, string propertyName);

    [JSImport("globalThis.Reflect.get")]
    private static partial JSObject? GetPropertyAsJSObjectV2AsNullable_Bridge(JSObject obj, int propertyIndex);

    #endregion

    // public static object GetPropertyAsObjectV2(this JSObject obj, string propertyName) =>
    //     GetPropertyAsObjectV2AsNullable_Bridge(obj, propertyName) ??
    //     throw new Exception($"Property {propertyName} is null or undefined.");
    //
    // public static object? GetPropertyAsObjectV2AsNullable(this JSObject obj, string propertyName) =>
    //     GetPropertyAsObjectV2AsNullable_Bridge(obj, propertyName);

    // [JSImport("globalThis.Reflect.get")]
    // [return: JSMarshalAs<JSType.Any>]
    // private static partial object? GetPropertyAsObjectV2AsNullable_Bridge(JSObject obj, string propertyName);

    #region Union Get

    public static JSObject GetPropertyAsUnionV2(this JSObject obj, string propertyName) =>
        GetPropertyAsUnionV2AsNullable_Bridge(obj, propertyName) ??
        throw new Exception($"Property {propertyName} is null or undefined.");

    public static JSObject GetPropertyAsUnionV2(this JSObject obj, int propertyIndex) =>
        GetPropertyAsUnionV2AsNullable_Bridge(obj, propertyIndex) ??
        throw new Exception($"Property {propertyIndex} is null or undefined.");

    public static JSObject? GetPropertyAsUnionV2AsNullable(this JSObject obj, string propertyName) =>
        GetPropertyAsUnionV2AsNullable_Bridge(obj, propertyName);

    public static JSObject? GetPropertyAsUnionV2AsNullable(this JSObject obj, int propertyIndex) =>
        GetPropertyAsUnionV2AsNullable_Bridge(obj, propertyIndex);

    [JSImport("getPropertyAsUnion", "iskra")]
    [return: JSMarshalAs<JSType.Object>]
    private static partial JSObject? GetPropertyAsUnionV2AsNullable_Bridge(JSObject obj, string propertyName);

    [JSImport("getPropertyAsUnion", "iskra")]
    [return: JSMarshalAs<JSType.Object>]
    private static partial JSObject? GetPropertyAsUnionV2AsNullable_Bridge(JSObject obj, int propertyIndex);

    #endregion

    #region Boolean Set

    public static void SetPropertyAsBooleanV2AsNullable(this JSObject obj, string propertyName, bool? value) =>
        SetPropertyAsBooleanV2AsNullable_Bridge(obj, propertyName, value);

    public static void SetPropertyAsBooleanV2AsNullable(this JSObject obj, int propertyIndex, bool? value) =>
        SetPropertyAsBooleanV2AsNullable_Bridge(obj, propertyIndex, value);

    public static void SetPropertyAsBooleanV2(this JSObject obj, string propertyName, bool value) =>
        SetPropertyAsBooleanV2AsNullable_Bridge(obj, propertyName, value);

    public static void SetPropertyAsBooleanV2(this JSObject obj, int propertyIndex, bool value) =>
        SetPropertyAsBooleanV2AsNullable_Bridge(obj, propertyIndex, value);

    [JSImport("globalThis.Reflect.set")]
    private static partial void SetPropertyAsBooleanV2AsNullable_Bridge(JSObject obj, string propertyName, bool? value);

    [JSImport("globalThis.Reflect.set")]
    private static partial void SetPropertyAsBooleanV2AsNullable_Bridge(JSObject obj, int propertyIndex, bool? value);

    #endregion

    #region Double Set

    public static void SetPropertyAsDoubleV2AsNullable(this JSObject obj, string propertyName, double? value) =>
        SetPropertyAsDoubleV2AsNullable_Bridge(obj, propertyName, value);

    public static void SetPropertyAsDoubleV2AsNullable(this JSObject obj, int propertyIndex, double? value) =>
        SetPropertyAsDoubleV2AsNullable_Bridge(obj, propertyIndex, value);

    public static void SetPropertyAsDoubleV2(this JSObject obj, string propertyName, double value) =>
        SetPropertyAsDoubleV2AsNullable_Bridge(obj, propertyName, value);

    public static void SetPropertyAsDoubleV2(this JSObject obj, int propertyIndex, double value) =>
        SetPropertyAsDoubleV2AsNullable_Bridge(obj, propertyIndex, value);

    [JSImport("globalThis.Reflect.set")]
    private static partial void
        SetPropertyAsDoubleV2AsNullable_Bridge(JSObject obj, string propertyName, double? value);

    [JSImport("globalThis.Reflect.set")]
    private static partial void
        SetPropertyAsDoubleV2AsNullable_Bridge(JSObject obj, int propertyIndex, double? value);

    #endregion

    #region String Set

    public static void SetPropertyAsStringV2AsNullable(this JSObject obj, string propertyName, string? value) =>
        SetPropertyAsStringV2AsNullable_Bridge(obj, propertyName, value);

    public static void SetPropertyAsStringV2AsNullable(this JSObject obj, int propertyIndex, string? value) =>
        SetPropertyAsStringV2AsNullable_Bridge(obj, propertyIndex, value);


    public static void SetPropertyAsStringV2(this JSObject obj, string propertyName, string value) =>
        SetPropertyAsStringV2AsNullable_Bridge(obj, propertyName, value);

    public static void SetPropertyAsStringV2(this JSObject obj, int propertyIndex, string value) =>
        SetPropertyAsStringV2AsNullable_Bridge(obj, propertyIndex, value);

    [JSImport("globalThis.Reflect.set")]
    private static partial void
        SetPropertyAsStringV2AsNullable_Bridge(JSObject obj, string propertyName, string? value);

    [JSImport("globalThis.Reflect.set")]
    private static partial void
        SetPropertyAsStringV2AsNullable_Bridge(JSObject obj, int propertyIndex, string? value);

    #endregion

    #region JSObject Set

    public static void SetPropertyAsJSObjectV2AsNullable(this JSObject obj, string propertyName, JSObject? value) =>
        SetPropertyAsJSObjectV2AsNullable_Bridge(obj, propertyName, value);

    public static void SetPropertyAsJSObjectV2AsNullable(this JSObject obj, int propertyIndex, JSObject? value) =>
        SetPropertyAsJSObjectV2AsNullable_Bridge(obj, propertyIndex, value);


    public static void SetPropertyAsJSObjectV2(this JSObject obj, string propertyName, JSObject value) =>
        SetPropertyAsJSObjectV2AsNullable_Bridge(obj, propertyName, value);

    public static void SetPropertyAsJSObjectV2(this JSObject obj, int propertyIndex, JSObject value) =>
        SetPropertyAsJSObjectV2AsNullable_Bridge(obj, propertyIndex, value);

    [JSImport("globalThis.Reflect.set")]
    private static partial void
        SetPropertyAsJSObjectV2AsNullable_Bridge(JSObject obj, string propertyName, JSObject? value);

    [JSImport("globalThis.Reflect.set")]
    private static partial void
        SetPropertyAsJSObjectV2AsNullable_Bridge(JSObject obj, int propertyIndex, JSObject? value);

    #endregion

    // public static void SetPropertyAsObjectV2AsNullable(this JSObject obj, string propertyName, object? value) =>
    //     SetPropertyAsObjectV2AsNullable_Bridge(obj, propertyName, value);
    //
    // public static void SetPropertyAsObjectV2(this JSObject obj, string propertyName, object value) =>
    //     SetPropertyAsObjectV2AsNullable_Bridge(obj, propertyName, value);
    //
    // [JSImport("globalThis.Reflect.set")]
    // private static partial void
    //     SetPropertyAsObjectV2AsNullable_Bridge(JSObject obj, string propertyName,
    //         [JSMarshalAs<JSType.Any>] object? value);

    #region Union Set

    public static void SetPropertyAsUnionAsNullable(this JSObject obj, string propertyName, JSObject? value) =>
        SetPropertyAsUnionV2AsNullable_Bridge(obj, propertyName, value);

    public static void SetPropertyAsUnionAsNullable(this JSObject obj, int propertyIndex, JSObject? value) =>
        SetPropertyAsUnionV2AsNullable_Bridge(obj, propertyIndex, value);

    [JSImport("setPropertyAsUnion", "iskra")]
    private static partial void SetPropertyAsUnionV2AsNullable_Bridge(JSObject obj, string propertyName,
        JSObject? value);

    [JSImport("setPropertyAsUnion", "iskra")]
    private static partial void SetPropertyAsUnionV2AsNullable_Bridge(JSObject obj, int propertyIndex,
        JSObject? value);

    #endregion
}