using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebApi.Api;

[GenerateBindings]
[AddToGlobalFactory]
public class HTMLFormElement : HTMLElement
{
    protected HTMLFormElement() => throw new();
}