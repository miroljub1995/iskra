using System.Runtime.Versioning;
using Iskra.Core.RenderRoot;
using Iskra.Ssr.Abstractions.RenderRoot;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Dom.Components;

public class OutputProps : GlobalHtmlComponentProps<HTMLOutputElement>
{
    public IReadOnlySignal<string>? HtmlFor { get; init; }
    public IReadOnlySignal<string>? Name { get; init; }
    public IReadOnlySignal<string>? DefaultValue { get; init; }
    public IReadOnlySignal<string>? Value { get; init; }

    [SupportedOSPlatform("browser")]
    protected internal override void RegisterClientEffects(Action<Action<HTMLOutputElement>> register)
    {
        base.RegisterClientEffects(register);

        if (HtmlFor != null)
        {
            register(el => el.HtmlFor.Value = HtmlFor.Value);
        }

        if (Name != null)
        {
            register(el => el.Name = Name.Value);
        }

        if (DefaultValue != null)
        {
            register(el => el.DefaultValue = DefaultValue.Value);
        }

        if (Value != null)
        {
            register(el => el.Value = Value.Value);
        }
    }

    protected internal override void RegisterServerEffects(SsrElementNode el)
    {
        base.RegisterServerEffects(el);

        if (HtmlFor != null)
        {
            el.SetAttribute("for", HtmlFor);
        }

        if (Name != null)
        {
            el.SetAttribute("name", Name);
        }

        if (DefaultValue != null)
        {
            el.SetAttribute("value", DefaultValue);
        }

        if (Value != null)
        {
            el.SetAttribute("value", Value);
        }
    }
}

public class OutputEvents : HtmlElementComponentEvents<HTMLOutputElement>
{
}

public class Output() : BaseNonVoidDomComponent<HTMLOutputElement, OutputProps, OutputEvents>("output")
{
}
