using System.Runtime.Versioning;
using Iskra.Core.RenderRoot;
using Iskra.Ssr.Abstractions.RenderRoot;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Dom.Components;

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

        if (Poster != null)
        {
            el.SetAttribute("poster", Poster);
        }

        if (PlaysInline != null)
        {
            el.SetBoolean("playsinline", PlaysInline);
        }

        if (Width != null)
        {
            el.SetUInt("width", Width);
        }

        if (Height != null)
        {
            el.SetUInt("height", Height);
        }

        if (DisablePictureInPicture != null)
        {
            el.SetBoolean("disablepictureinpicture", DisablePictureInPicture);
        }

        if (DisableRemotePlayback != null)
        {
            el.SetBoolean("disableremoteplayback", DisableRemotePlayback);
        }
    }
}

public class VideoEvents : HtmlElementComponentEvents<HTMLVideoElement>
{
}

public class Video() : BaseNonVoidDomComponent<HTMLVideoElement, VideoProps, VideoEvents>("video")
{
}
