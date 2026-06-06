using System.Runtime.Versioning;
using Iskra.Core.RenderRoot;
using Iskra.Ssr.Abstractions.RenderRoot;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Dom.Components;

public class LabelProps : GlobalHtmlComponentProps<HTMLLabelElement>
{
    public IReadOnlySignal<string>? HtmlFor { get; init; }

    [SupportedOSPlatform("browser")]
    protected internal override void RegisterClientEffects(Action<Action<HTMLLabelElement>> register)
    {
        base.RegisterClientEffects(register);

        if (HtmlFor != null)
        {
            register(el => el.HtmlFor = HtmlFor.Value);
        }
    }

    protected internal override void RegisterServerEffects(SsrElementNode el)
    {
        base.RegisterServerEffects(el);

        if (HtmlFor != null)
        {
            el.SetAttribute("for", HtmlFor);
        }
    }
}

public class LabelEvents : HtmlElementComponentEvents<HTMLLabelElement>
{
}

public class Label() : BaseNonVoidDomComponent<HTMLLabelElement, LabelProps, LabelEvents>("label")
{
}
