using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class DdProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class DdEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class Dd() : BaseNonVoidDomComponent<HTMLElement, DdProps, DdEvents>("dd")
{
}
