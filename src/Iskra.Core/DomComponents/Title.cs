using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class TitleProps : GlobalHtmlComponentProps<HTMLTitleElement>
{
}

public class TitleEvents : HtmlElementComponentEvents<HTMLTitleElement>
{
}

public class Title() : BaseNonVoidDomComponent<HTMLTitleElement, TitleProps, TitleEvents>("title")
{
}
