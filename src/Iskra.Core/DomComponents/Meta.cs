using System.Runtime.Versioning;
using Iskra.Core.RenderRoot;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

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

    protected internal override void RegisterServerEffects(Action<Action<SsrElementNode>> register)
    {
        base.RegisterServerEffects(register);

        if (Name != null)
        {
            register(el => el.SetAttribute("name", Name.Value));
        }

        if (HttpEquiv != null)
        {
            register(el => el.SetAttribute("http-equiv", HttpEquiv.Value));
        }

        if (Content != null)
        {
            register(el => el.SetAttribute("content", Content.Value));
        }

        if (Media != null)
        {
            register(el => el.SetAttribute("media", Media.Value));
        }
    }
}

public class MetaEvents : HtmlElementComponentEvents<HTMLMetaElement>
{
}

public class Meta() : BaseVoidDomComponent<HTMLMetaElement, MetaProps, MetaEvents>("meta")
{
}
