using System.Runtime.Versioning;
using Iskra.Core.RenderRoot;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class LinkProps : GlobalHtmlComponentProps<HTMLLinkElement>
{
    public IReadOnlySignal<string>? Href { get; init; }
    public IReadOnlySignal<string?>? CrossOrigin { get; init; }
    public IReadOnlySignal<string>? Rel { get; init; }
    public IReadOnlySignal<string>? As { get; init; }
    public IReadOnlySignal<string>? Media { get; init; }
    public IReadOnlySignal<string>? Integrity { get; init; }
    public IReadOnlySignal<string>? Hreflang { get; init; }
    public IReadOnlySignal<string>? Type { get; init; }
    public IReadOnlySignal<string>? ReferrerPolicy { get; init; }
    public IReadOnlySignal<bool>? Disabled { get; init; }
    public IReadOnlySignal<string>? FetchPriority { get; init; }
    public IReadOnlySignal<string>? Blocking { get; init; }
    public IReadOnlySignal<string>? ImageSizes { get; init; }
    public IReadOnlySignal<string>? ImageSrcset { get; init; }

    [SupportedOSPlatform("browser")]
    protected internal override void RegisterClientEffects(Action<Action<HTMLLinkElement>> register)
    {
        base.RegisterClientEffects(register);

        if (Href != null)
        {
            register(el => el.Href = Href.Value);
        }

        if (CrossOrigin != null)
        {
            register(el => el.CrossOrigin = CrossOrigin.Value);
        }

        if (Rel != null)
        {
            register(el => el.Rel = Rel.Value);
        }

        if (As != null)
        {
            register(el => el.As = As.Value);
        }

        if (Media != null)
        {
            register(el => el.Media = Media.Value);
        }

        if (Integrity != null)
        {
            register(el => el.Integrity = Integrity.Value);
        }

        if (Hreflang != null)
        {
            register(el => el.Hreflang = Hreflang.Value);
        }

        if (Type != null)
        {
            register(el => el.Type = Type.Value);
        }

        if (ReferrerPolicy != null)
        {
            register(el => el.ReferrerPolicy = ReferrerPolicy.Value);
        }

        if (Disabled != null)
        {
            register(el => el.Disabled = Disabled.Value);
        }

        if (FetchPriority != null)
        {
            register(el => el.FetchPriority = FetchPriority.Value);
        }

        if (Blocking != null)
        {
            register(el => el.Blocking.Value = Blocking.Value);
        }

        if (ImageSizes != null)
        {
            register(el => el.ImageSizes = ImageSizes.Value);
        }

        if (ImageSrcset != null)
        {
            register(el => el.ImageSrcset = ImageSrcset.Value);
        }
    }

    protected internal override void RegisterServerEffects(Action<Action<SsrElementNode>> register)
    {
        base.RegisterServerEffects(register);

        if (Href != null)
        {
            register(el => el.SetAttribute("href", Href.Value));
        }

        if (CrossOrigin != null)
        {
            register(el => SsrAttributes.SetNullableString(el, "crossorigin", CrossOrigin.Value));
        }

        if (Rel != null)
        {
            register(el => el.SetAttribute("rel", Rel.Value));
        }

        if (As != null)
        {
            register(el => el.SetAttribute("as", As.Value));
        }

        if (Media != null)
        {
            register(el => el.SetAttribute("media", Media.Value));
        }

        if (Integrity != null)
        {
            register(el => el.SetAttribute("integrity", Integrity.Value));
        }

        if (Hreflang != null)
        {
            register(el => el.SetAttribute("hreflang", Hreflang.Value));
        }

        if (Type != null)
        {
            register(el => el.SetAttribute("type", Type.Value));
        }

        if (ReferrerPolicy != null)
        {
            register(el => el.SetAttribute("referrerpolicy", ReferrerPolicy.Value));
        }

        if (Disabled != null)
        {
            register(el => SsrAttributes.SetBoolean(el, "disabled", Disabled.Value));
        }

        if (FetchPriority != null)
        {
            register(el => el.SetAttribute("fetchpriority", FetchPriority.Value));
        }

        if (Blocking != null)
        {
            register(el => el.SetAttribute("blocking", Blocking.Value));
        }

        if (ImageSizes != null)
        {
            register(el => el.SetAttribute("imagesizes", ImageSizes.Value));
        }

        if (ImageSrcset != null)
        {
            register(el => el.SetAttribute("imagesrcset", ImageSrcset.Value));
        }
    }
}

public class LinkEvents : HtmlElementComponentEvents<HTMLLinkElement>
{
}

public class Link() : BaseVoidDomComponent<HTMLLinkElement, LinkProps, LinkEvents>("link")
{
}
