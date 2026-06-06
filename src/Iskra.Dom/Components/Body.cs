using Iskra.StdWeb;

namespace Iskra.Dom.Components;

public class BodyProps : GlobalHtmlComponentProps<HTMLBodyElement>
{
}

public class BodyEvents : HtmlElementComponentEvents<HTMLBodyElement>
{
}

public class Body() : BaseNonVoidDomComponent<HTMLBodyElement, BodyProps, BodyEvents>("body")
{
}
