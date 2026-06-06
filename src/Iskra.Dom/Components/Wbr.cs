using Iskra.StdWeb;

namespace Iskra.Dom.Components;

public class WbrProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class WbrEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class Wbr() : BaseVoidDomComponent<HTMLElement, WbrProps, WbrEvents>("wbr")
{
}
