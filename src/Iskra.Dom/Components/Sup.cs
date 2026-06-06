using Iskra.StdWeb;

namespace Iskra.Dom.Components;

public class SupProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class SupEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class Sup() : BaseNonVoidDomComponent<HTMLElement, SupProps, SupEvents>("sup")
{
}
