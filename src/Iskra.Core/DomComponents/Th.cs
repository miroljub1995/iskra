using System.Runtime.Versioning;
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
}

public class ThEvents : HtmlElementComponentEvents<HTMLTableCellElement>
{
}

public class Th() : BaseNonVoidDomComponent<HTMLTableCellElement, ThProps, ThEvents>("th")
{
}
