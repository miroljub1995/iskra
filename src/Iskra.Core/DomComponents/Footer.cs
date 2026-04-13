using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class FooterProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class FooterEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class Footer() : BaseNonVoidDomComponent<HTMLElement, FooterProps, FooterEvents>("footer")
{
}
