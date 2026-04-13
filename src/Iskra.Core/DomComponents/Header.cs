using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class HeaderProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class HeaderEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class Header() : BaseNonVoidDomComponent<HTMLElement, HeaderProps, HeaderEvents>("header")
{
}
