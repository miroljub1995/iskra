using Iskra.StdWeb;

namespace Iskra.Dom.Components;

public class SmallProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class SmallEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class Small() : BaseNonVoidDomComponent<HTMLElement, SmallProps, SmallEvents>("small")
{
}
