using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;

namespace Iskra.JSFunction;

[SupportedOSPlatform("browser")]
public partial class JSFunction(JSObject func)
{
    private const string ProxyMethodName = "iskra_callFunction";
    private static bool _hasProxyMethod;

    public object Call(params object[] args)
    {
        if (!_hasProxyMethod)
        {
            JSHost.GlobalThis.SetProperty(ProxyMethodName,
                Function("arguments[0](...arguments[1])"));
            _hasProxyMethod = true;
        }

        return CallFunction(func, args);
    }

    [JSImport($"globalThis.{ProxyMethodName}")]
    [return: JSMarshalAs<JSType.Any>]
    private static partial object CallFunction(JSObject func, [JSMarshalAs<JSType.Array<JSType.Any>>] object[] args);

    [JSImport("globalThis.Function")]
    private static partial JSObject Function(string code);
}