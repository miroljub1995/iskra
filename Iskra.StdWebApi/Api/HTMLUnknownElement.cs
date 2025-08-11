using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebApi.Api;

[GenerateBindings]
[AddToGlobalFactory]
public class HTMLUnknownElement : HTMLElement
{
    protected HTMLUnknownElement() => throw new();
}