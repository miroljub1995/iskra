using Iskra.StdWeb;

namespace Iskra.Dom.Components;

public class HeadProps : GlobalHtmlComponentProps<HTMLHeadElement>
{
}

public class HeadEvents : HtmlElementComponentEvents<HTMLHeadElement>
{
}

public class Head() : BaseNonVoidDomComponent<HTMLHeadElement, HeadProps, HeadEvents>("head")
{
}
