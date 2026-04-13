using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class ArticleProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class ArticleEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class Article() : BaseNonVoidDomComponent<HTMLElement, ArticleProps, ArticleEvents>("article")
{
}
