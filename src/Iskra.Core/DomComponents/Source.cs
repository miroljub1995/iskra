using System.Runtime.Versioning;
using Iskra.Core.RenderRoot;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class SourceProps : GlobalHtmlComponentProps<HTMLSourceElement>
{
    public IReadOnlySignal<string>? Src { get; init; }
    public IReadOnlySignal<string>? Type { get; init; }
    public IReadOnlySignal<string>? Srcset { get; init; }
    public IReadOnlySignal<string>? Sizes { get; init; }
    public IReadOnlySignal<string>? Media { get; init; }
    public IReadOnlySignal<uint>? Width { get; init; }
    public IReadOnlySignal<uint>? Height { get; init; }

    [SupportedOSPlatform("browser")]
    protected internal override void RegisterClientEffects(Action<Action<HTMLSourceElement>> register)
    {
        base.RegisterClientEffects(register);

        if (Src != null)
        {
            register(el => el.Src = Src.Value);
        }

        if (Type != null)
        {
            register(el => el.Type = Type.Value);
        }

        if (Srcset != null)
        {
            register(el => el.Srcset = Srcset.Value);
        }

        if (Sizes != null)
        {
            register(el => el.Sizes = Sizes.Value);
        }

        if (Media != null)
        {
            register(el => el.Media = Media.Value);
        }

        if (Width != null)
        {
            register(el => el.Width = Width.Value);
        }

        if (Height != null)
        {
            register(el => el.Height = Height.Value);
        }
    }

    protected internal override void RegisterServerEffects(SsrElementNode el)
    {
        base.RegisterServerEffects(el);

        if (Src != null)
        {
            el.SetAttribute("src", Src);
        }

        if (Type != null)
        {
            el.SetAttribute("type", Type);
        }

        if (Srcset != null)
        {
            el.SetAttribute("srcset", Srcset);
        }

        if (Sizes != null)
        {
            el.SetAttribute("sizes", Sizes);
        }

        if (Media != null)
        {
            el.SetAttribute("media", Media);
        }

        if (Width != null)
        {
            el.SetUInt("width", Width);
        }

        if (Height != null)
        {
            el.SetUInt("height", Height);
        }
    }
}

public class SourceEvents : HtmlElementComponentEvents<HTMLSourceElement>
{
}

public class Source() : BaseVoidDomComponent<HTMLSourceElement, SourceProps, SourceEvents>("source")
{
}
