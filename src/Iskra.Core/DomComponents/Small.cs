using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class SmallProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class SmallEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class Small() : BaseNonVoidDomComponent<HTMLElement, SmallProps, SmallEvents>("small")
{
}
