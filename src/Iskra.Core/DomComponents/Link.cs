using System.Runtime.Versioning;
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
}

public class LinkEvents : HtmlElementComponentEvents<HTMLLinkElement>
{
}

public class Link() : BaseVoidDomComponent<HTMLLinkElement, LinkProps, LinkEvents>("link")
{
}
