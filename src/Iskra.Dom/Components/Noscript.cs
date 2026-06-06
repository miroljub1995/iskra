using Iskra.StdWeb;

namespace Iskra.Dom.Components;

public class NoscriptProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class NoscriptEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class Noscript() : BaseNonVoidDomComponent<HTMLElement, NoscriptProps, NoscriptEvents>("noscript")
{
}
