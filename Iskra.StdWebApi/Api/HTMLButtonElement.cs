using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebApi.Api;

[GenerateBindings]
[AddToGlobalFactory]
public class HTMLButtonElement : HTMLElement
{
    protected HTMLButtonElement() => throw new();
}