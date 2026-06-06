using Iskra.StdWeb;

namespace Iskra.Dom.Components;

public class UlProps : GlobalHtmlComponentProps<HTMLUListElement>
{
}

public class UlEvents : HtmlElementComponentEvents<HTMLUListElement>
{
}

public class Ul() : BaseNonVoidDomComponent<HTMLUListElement, UlProps, UlEvents>("ul")
{
}
