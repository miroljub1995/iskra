using System.Runtime.Versioning;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class DelProps : GlobalHtmlComponentProps<HTMLModElement>
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
}

public class DelEvents : HtmlElementComponentEvents<HTMLModElement>
{
}

public class Del() : BaseNonVoidDomComponent<HTMLModElement, DelProps, DelEvents>("del")
{
}
