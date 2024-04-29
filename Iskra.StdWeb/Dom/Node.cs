using System.Runtime.InteropServices.JavaScript;
using Iskra.Utils;

namespace Iskra.StdWeb.Dom;

public class Node(JSObject obj) : EventTarget(obj)
{
    public NodeList ChildNodes => new(JSObject.GetPropertyAsJSObject("childNodes")
                                      ?? throw new("childNodes not defined."));

    public TNode AppendChild<TNode>(TNode node)
        where TNode : Node
    {
        JSFunction func = JSObject.GetPropertyAsJSFunction("appendChild")
                          ?? throw new("appendChild not defined.");

        func.Call(node.JSObject);

        return node;
    }
}