using System.Runtime.InteropServices.JavaScript;
using Iskra.Utils;

namespace Iskra.StdWeb.Dom;

public class Node(JSObject obj) : EventTarget(obj)
{
    public NodeList ChildNodes => new(JSObject.GetPropertyAsJSObject("childNodes")
                                      ?? throw new("childNodes not defined."));

    public Node? PreviousSibling => JSObject.GetPropertyAsJSObject("previousSibling") is { } obj ? new(obj) : null;

    public TNode AppendChild<TNode>(TNode node)
        where TNode : Node
    {
        JSFunction func = JSObject.GetPropertyAsJSFunction("appendChild")
                          ?? throw new("appendChild not defined.");

        func.Call(node.JSObject);

        return node;
    }

    public TNode ReplaceChild<TNode>(TNode newChild, Node oldChild)
        where TNode : Node
    {
        JSFunction func = JSObject.GetPropertyAsJSFunction("replaceChild")
                          ?? throw new("replaceChild not defined.");

        func.Call(newChild.JSObject, oldChild.JSObject);

        return newChild;
    }
}