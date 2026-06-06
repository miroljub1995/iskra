using Iskra.StdWeb;

namespace Iskra.Dom.Components;

public class NavProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class NavEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class Nav() : BaseNonVoidDomComponent<HTMLElement, NavProps, NavEvents>("nav")
{
}
