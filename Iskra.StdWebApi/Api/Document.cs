using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebApi.Api;

[GenerateBindings]
public class Document : Node
{
    protected Document() => throw new();

    public HTMLBodyElement? Body
    {
        get => throw new();
        set => throw new();
    }

    public Element CreateElement(string tagName, ElementCreationOptions? options = null) => throw new();

    public Text CreateTextNode(string data) => throw new();
}