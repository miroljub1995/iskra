using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebApi.Api;

[GenerateBindings]
[AddToGlobalFactory]
public class Element : Node
{
    protected Element() => throw new();

    public string TagName
    {
        get => throw new();
    }

    public string InnerHTML
    {
        get => throw new();
        set => throw new();
    }

    public DomTokenList ClassList
    {
        get => throw new();
    }
}