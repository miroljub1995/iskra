using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class NoscriptProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class NoscriptEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class Noscript() : BaseNonVoidDomComponent<HTMLElement, NoscriptProps, NoscriptEvents>("noscript")
{
}
