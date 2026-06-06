using Iskra.StdWeb;

namespace Iskra.Dom.Components;

public class RpProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class RpEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class Rp() : BaseNonVoidDomComponent<HTMLElement, RpProps, RpEvents>("rp")
{
}
