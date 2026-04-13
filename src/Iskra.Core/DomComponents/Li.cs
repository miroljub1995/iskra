using System.Runtime.Versioning;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class LiProps : GlobalHtmlComponentProps<HTMLLIElement>
{
    public IReadOnlySignal<int>? Value { get; init; }

    [SupportedOSPlatform("browser")]
    protected internal override void RegisterClientEffects(Action<Action<HTMLLIElement>> register)
    {
        base.RegisterClientEffects(register);

        if (Value != null)
        {
            register(el => el.Value = Value.Value);
        }
    }
}

public class LiEvents : HtmlElementComponentEvents<HTMLLIElement>
{
}

public class Li() : BaseNonVoidDomComponent<HTMLLIElement, LiProps, LiEvents>("li")
{
}
