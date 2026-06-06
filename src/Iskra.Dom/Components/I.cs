using Iskra.StdWeb;

namespace Iskra.Dom.Components;

public class IProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class IEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class I() : BaseNonVoidDomComponent<HTMLElement, IProps, IEvents>("i")
{
}
