using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebApi.Api;

[GenerateBindings]
[AddToGlobalFactory]
public class HTMLTitleElement : HTMLElement
{
    protected HTMLTitleElement() => throw new();

    public string Text
    {
        get => throw new();
        set => throw new();
    }
}