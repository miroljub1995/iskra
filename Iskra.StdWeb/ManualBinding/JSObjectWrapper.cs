using System.Runtime.InteropServices.JavaScript;

namespace Iskra.StdWeb;

public class JSObjectWrapper(JSObject obj)
{
    public JSObject JSObject => obj;

    public static implicit operator JSObject(JSObjectWrapper jsWrapper)
        => jsWrapper.JSObject;
}