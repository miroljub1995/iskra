using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class NavProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class NavEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class Nav() : BaseNonVoidDomComponent<HTMLElement, NavProps, NavEvents>("nav")
{
}
