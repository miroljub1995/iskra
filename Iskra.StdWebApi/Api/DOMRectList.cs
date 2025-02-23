using System.Runtime.CompilerServices;
using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebApi.Api;

[GenerateBindings]
[AddToGlobalFactory]
public class DOMRectList
{
    protected DOMRectList() => throw new();

    public int Length
    {
        get => throw new();
    }

    public DOMRect Item(int index) => throw new();

    [IndexerName("Indexer")]
    [IndexerAliasMethods(Get = nameof(Item))]
    public DOMRect this[int index]
    {
        get => throw new();
    }
}