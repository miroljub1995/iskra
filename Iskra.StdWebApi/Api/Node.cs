using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebApi.Api;

[GenerateBindings]
public class Node : EventTarget
{
    protected Node() => throw new();

    public NodeList ChildNodes
    {
        get => throw new();
    }

    public Node AppendChild(Node aChild) => throw new();

    public Node ReplaceChild(Node newChild, Node oldChild) => throw new();
}