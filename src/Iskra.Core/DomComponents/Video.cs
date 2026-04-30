using System.Runtime.Versioning;
using Iskra.Core.RenderRoot;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class VideoProps : GlobalHtmlComponentProps<HTMLVideoElement>
{
    public IReadOnlySignal<string>? Src { get; init; }
    public IReadOnlySignal<bool>? Autoplay { get; init; }
    public IReadOnlySignal<bool>? Controls { get; init; }
    public IReadOnlySignal<bool>? Loop { get; init; }
    public IReadOnlySignal<bool>? Muted { get; init; }
    public IReadOnlySignal<string>? Preload { get; init; }
    public IReadOnlySignal<string?>? CrossOrigin { get; init; }
    public IReadOnlySignal<string>? Poster { get; init; }
    public IReadOnlySignal<bool>? PlaysInline { get; init; }
    public IReadOnlySignal<uint>? Width { get; init; }
    public IReadOnlySignal<uint>? Height { get; init; }
    public IReadOnlySignal<bool>? DisablePictureInPicture { get; init; }
    public IReadOnlySignal<bool>? DisableRemotePlayback { get; init; }

    [SupportedOSPlatform("browser")]
    protected internal override void RegisterClientEffects(Action<Action<HTMLVideoElement>> register)
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

        if (Poster != null)
        {
            register(el => el.Poster = Poster.Value);
        }

        if (PlaysInline != null)
        {
            register(el => el.PlaysInline = PlaysInline.Value);
        }

        if (Width != null)
        {
            register(el => el.Width = Width.Value);
        }

        if (Height != null)
        {
            register(el => el.Height = Height.Value);
        }

        if (DisablePictureInPicture != null)
        {
            register(el => el.DisablePictureInPicture = DisablePictureInPicture.Value);
        }

        if (DisableRemotePlayback != null)
        {
            register(el => el.DisableRemotePlayback = DisableRemotePlayback.Value);
        }
    }

    protected internal override void RegisterServerEffects(Action<Action<SsrElementNode>> register)
    {
        base.RegisterServerEffects(register);

        if (Src != null)
        {
            register(el => el.SetAttribute("src", Src.Value));
        }

        if (Autoplay != null)
        {
            register(el => SsrAttributes.SetBoolean(el, "autoplay", Autoplay.Value));
        }

        if (Controls != null)
        {
            register(el => SsrAttributes.SetBoolean(el, "controls", Controls.Value));
        }

        if (Loop != null)
        {
            register(el => SsrAttributes.SetBoolean(el, "loop", Loop.Value));
        }

        if (Muted != null)
        {
            register(el => SsrAttributes.SetBoolean(el, "muted", Muted.Value));
        }

        if (Preload != null)
        {
            register(el => el.SetAttribute("preload", Preload.Value));
        }

        if (CrossOrigin != null)
        {
            register(el => SsrAttributes.SetNullableString(el, "crossorigin", CrossOrigin.Value));
        }

        if (Poster != null)
        {
            register(el => el.SetAttribute("poster", Poster.Value));
        }

        if (PlaysInline != null)
        {
            register(el => SsrAttributes.SetBoolean(el, "playsinline", PlaysInline.Value));
        }

        if (Width != null)
        {
            register(el => SsrAttributes.SetUInt(el, "width", Width.Value));
        }

        if (Height != null)
        {
            register(el => SsrAttributes.SetUInt(el, "height", Height.Value));
        }

        if (DisablePictureInPicture != null)
        {
            register(el => SsrAttributes.SetBoolean(el, "disablepictureinpicture", DisablePictureInPicture.Value));
        }

        if (DisableRemotePlayback != null)
        {
            register(el => SsrAttributes.SetBoolean(el, "disableremoteplayback", DisableRemotePlayback.Value));
        }
    }
}

public class VideoEvents : HtmlElementComponentEvents<HTMLVideoElement>
{
}

public class Video() : BaseNonVoidDomComponent<HTMLVideoElement, VideoProps, VideoEvents>("video")
{
}
