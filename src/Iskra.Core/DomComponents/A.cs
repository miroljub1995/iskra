using System.Runtime.Versioning;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class AProps : GlobalHtmlComponentProps<HTMLAnchorElement>
{
    public IReadOnlySignal<string>? Href { get; init; }
    public IReadOnlySignal<string>? Target { get; init; }
    public IReadOnlySignal<string>? Rel { get; init; }
    public IReadOnlySignal<string>? Download { get; init; }
    public IReadOnlySignal<string>? Hreflang { get; init; }
    public IReadOnlySignal<string>? Ping { get; init; }
    public IReadOnlySignal<string>? ReferrerPolicy { get; init; }
    public IReadOnlySignal<string>? Type { get; init; }

    [SupportedOSPlatform("browser")]
    protected internal override void RegisterClientEffects(Action<Action<HTMLAnchorElement>> register)
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

        if (Rel != null)
        {
            register(el => el.Rel = Rel.Value);
        }

        if (Download != null)
        {
            register(el => el.Download = Download.Value);
        }

        if (Hreflang != null)
        {
            register(el => el.Hreflang = Hreflang.Value);
        }

        if (Ping != null)
        {
            register(el => el.Ping = Ping.Value);
        }

        if (ReferrerPolicy != null)
        {
            register(el => el.ReferrerPolicy = ReferrerPolicy.Value);
        }

        if (Type != null)
        {
            register(el => el.Type = Type.Value);
        }
    }
}

public class AEvents : HtmlElementComponentEvents<HTMLAnchorElement>
{
}

public class A() : BaseNonVoidDomComponent<HTMLAnchorElement, AProps, AEvents>("a")
{
}
