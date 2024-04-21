using System.Runtime.InteropServices.JavaScript;

namespace Iskra.StdWeb.Dom;

public class EventTarget(JSObject obj)
{
    public JSObject JSObject => obj;
}