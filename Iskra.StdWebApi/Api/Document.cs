using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebApi.Api;

[GenerateBindings]
[AddToGlobalFactory]
public class Document : Node
{
    protected Document() => throw new();

    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/Document/activeElement
    /// </summary>
    public Element? activeElement => throw new();

    public HTMLBodyElement? Body
    {
        get => throw new();
        set => throw new();
    }

    public Element CreateElement(string tagName, ElementCreationOptions? options = null) => throw new();

    public Text CreateTextNode(string data) => throw new();
}