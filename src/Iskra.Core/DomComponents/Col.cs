using System.Runtime.Versioning;
using Iskra.Core.RenderRoot;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class ColProps : GlobalHtmlComponentProps<HTMLTableColElement>
{
    public IReadOnlySignal<uint>? Span { get; init; }

    [SupportedOSPlatform("browser")]
    protected internal override void RegisterClientEffects(Action<Action<HTMLTableColElement>> register)
    {
        base.RegisterClientEffects(register);

        if (Span != null)
        {
            register(el => el.Span = Span.Value);
        }
    }

    protected internal override void RegisterServerEffects(SsrElementNode el)
    {
        base.RegisterServerEffects(el);

        if (Span != null)
        {
            el.SetUInt("span", Span);
        }
    }
}

public class ColEvents : HtmlElementComponentEvents<HTMLTableColElement>
{
}

public class Col() : BaseVoidDomComponent<HTMLTableColElement, ColProps, ColEvents>("col")
{
}
