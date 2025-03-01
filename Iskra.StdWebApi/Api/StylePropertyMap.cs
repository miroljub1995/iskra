using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebApi.Api;

[GenerateBindings]
[AddToGlobalFactory]
public class StylePropertyMap : StylePropertyMapReadOnly
{
    protected StylePropertyMap() => throw new();
}