using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebApi.Api;

[GenerateBindings]
public class Element : Node
{
    protected Element() => throw new();

    public string InnerHTML
    {
        get => throw new();
        set => throw new();
    }
}