using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class SearchProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class SearchEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class Search() : BaseNonVoidDomComponent<HTMLElement, SearchProps, SearchEvents>("search")
{
}
