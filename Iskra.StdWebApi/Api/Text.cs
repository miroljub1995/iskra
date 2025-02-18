using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebApi.Api;

[GenerateBindings]
[AddToGlobalFactory]
public class Text : Node
{
    protected Text() => throw new();

    public string WholeText
    {
        get => throw new();
    }
}