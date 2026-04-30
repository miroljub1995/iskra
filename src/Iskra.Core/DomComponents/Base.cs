using System.Runtime.Versioning;
using Iskra.Core.RenderRoot;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class BaseProps : GlobalHtmlComponentProps<HTMLBaseElement>
{
    public IReadOnlySignal<string>? Href { get; init; }
    public IReadOnlySignal<string>? Target { get; init; }

    [SupportedOSPlatform("browser")]
    protected internal override void RegisterClientEffects(Action<Action<HTMLBaseElement>> register)
    {
        base.RegisterClientEffects(register);

        if (Href != null)
        {
            register(el => el.Href = Href.Value);
        }

        if (Target != null)
        {
            register(el => el.Target = Target.Value);
        }
    }

    protected internal override void RegisterServerEffects(Action<Action<SsrElementNode>> register)
    {
        base.RegisterServerEffects(register);

        if (Href != null)
        {
            register(el => el.SetAttribute("href", Href.Value));
        }

        if (Target != null)
        {
            register(el => el.SetAttribute("target", Target.Value));
        }
    }
}

public class BaseEvents : HtmlElementComponentEvents<HTMLBaseElement>
{
}

public class Base() : BaseVoidDomComponent<HTMLBaseElement, BaseProps, BaseEvents>("base")
{
}
