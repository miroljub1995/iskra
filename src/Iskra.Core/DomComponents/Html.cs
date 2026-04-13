using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class HtmlProps : GlobalHtmlComponentProps<HTMLHtmlElement>
{
}

public class HtmlEvents : HtmlElementComponentEvents<HTMLHtmlElement>
{
}

public class Html() : BaseNonVoidDomComponent<HTMLHtmlElement, HtmlProps, HtmlEvents>("html")
{
}
