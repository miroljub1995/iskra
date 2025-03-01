using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebApi.Api;

[GenerateBindings]
[AddToGlobalFactory]
public class HTMLElement : Element
{
    protected HTMLElement() => throw new();

    public string AccessKey
    {
        get => throw new();
        set => throw new();
    }

    public string AccessKeyLabel
    {
        get => throw new();
    }

    public StylePropertyMap AttributeStyleMap
    {
        get => throw new();
    }

    public string Autocapitalize
    {
        get => throw new();
        set => throw new();
    }

    public bool Autofocus
    {
        get => throw new();
        set => throw new();
    }

    public bool Autocorrect
    {
        get => throw new();
        set => throw new();
    }

    public bool ContentEditable
    {
        get => throw new();
        set => throw new();
    }

    public DOMStringMap Dataset
    {
        get => throw new();
    }

    public string Dir
    {
        get => throw new();
        set => throw new();
    }

    public bool Draggable
    {
        get => throw new();
        set => throw new();
    }

    // editContext

    public string EnterKeyHint
    {
        get => throw new();
        set => throw new();
    }

    public OneOf<string, bool> Hidden
    {
        get => throw new();
        set => throw new();
    }

    public bool Inert
    {
        get => throw new();
        set => throw new();
    }

    public string InnerText
    {
        get => throw new();
        set => throw new();
    }

    public string InputMode
    {
        get => throw new();
        set => throw new();
    }

    public bool IsContentEditable
    {
        get => throw new();
        set => throw new();
    }

    public string Lang
    {
        get => throw new();
        set => throw new();
    }

    public string Nonce
    {
        get => throw new();
        set => throw new();
    }

    public double OffsetHeight
    {
        get => throw new();
    }

    public double OffsetLeft
    {
        get => throw new();
    }

    public double OffsetParent
    {
        get => throw new();
    }

    public double OffsetTop
    {
        get => throw new();
    }

    public double OffsetWidth
    {
        get => throw new();
    }

    public string OuterText
    {
        get => throw new();
        set => throw new();
    }

    public string Popover
    {
        get => throw new();
        set => throw new();
    }

    public bool Spellcheck
    {
        get => throw new();
        set => throw new();
    }

    public CSSStyleDeclaration Style
    {
        get => throw new();
        set => throw new();
    }

    public long TabIndex
    {
        get => throw new();
        set => throw new();
    }

    public string Title
    {
        get => throw new();
        set => throw new();
    }

    public bool Translate
    {
        get => throw new();
        set => throw new();
    }

    // virtualKeyboardPolicy

    public string WritingSuggestions
    {
        get => throw new();
        set => throw new();
    }

    public ElementInternals AttachInternals() => throw new();

    public void Blur() => throw new();

    public void Click() => throw new();

    public void Focus(HTMLElementFocusOptions? options) => throw new();

    public void HidePopover() => throw new();

    public void ShowPopover(HTMLElementShowPopoverOptions? options) => throw new();

    public bool TogglePopover() => throw new();

    public bool TogglePopover(bool force) => throw new();
    
    public bool TogglePopover(HTMLElementTogglePopoverOptions options) => throw new();
}