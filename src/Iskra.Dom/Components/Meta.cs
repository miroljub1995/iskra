using System.Runtime.Versioning;
using Iskra.Core.RenderRoot;
using Iskra.Ssr.Abstractions.RenderRoot;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Dom.Components;

public class MetaProps : GlobalHtmlComponentProps<HTMLMetaElement>
{
    public IReadOnlySignal<string>? Name { get; init; }
    public IReadOnlySignal<string>? HttpEquiv { get; init; }
    public IReadOnlySignal<string>? Content { get; init; }
    public IReadOnlySignal<string>? Media { get; init; }

    [SupportedOSPlatform("browser")]
    protected internal override void RegisterClientEffects(Action<Action<HTMLMetaElement>> register)
    {
        base.RegisterClientEffects(register);

        if (Name != null)
        {
            register(el => el.Name = Name.Value);
        }

        if (HttpEquiv != null)
        {
            register(el => el.HttpEquiv = HttpEquiv.Value);
        }

        if (Content != null)
        {
            register(el => el.Content = Content.Value);
        }

        if (Media != null)
        {
            register(el => el.Media = Media.Value);
        }
    }

    protected internal override void RegisterServerEffects(SsrElementNode el)
    {
        base.RegisterServerEffects(el);

        if (Name != null)
        {
            el.SetAttribute("name", Name);
        }

        if (HttpEquiv != null)
        {
            el.SetAttribute("http-equiv", HttpEquiv);
        }

        if (Content != null)
        {
            el.SetAttribute("content", Content);
        }

        if (Media != null)
        {
            el.SetAttribute("media", Media);
        }
    }
}

public class MetaEvents : HtmlElementComponentEvents<HTMLMetaElement>
{
}

public class Meta() : BaseVoidDomComponent<HTMLMetaElement, MetaProps, MetaEvents>("meta")
{
}
