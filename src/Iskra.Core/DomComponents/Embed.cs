using System.Runtime.Versioning;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class EmbedProps : GlobalHtmlComponentProps<HTMLEmbedElement>
{
    public IReadOnlySignal<string>? Src { get; init; }
    public IReadOnlySignal<string>? Type { get; init; }
    public IReadOnlySignal<string>? Width { get; init; }
    public IReadOnlySignal<string>? Height { get; init; }

    [SupportedOSPlatform("browser")]
    protected internal override void RegisterClientEffects(Action<Action<HTMLEmbedElement>> register)
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

        if (Width != null)
        {
            register(el => el.Width = Width.Value);
        }

        if (Height != null)
        {
            register(el => el.Height = Height.Value);
        }
    }
}

public class EmbedEvents : HtmlElementComponentEvents<HTMLEmbedElement>
{
}

public class Embed() : BaseVoidDomComponent<HTMLEmbedElement, EmbedProps, EmbedEvents>("embed")
{
}
