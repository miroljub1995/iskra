using Iskra.StdWeb;

namespace Iskra.Dom.Components;

public class RtProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class RtEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class Rt() : BaseNonVoidDomComponent<HTMLElement, RtProps, RtEvents>("rt")
{
}
