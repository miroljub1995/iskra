using System.Runtime.CompilerServices;
using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebApi.Api;

[GenerateBindings]
[AddToGlobalFactory]
public class NamedNodeMap
{
    protected NamedNodeMap() => throw new();

    public int Length
    {
        get => throw new();
    }

    public Attr? GetNamedItem(string name) => throw new();

    [IndexerName("Indexer")] public Attr? this[string name] => throw new();

    public Attr? SetNamedItem(Attr attribute) => throw new();

    public Attr RemoveNamedItem(string attrName) => throw new();

    public Attr? Item(int index) => throw new();

    [IndexerName("Indexer")] public Attr? this[int index] => throw new();

    public Attr? GetNamedItemNS(string namespaceURI, string localName) => throw new();

    public Attr? SetNamedItemNS(Attr attr) => throw new();

    public Attr RemoveNamedItemNS(string namespaceURI, string localName) => throw new();
}