using System.Runtime.Versioning;
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
}

public class ColEvents : HtmlElementComponentEvents<HTMLTableColElement>
{
}

public class Col() : BaseVoidDomComponent<HTMLTableColElement, ColProps, ColEvents>("col")
{
}
