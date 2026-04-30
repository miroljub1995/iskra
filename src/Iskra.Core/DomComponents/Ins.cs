using System.Runtime.Versioning;
using Iskra.Core.RenderRoot;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class InsProps : GlobalHtmlComponentProps<HTMLModElement>
{
    public IReadOnlySignal<string>? Cite { get; init; }
    public IReadOnlySignal<string>? DateTime { get; init; }

    [SupportedOSPlatform("browser")]
    protected internal override void RegisterClientEffects(Action<Action<HTMLModElement>> register)
    {
        base.RegisterClientEffects(register);

        if (Cite != null)
        {
            register(el => el.Cite = Cite.Value);
        }

        if (DateTime != null)
        {
            register(el => el.DateTime = DateTime.Value);
        }
    }

    protected internal override void RegisterServerEffects(Action<Action<SsrElementNode>> register)
    {
        base.RegisterServerEffects(register);

        if (Cite != null)
        {
            register(el => el.SetAttribute("cite", Cite.Value));
        }

        if (DateTime != null)
        {
            register(el => el.SetAttribute("datetime", DateTime.Value));
        }
    }
}

public class InsEvents : HtmlElementComponentEvents<HTMLModElement>
{
}

public class Ins() : BaseNonVoidDomComponent<HTMLModElement, InsProps, InsEvents>("ins")
{
}
