using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebApi.Api;

[GenerateBindings]
[AddToGlobalFactory]
public class HTMLTemplateElement : HTMLElement
{
    protected HTMLTemplateElement() => throw new();

    public DocumentFragment Content
    {
        get => throw new();
    }

    public string ShadowRootMode
    {
        get => throw new();
        set => throw new();
    }

    public bool ShadowRootDelegatesFocus
    {
        get => throw new();
        set => throw new();
    }

    public bool ShadowRootClonable
    {
        get => throw new();
        set => throw new();
    }

    public bool ShadowRootSerializable
    {
        get => throw new();
        set => throw new();
    }
}