using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class DtProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class DtEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class Dt() : BaseNonVoidDomComponent<HTMLElement, DtProps, DtEvents>("dt")
{
}
