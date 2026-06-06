using Iskra.StdWeb;

namespace Iskra.Dom.Components;

public class SearchProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class SearchEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class Search() : BaseNonVoidDomComponent<HTMLElement, SearchProps, SearchEvents>("search")
{
}
