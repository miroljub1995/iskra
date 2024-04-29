using System.Runtime.InteropServices.JavaScript;

namespace Iskra.StdWeb.Dom;

public class Text(JSObject obj) : Node(obj)
{
    public string WholeText => JSObject.GetPropertyAsString("wholeText")
                               ?? throw new("wholeText is not defined");
}