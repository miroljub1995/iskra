using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;

namespace Iskra.JSFunction;

[SupportedOSPlatform("browser")]
public static partial class ManagedToJSFunctionExtensions
{
    private const string ProxyFunctionName = "iskra_toJSObject";
    private const string ImportProxyFunctionName = $"globalThis.{ProxyFunctionName}";
    private static bool _isProxyInitialized;

    [JSImport(ImportProxyFunctionName)]
    private static partial JSObject ToJSObjectProxy(
        [JSMarshalAs<JSType.Function>] Action action
    );

    [JSImport(ImportProxyFunctionName)]
    private static partial JSObject ToJSObjectProxy(
        [JSMarshalAs<JSType.Function<JSType.Any>>]
        Action<object?> action
    );

    [JSImport(ImportProxyFunctionName)]
    private static partial JSObject ToJSObjectProxy(
        [JSMarshalAs<JSType.Function<JSType.Any, JSType.Any>>]
        Action<object?, object?> action
    );

    [JSImport(ImportProxyFunctionName)]
    private static partial JSObject ToJSObjectProxy(
        [JSMarshalAs<JSType.Function<JSType.Any, JSType.Any, JSType.Any>>]
        Action<object?, object?, object?> action
    );

    [JSImport(ImportProxyFunctionName)]
    private static partial JSObject ToJSObjectProxy(
        [JSMarshalAs<JSType.Function<JSType.Any>>]
        Func<object?> action
    );

    [JSImport(ImportProxyFunctionName)]
    private static partial JSObject ToJSObjectProxy(
        [JSMarshalAs<JSType.Function<JSType.Any, JSType.Any>>]
        Func<object?, object?> action
    );

    [JSImport(ImportProxyFunctionName)]
    private static partial JSObject ToJSObjectProxy(
        [JSMarshalAs<JSType.Function<JSType.Any, JSType.Any, JSType.Any>>]
        Func<object?, object?, object?> action
    );

    [JSImport(ImportProxyFunctionName)]
    private static partial JSObject ToJSObjectProxy(
        [JSMarshalAs<JSType.Function<JSType.Any, JSType.Any, JSType.Any, JSType.Any>>]
        Func<object?, object?, object?, object?> action
    );

    private static void EnsureMethodProxyInitialized()
    {
        if (!_isProxyInitialized)
        {
            JSHost.GlobalThis.SetProperty(ProxyFunctionName,
                Function("cb", "return ((...args) => cb(...args));"));
            _isProxyInitialized = true;
        }
    }

    [JSImport("globalThis.Function")]
    private static partial JSObject Function(string cb, string code);

    public static JSObject ToJSObject(this Action action)
    {
        EnsureMethodProxyInitialized();

        return ToJSObjectProxy(action);
    }

    public static JSObject ToJSObject(this Action<object?> action)
    {
        EnsureMethodProxyInitialized();

        return ToJSObjectProxy(action);
    }

    public static JSObject ToJSObject(this Action<object?, object?> action)
    {
        EnsureMethodProxyInitialized();

        return ToJSObjectProxy(action);
    }

    public static JSObject ToJSObject(this Action<object?, object?, object?> action)
    {
        EnsureMethodProxyInitialized();

        return ToJSObjectProxy(action);
    }

    public static JSObject ToJSObject(this Func<object?> action)
    {
        EnsureMethodProxyInitialized();

        return ToJSObjectProxy(action);
    }

    public static JSObject ToJSObject(this Func<object?, object?> action)
    {
        EnsureMethodProxyInitialized();

        return ToJSObjectProxy(action);
    }

    public static JSObject ToJSObject(this Func<object?, object?, object?> action)
    {
        EnsureMethodProxyInitialized();

        return ToJSObjectProxy(action);
    }

    public static JSObject ToJSObject(this Func<object?, object?, object?, object?> action)
    {
        EnsureMethodProxyInitialized();

        return ToJSObjectProxy(action);
    }
}