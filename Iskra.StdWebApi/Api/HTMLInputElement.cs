using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebApi.Api;

[GenerateBindings]
[AddToGlobalFactory]
public class HTMLInputElement : HTMLElement
{
    protected HTMLInputElement() => throw new();

    public string Value
    {
        get => throw new();
        set => throw new();
    }
}