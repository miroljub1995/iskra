using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebApi.Api;

[GenerateBindings]
[AddToGlobalFactory]
public class StylePropertyMapReadOnly
{
    protected StylePropertyMapReadOnly() => throw new();

    public int Size
    {
        get => throw new();
    }
}