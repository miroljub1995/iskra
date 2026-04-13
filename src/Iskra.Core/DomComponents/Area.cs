using System.Runtime.Versioning;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class AreaProps : GlobalHtmlComponentProps<HTMLAreaElement>
{
    public IReadOnlySignal<string>? Alt { get; init; }
    public IReadOnlySignal<string>? Coords { get; init; }
    public IReadOnlySignal<string>? Shape { get; init; }
    public IReadOnlySignal<string>? Href { get; init; }
    public IReadOnlySignal<string>? Target { get; init; }
    public IReadOnlySignal<string>? Download { get; init; }
    public IReadOnlySignal<string>? Ping { get; init; }
    public IReadOnlySignal<string>? Rel { get; init; }
    public IReadOnlySignal<string>? ReferrerPolicy { get; init; }

    [SupportedOSPlatform("browser")]
    protected internal override void RegisterClientEffects(Action<Action<HTMLAreaElement>> register)
    {
        base.RegisterClientEffects(register);

        if (Alt != null)
        {
            register(el => el.Alt = Alt.Value);
        }

        if (Coords != null)
        {
            register(el => el.Coords = Coords.Value);
        }

        if (Shape != null)
        {
            register(el => el.Shape = Shape.Value);
        }

        if (Href != null)
        {
            register(el => el.Href = Href.Value);
        }

        if (Target != null)
        {
            register(el => el.Target = Target.Value);
        }

        if (Download != null)
        {
            register(el => el.Download = Download.Value);
        }

        if (Ping != null)
        {
            register(el => el.Ping = Ping.Value);
        }

        if (Rel != null)
        {
            register(el => el.Rel = Rel.Value);
        }

        if (ReferrerPolicy != null)
        {
            register(el => el.ReferrerPolicy = ReferrerPolicy.Value);
        }
    }
}

public class AreaEvents : HtmlElementComponentEvents<HTMLAreaElement>
{
}

public class Area() : BaseVoidDomComponent<HTMLAreaElement, AreaProps, AreaEvents>("area")
{
}
