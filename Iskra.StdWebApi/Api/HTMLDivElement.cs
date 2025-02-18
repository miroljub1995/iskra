using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebApi.Api;

[GenerateBindings]
[AddToGlobalFactory]
public class HTMLDivElement : HTMLElement
{
    protected HTMLDivElement() => throw new();
}