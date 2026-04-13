using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class RpProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class RpEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class Rp() : BaseNonVoidDomComponent<HTMLElement, RpProps, RpEvents>("rp")
{
}
