using System.Runtime.Versioning;
using Iskra.Core.RenderRoot;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class BlockquoteProps : GlobalHtmlComponentProps<HTMLQuoteElement>
{
    public IReadOnlySignal<string>? Cite { get; init; }

    [SupportedOSPlatform("browser")]
    protected internal override void RegisterClientEffects(Action<Action<HTMLQuoteElement>> register)
    {
        base.RegisterClientEffects(register);

        if (Cite != null)
        {
            register(el => el.Cite = Cite.Value);
        }
    }

    protected internal override void RegisterServerEffects(Action<Action<SsrElementNode>> register)
    {
        base.RegisterServerEffects(register);

        if (Cite != null)
        {
            register(el => el.SetAttribute("cite", Cite.Value));
        }
    }
}

public class BlockquoteEvents : HtmlElementComponentEvents<HTMLQuoteElement>
{
}

public class Blockquote() : BaseNonVoidDomComponent<HTMLQuoteElement, BlockquoteProps, BlockquoteEvents>("blockquote")
{
}
