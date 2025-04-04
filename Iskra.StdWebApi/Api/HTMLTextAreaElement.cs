using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebApi.Api;

[GenerateBindings]
[AddToGlobalFactory]
public class HTMLTextAreaElement : HTMLElement
{
    protected HTMLTextAreaElement() => throw new();

    public string Value
    {
        get => throw new();
        set => throw new();
    }
}