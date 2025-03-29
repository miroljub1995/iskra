using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebApi.Api;

[GenerateBindings]
[IsPlainJSObject]
public class ElementGetHTMLOptions
{
    public bool? SerializableShadowRoots
    {
        get => throw new();
        set => throw new();
    }

    public IReadOnlyList<ShadowRoot>? ShadowRoots
    {
        get => throw new();
        set => throw new();
    }
}