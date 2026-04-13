using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class KbdProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class KbdEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class Kbd() : BaseNonVoidDomComponent<HTMLElement, KbdProps, KbdEvents>("kbd")
{
}
