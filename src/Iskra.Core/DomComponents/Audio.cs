using System.Runtime.Versioning;
using Iskra.Core.RenderRoot;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class AudioProps : GlobalHtmlComponentProps<HTMLAudioElement>
{
    public IReadOnlySignal<string>? Src { get; init; }
    public IReadOnlySignal<bool>? Autoplay { get; init; }
    public IReadOnlySignal<bool>? Controls { get; init; }
    public IReadOnlySignal<bool>? Loop { get; init; }
    public IReadOnlySignal<bool>? Muted { get; init; }
    public IReadOnlySignal<string>? Preload { get; init; }
    public IReadOnlySignal<string?>? CrossOrigin { get; init; }
    public IReadOnlySignal<bool>? DisableRemotePlayback { get; init; }

    [SupportedOSPlatform("browser")]
    protected internal override void RegisterClientEffects(Action<Action<HTMLAudioElement>> register)
    {
        base.RegisterClientEffects(register);

        if (Src != null)
        {
            register(el => el.Src = Src.Value);
        }

        if (Autoplay != null)
        {
            register(el => el.Autoplay = Autoplay.Value);
        }

        if (Controls != null)
        {
            register(el => el.Controls = Controls.Value);
        }

        if (Loop != null)
        {
            register(el => el.Loop = Loop.Value);
        }

        if (Muted != null)
        {
            register(el => el.Muted = Muted.Value);
        }

        if (Preload != null)
        {
            register(el => el.Preload = Preload.Value);
        }

        if (CrossOrigin != null)
        {
            register(el => el.CrossOrigin = CrossOrigin.Value);
        }

        if (DisableRemotePlayback != null)
        {
            register(el => el.DisableRemotePlayback = DisableRemotePlayback.Value);
        }
    }

    protected internal override void RegisterServerEffects(SsrElementNode el)
    {
        base.RegisterServerEffects(el);

        if (Src != null)
        {
            el.SetAttribute("src", Src);
        }

        if (Autoplay != null)
        {
            el.SetBoolean("autoplay", Autoplay);
        }

        if (Controls != null)
        {
            el.SetBoolean("controls", Controls);
        }

        if (Loop != null)
        {
            el.SetBoolean("loop", Loop);
        }

        if (Muted != null)
        {
            el.SetBoolean("muted", Muted);
        }

        if (Preload != null)
        {
            el.SetAttribute("preload", Preload);
        }

        if (CrossOrigin != null)
        {
            el.SetNullableString("crossorigin", CrossOrigin);
        }

        if (DisableRemotePlayback != null)
        {
            el.SetBoolean("disableremoteplayback", DisableRemotePlayback);
        }
    }
}

public class AudioEvents : HtmlElementComponentEvents<HTMLAudioElement>
{
}

public class Audio() : BaseNonVoidDomComponent<HTMLAudioElement, AudioProps, AudioEvents>("audio")
{
}
