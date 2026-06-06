using Iskra.StdWeb;

namespace Iskra.Dom.Components;

public class MainProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class MainEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class Main() : BaseNonVoidDomComponent<HTMLElement, MainProps, MainEvents>("main")
{
}
