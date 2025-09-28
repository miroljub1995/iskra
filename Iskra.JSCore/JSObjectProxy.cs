using System.Runtime.InteropServices.JavaScript;

namespace Iskra.JSCore;

public abstract class JSObjectProxy(JSObject obj)
{
    public JSObject JSObject => obj;
}