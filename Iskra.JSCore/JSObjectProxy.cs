using System.Runtime.InteropServices.JavaScript;

namespace Iskra.JSCore;

public class JSObjectProxy(JSObject obj)
{
    public JSObject JSObject => obj;
}