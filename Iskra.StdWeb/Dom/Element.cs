using System.Runtime.InteropServices.JavaScript;

namespace Iskra.StdWeb.Dom;

public class Element(JSObject obj) : Node(obj)
{
    public string TagName => JSObject.GetPropertyAsString("tagName")
                             ?? throw new("tagName not defined.");
}