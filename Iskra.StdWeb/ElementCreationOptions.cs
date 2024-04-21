using System.Runtime.InteropServices.JavaScript;
using Iskra.StdWeb.Dom;
using Iskra.Utils;

namespace Iskra.StdWeb;

public class ElementCreationOptions(JSObject obj) : JSObjectWrapper(obj)
{
    public ElementCreationOptions() : this(JSObjectCreator.Create())
    {
    }

    public string? Is
    {
        get => JSObject.GetPropertyAsString("is");
        set => JSObject.SetProperty("is", value);
    }
}