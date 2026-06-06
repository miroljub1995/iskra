using Iskra.StdWeb;

namespace Iskra.Dom.Components;

public class BProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class BEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class B() : BaseNonVoidDomComponent<HTMLElement, BProps, BEvents>("b")
{
}
