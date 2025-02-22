using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebApi.Api;

[GenerateBindings]
[AddToGlobalFactory]
public class Node : EventTarget
{
    protected Node() => throw new();

    public string BaseURI
    {
        get => throw new();
    }

    public NodeList ChildNodes
    {
        get => throw new();
    }

    public Node? FirstChild
    {
        get => throw new();
    }

    public bool IsConnected
    {
        get => throw new();
    }

    public Node? LastChild
    {
        get => throw new();
    }

    public Node? NextSibling
    {
        get => throw new();
    }

    public string NodeName
    {
        get => throw new();
    }

    public int NodeType
    {
        get => throw new();
    }

    public string? NodeValue
    {
        get => throw new();
        set => throw new();
    }

    public Document? OwnerDocument
    {
        get => throw new();
    }

    public Node? ParentNode
    {
        get => throw new();
    }

    public Element? ParentElement
    {
        get => throw new();
    }

    public Node? PreviousSibling
    {
        get => throw new();
    }

    public string? TextContent
    {
        get => throw new();
        set => throw new();
    }

    public Node AppendChild(Node aChild) => throw new();

    public Node CloneNode() => throw new();

    public Node CloneNode(bool deep) => throw new();

    public int CompareDocumentPosition(Node otherNode) => throw new();

    public bool Contains(Node otherNode) => throw new();

    public Node GetRootNode() => throw new();
    // public Node GetRootNode(options) => throw new();

    public bool HasChildNodes() => throw new();

    public Node InsertBefore(Node newNode, Node referenceNode) => throw new();

    public bool IsDefaultNamespace(string namespaceURI) => throw new();

    public bool IsEqualNode(Node otherNode) => throw new();

    public bool IsSameNode(Node otherNode) => throw new();

    public string? LookupPrefix(string? namespaceValue) => throw new();

    public string? LookupNamespaceURI(string prefix) => throw new();

    public void Normalize() => throw new();

    public Node RemoveChild(Node child) => throw new();

    public Node ReplaceChild(Node newChild, Node oldChild) => throw new();
}