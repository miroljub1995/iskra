using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class SupProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class SupEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class Sup() : BaseNonVoidDomComponent<HTMLElement, SupProps, SupEvents>("sup")
{
}
