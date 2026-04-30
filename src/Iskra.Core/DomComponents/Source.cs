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

    protected internal override void RegisterServerEffects(Action<Action<SsrElementNode>> register)
    {
        base.RegisterServerEffects(register);

        if (Src != null)
        {
            register(el => el.SetAttribute("src", Src.Value));
        }

        if (Type != null)
        {
            register(el => el.SetAttribute("type", Type.Value));
        }

        if (Srcset != null)
        {
            register(el => el.SetAttribute("srcset", Srcset.Value));
        }

        if (Sizes != null)
        {
            register(el => el.SetAttribute("sizes", Sizes.Value));
        }

        if (Media != null)
        {
            register(el => el.SetAttribute("media", Media.Value));
        }

        if (Width != null)
        {
            register(el => SsrAttributes.SetUInt(el, "width", Width.Value));
        }

        if (Height != null)
        {
            register(el => SsrAttributes.SetUInt(el, "height", Height.Value));
        }
    }
}

public class SourceEvents : HtmlElementComponentEvents<HTMLSourceElement>
{
}

public class Source() : BaseVoidDomComponent<HTMLSourceElement, SourceProps, SourceEvents>("source")
{
}
