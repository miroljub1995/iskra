using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class HeadProps : GlobalHtmlComponentProps<HTMLHeadElement>
{
}

public class HeadEvents : HtmlElementComponentEvents<HTMLHeadElement>
{
}

public class Head() : BaseNonVoidDomComponent<HTMLHeadElement, HeadProps, HeadEvents>("head")
{
}
