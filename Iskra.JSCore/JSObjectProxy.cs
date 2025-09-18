using System.Runtime.InteropServices.JavaScript;

namespace Iskra.JSCore;

public abstract class JSObjectProxy(JSObject obj)
{
    private static readonly Dictionary<string, Func<JSObject, JSObjectProxy>> GlobalConstructors = [];

    public JSObject JSObject => obj;
}