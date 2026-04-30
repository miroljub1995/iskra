using System.Runtime.Versioning;
using Iskra.Core.RenderRoot;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class TimeProps : GlobalHtmlComponentProps<HTMLTimeElement>
{
    public IReadOnlySignal<string>? DateTime { get; init; }

    [SupportedOSPlatform("browser")]
    protected internal override void RegisterClientEffects(Action<Action<HTMLTimeElement>> register)
    {
        base.RegisterClientEffects(register);

        if (DateTime != null)
        {
            register(el => el.DateTime = DateTime.Value);
        }
    }

    protected internal override void RegisterServerEffects(Action<Action<SsrElementNode>> register)
    {
        base.RegisterServerEffects(register);

        if (DateTime != null)
        {
            register(el => el.SetAttribute("datetime", DateTime.Value));
        }
    }
}

public class TimeEvents : HtmlElementComponentEvents<HTMLTimeElement>
{
}

public class Time() : BaseNonVoidDomComponent<HTMLTimeElement, TimeProps, TimeEvents>("time")
{
}
