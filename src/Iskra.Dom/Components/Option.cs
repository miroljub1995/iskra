using System.Runtime.Versioning;
using Iskra.Core.RenderRoot;
using Iskra.Ssr.Abstractions.RenderRoot;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Dom.Components;

public class OptionProps : GlobalHtmlComponentProps<HTMLOptionElement>
{
    public IReadOnlySignal<bool>? Disabled { get; init; }
    public IReadOnlySignal<string>? Label { get; init; }
    public IReadOnlySignal<bool>? DefaultSelected { get; init; }
    public IReadOnlySignal<bool>? Selected { get; init; }
    public IReadOnlySignal<string>? Value { get; init; }

    [SupportedOSPlatform("browser")]
    protected internal override void RegisterClientEffects(Action<Action<HTMLOptionElement>> register)
    {
        base.RegisterClientEffects(register);

        if (Disabled != null)
        {
            register(el => el.Disabled = Disabled.Value);
        }

        if (Label != null)
        {
            register(el => el.Label = Label.Value);
        }

        if (DefaultSelected != null)
        {
            register(el => el.DefaultSelected = DefaultSelected.Value);
        }

        if (Selected != null)
        {
            register(el => el.Selected = Selected.Value);
        }

        if (Value != null)
        {
            register(el => el.Value = Value.Value);
        }
    }

    protected internal override void RegisterServerEffects(SsrElementNode el)
    {
        base.RegisterServerEffects(el);

        if (Disabled != null)
        {
            el.SetBoolean("disabled", Disabled);
        }

        if (Label != null)
        {
            el.SetAttribute("label", Label);
        }

        if (DefaultSelected != null)
        {
            el.SetBoolean("selected", DefaultSelected);
        }

        if (Selected != null)
        {
            el.SetBoolean("selected", Selected);
        }

        if (Value != null)
        {
            el.SetAttribute("value", Value);
        }
    }
}

public class OptionEvents : HtmlElementComponentEvents<HTMLOptionElement>
{
}

public class Option() : BaseNonVoidDomComponent<HTMLOptionElement, OptionProps, OptionEvents>("option")
{
}
