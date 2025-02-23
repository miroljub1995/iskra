using System.Runtime.CompilerServices;
using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebApi.Api;

[GenerateBindings]
[AddToGlobalFactory]
public class HTMLCollection
{
    protected HTMLCollection() => throw new();

    public int Length
    {
        get => throw new();
    }

    public Element? Item(int index) => throw new();

    [IndexerName("Indexer")] public Element? this[int index] => throw new();

    public Element? NamedItem(string name) => throw new();

    [IndexerName("Indexer")] public Element? this[string name] => throw new();
}