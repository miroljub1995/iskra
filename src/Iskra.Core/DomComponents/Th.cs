using System.Runtime.Versioning;
using Iskra.Core.RenderRoot;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class ThProps : GlobalHtmlComponentProps<HTMLTableCellElement>
{
    public IReadOnlySignal<uint>? ColSpan { get; init; }
    public IReadOnlySignal<uint>? RowSpan { get; init; }
    public IReadOnlySignal<string>? Headers { get; init; }
    public IReadOnlySignal<string>? Scope { get; init; }
    public IReadOnlySignal<string>? Abbr { get; init; }

    [SupportedOSPlatform("browser")]
    protected internal override void RegisterClientEffects(Action<Action<HTMLTableCellElement>> register)
    {
        base.RegisterClientEffects(register);

        if (ColSpan != null)
        {
            register(el => el.ColSpan = ColSpan.Value);
        }

        if (RowSpan != null)
        {
            register(el => el.RowSpan = RowSpan.Value);
        }

        if (Headers != null)
        {
            register(el => el.Headers = Headers.Value);
        }

        if (Scope != null)
        {
            register(el => el.Scope = Scope.Value);
        }

        if (Abbr != null)
        {
            register(el => el.Abbr = Abbr.Value);
        }
    }

    protected internal override void RegisterServerEffects(SsrElementNode el)
    {
        base.RegisterServerEffects(el);

        if (ColSpan != null)
        {
            el.SetUInt("colspan", ColSpan);
        }

        if (RowSpan != null)
        {
            el.SetUInt("rowspan", RowSpan);
        }

        if (Headers != null)
        {
            el.SetAttribute("headers", Headers);
        }

        if (Scope != null)
        {
            el.SetAttribute("scope", Scope);
        }

        if (Abbr != null)
        {
            el.SetAttribute("abbr", Abbr);
        }
    }
}

public class ThEvents : HtmlElementComponentEvents<HTMLTableCellElement>
{
}

public class Th() : BaseNonVoidDomComponent<HTMLTableCellElement, ThProps, ThEvents>("th")
{
}
