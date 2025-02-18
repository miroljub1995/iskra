using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebApi.Api;

[GenerateBindings]
[AddToGlobalFactory]
public class NodeList
{
    protected NodeList() => throw new();

    public int Length
    {
        get => throw new();
    }
}