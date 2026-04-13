using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class AbbrProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class AbbrEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class Abbr() : BaseNonVoidDomComponent<HTMLElement, AbbrProps, AbbrEvents>("abbr")
{
}
