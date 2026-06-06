using Iskra.StdWeb;

namespace Iskra.Dom.Components;

public class KbdProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class KbdEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class Kbd() : BaseNonVoidDomComponent<HTMLElement, KbdProps, KbdEvents>("kbd")
{
}
