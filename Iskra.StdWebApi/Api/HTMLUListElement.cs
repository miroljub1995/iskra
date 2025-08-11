using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebApi.Api;

[GenerateBindings]
[AddToGlobalFactory]
public class HTMLUListElement : HTMLElement
{
    protected HTMLUListElement() => throw new();
}