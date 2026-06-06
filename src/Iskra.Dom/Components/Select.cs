using System.Runtime.Versioning;
using Iskra.Core.RenderRoot;
using Iskra.Ssr.Abstractions.RenderRoot;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Dom.Components;

public class SelectProps : GlobalHtmlComponentProps<HTMLSelectElement>
{
    public IReadOnlySignal<string>? Autocomplete { get; init; }
    public IReadOnlySignal<bool>? Disabled { get; init; }
    public IReadOnlySignal<bool>? Multiple { get; init; }
    public IReadOnlySignal<string>? Name { get; init; }
    public IReadOnlySignal<bool>? Required { get; init; }
    public IReadOnlySignal<uint>? Size { get; init; }
    public IReadOnlySignal<string>? Value { get; init; }

    [SupportedOSPlatform("browser")]
    protected internal override void RegisterClientEffects(Action<Action<HTMLSelectElement>> register)
    {
        base.RegisterClientEffects(register);

        if (Autocomplete != null)
        {
            register(el => el.Autocomplete = Autocomplete.Value);
        }

        if (Disabled != null)
        {
            register(el => el.Disabled = Disabled.Value);
        }

        if (Multiple != null)
        {
            register(el => el.Multiple = Multiple.Value);
        }

        if (Name != null)
        {
            register(el => el.Name = Name.Value);
        }

        if (Required != null)
        {
            register(el => el.Required = Required.Value);
        }

        if (Size != null)
        {
            register(el => el.Size = Size.Value);
        }

        if (Value != null)
        {
            register(el => el.Value = Value.Value);
        }
    }

    protected internal override void RegisterServerEffects(SsrElementNode el)
    {
        base.RegisterServerEffects(el);

        if (Autocomplete != null)
        {
            el.SetAttribute("autocomplete", Autocomplete);
        }

        if (Disabled != null)
        {
            el.SetBoolean("disabled", Disabled);
        }

        if (Multiple != null)
        {
            el.SetBoolean("multiple", Multiple);
        }

        if (Name != null)
        {
            el.SetAttribute("name", Name);
        }

        if (Required != null)
        {
            el.SetBoolean("required", Required);
        }

        if (Size != null)
        {
            el.SetUInt("size", Size);
        }

        if (Value != null)
        {
            el.SetAttribute("value", Value);
        }
    }
}

public class SelectEvents : HtmlElementComponentEvents<HTMLSelectElement>
{
}

public class Select() : BaseNonVoidDomComponent<HTMLSelectElement, SelectProps, SelectEvents>("select")
{
}
