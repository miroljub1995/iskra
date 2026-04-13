using System.Runtime.Versioning;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

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
}

public class LabelEvents : HtmlElementComponentEvents<HTMLLabelElement>
{
}

public class Label() : BaseNonVoidDomComponent<HTMLLabelElement, LabelProps, LabelEvents>("label")
{
}
