using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class RtProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class RtEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class Rt() : BaseNonVoidDomComponent<HTMLElement, RtProps, RtEvents>("rt")
{
}
