using System.Runtime.InteropServices.JavaScript;

namespace Iskra.StdWeb.Dom;

public class HtmlInputElement(JSObject obj) : HtmlElement(obj)
{
    public string Value => JSObject.GetPropertyAsString("value")
                           ?? throw new("value is null.");
}