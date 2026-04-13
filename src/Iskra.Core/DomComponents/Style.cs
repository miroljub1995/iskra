using System.Runtime.Versioning;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class StyleProps : GlobalHtmlComponentProps<HTMLStyleElement>
{
    public IReadOnlySignal<bool>? Disabled { get; init; }
    public IReadOnlySignal<string>? Media { get; init; }
    public IReadOnlySignal<string>? Blocking { get; init; }

    [SupportedOSPlatform("browser")]
    protected internal override void RegisterClientEffects(Action<Action<HTMLStyleElement>> register)
    {
        base.RegisterClientEffects(register);

        if (Disabled != null)
        {
            register(el => el.Disabled = Disabled.Value);
        }

        if (Media != null)
        {
            register(el => el.Media = Media.Value);
        }

        if (Blocking != null)
        {
            register(el => el.Blocking.Value = Blocking.Value);
        }
    }
}

public class StyleEvents : HtmlElementComponentEvents<HTMLStyleElement>
{
}

public class Style() : BaseNonVoidDomComponent<HTMLStyleElement, StyleProps, StyleEvents>("style")
{
}
