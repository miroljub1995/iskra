using System.Runtime.Versioning;
using Iskra.Core.RenderRoot;
using Iskra.Ssr.Abstractions.RenderRoot;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Dom.Components;

public class TrackProps : GlobalHtmlComponentProps<HTMLTrackElement>
{
    public IReadOnlySignal<string>? Kind { get; init; }
    public IReadOnlySignal<string>? Src { get; init; }
    public IReadOnlySignal<string>? Srclang { get; init; }
    public IReadOnlySignal<string>? Label { get; init; }
    public IReadOnlySignal<bool>? Default { get; init; }

    [SupportedOSPlatform("browser")]
    protected internal override void RegisterClientEffects(Action<Action<HTMLTrackElement>> register)
    {
        base.RegisterClientEffects(register);

        if (Kind != null)
        {
            register(el => el.Kind = Kind.Value);
        }

        if (Src != null)
        {
            register(el => el.Src = Src.Value);
        }

        if (Srclang != null)
        {
            register(el => el.Srclang = Srclang.Value);
        }

        if (Label != null)
        {
            register(el => el.Label = Label.Value);
        }

        if (Default != null)
        {
            register(el => el.Default = Default.Value);
        }
    }

    protected internal override void RegisterServerEffects(SsrElementNode el)
    {
        base.RegisterServerEffects(el);

        if (Kind != null)
        {
            el.SetAttribute("kind", Kind);
        }

        if (Src != null)
        {
            el.SetAttribute("src", Src);
        }

        if (Srclang != null)
        {
            el.SetAttribute("srclang", Srclang);
        }

        if (Label != null)
        {
            el.SetAttribute("label", Label);
        }

        if (Default != null)
        {
            el.SetBoolean("default", Default);
        }
    }
}

public class TrackEvents : HtmlElementComponentEvents<HTMLTrackElement>
{
}

public class Track() : BaseVoidDomComponent<HTMLTrackElement, TrackProps, TrackEvents>("track")
{
}
