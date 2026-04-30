using System.Runtime.Versioning;
using Iskra.Core.RenderRoot;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

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

    protected internal override void RegisterServerEffects(Action<Action<SsrElementNode>> register)
    {
        base.RegisterServerEffects(register);

        if (HtmlFor != null)
        {
            register(el => el.SetAttribute("for", HtmlFor.Value));
        }

        if (Name != null)
        {
            register(el => el.SetAttribute("name", Name.Value));
        }

        if (DefaultValue != null)
        {
            register(el => el.SetAttribute("value", DefaultValue.Value));
        }

        if (Value != null)
        {
            register(el => el.SetAttribute("value", Value.Value));
        }
    }
}

public class OutputEvents : HtmlElementComponentEvents<HTMLOutputElement>
{
}

public class Output() : BaseNonVoidDomComponent<HTMLOutputElement, OutputProps, OutputEvents>("output")
{
}
