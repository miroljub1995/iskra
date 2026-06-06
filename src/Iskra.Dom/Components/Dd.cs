using Iskra.StdWeb;

namespace Iskra.Dom.Components;

public class DdProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class DdEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class Dd() : BaseNonVoidDomComponent<HTMLElement, DdProps, DdEvents>("dd")
{
}
