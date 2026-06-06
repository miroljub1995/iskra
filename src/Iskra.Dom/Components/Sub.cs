using Iskra.StdWeb;

namespace Iskra.Dom.Components;

public class SubProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class SubEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class Sub() : BaseNonVoidDomComponent<HTMLElement, SubProps, SubEvents>("sub")
{
}
