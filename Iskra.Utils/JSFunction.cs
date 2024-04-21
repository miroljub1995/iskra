using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;

namespace Iskra.Utils;

[SupportedOSPlatform("browser")]
public partial class JSFunction(JSObject? thisObj, JSObject func)
{
    private const string ProxyMethodName = "iskra_callFunction";
    private static bool _isProxyInitialized;

    public object? Call(params object?[] args)
    {
        EnsureMethodProxyInitialized();

        return CallFunction(thisObj, func, args);
    }

    public TRes Call<TRes>(params object?[] args)
    {
        object? anyRes = Call(args);
        Console.WriteLine($"res is null: {anyRes is null}");
        if (anyRes is TRes res)
        {
            return res;
        }

        throw new Exception($"Result type '{anyRes?.GetType()}' is not {typeof(TRes)}");
    }

    private static void EnsureMethodProxyInitialized()
    {
        if (!_isProxyInitialized)
        {
            JSHost.GlobalThis.SetProperty(ProxyMethodName,
                Function("thisObj", "func", "args", "return func.apply(thisObj, args);"));
            _isProxyInitialized = true;
        }
    }

    [JSImport($"globalThis.{ProxyMethodName}")]
    [return: JSMarshalAs<JSType.Any>]
    private static partial object? CallFunction(JSObject? thisObj, JSObject? func,
        [JSMarshalAs<JSType.Array<JSType.Any>>]
        object?[] args);

    [JSImport("globalThis.Function")]
    private static partial JSObject Function(string thisObjArg, string funcArg, string argsArg, string code);
}