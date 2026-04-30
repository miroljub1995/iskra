using System.Runtime.Versioning;
using Iskra.Core.RenderRoot;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class CanvasProps : GlobalHtmlComponentProps<HTMLCanvasElement>
{
    public IReadOnlySignal<uint>? Width { get; init; }
    public IReadOnlySignal<uint>? Height { get; init; }

    [SupportedOSPlatform("browser")]
    protected internal override void RegisterClientEffects(Action<Action<HTMLCanvasElement>> register)
    {
        base.RegisterClientEffects(register);

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

public class CanvasEvents : HtmlElementComponentEvents<HTMLCanvasElement>
{
}

public class Canvas() : BaseNonVoidDomComponent<HTMLCanvasElement, CanvasProps, CanvasEvents>("canvas")
{
}
