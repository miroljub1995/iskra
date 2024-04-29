using System.Runtime.InteropServices.JavaScript;
using Iskra.Utils;

namespace Iskra.StdWeb.Dom;

public class DomTokenList(JSObject obj) : JSObjectWrapper(obj)
{
    public string Value
    {
        get => JSObject.GetPropertyAsString("value")
               ?? throw new("value not defined.");

        set => JSObject.SetProperty("value", value);
    }
}