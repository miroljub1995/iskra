using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebApi.Api;

[GenerateBindings]
[AddToGlobalFactory]
public class HTMLTimeElement : HTMLElement
{
    protected HTMLTimeElement() => throw new();

    public string DateTime
    {
        get => throw new();
        set => throw new();
    }
}