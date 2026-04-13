using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class AsideProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class AsideEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class Aside() : BaseNonVoidDomComponent<HTMLElement, AsideProps, AsideEvents>("aside")
{
}
