using System.Runtime.Versioning;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class TdProps : GlobalHtmlComponentProps<HTMLTableCellElement>
{
    public IReadOnlySignal<uint>? ColSpan { get; init; }
    public IReadOnlySignal<uint>? RowSpan { get; init; }
    public IReadOnlySignal<string>? Headers { get; init; }

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
    }
}

public class TdEvents : HtmlElementComponentEvents<HTMLTableCellElement>
{
}

public class Td() : BaseNonVoidDomComponent<HTMLTableCellElement, TdProps, TdEvents>("td")
{
}
