using Iskra.StdWeb;

namespace Iskra.Dom.Components;

public class AsideProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class AsideEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class Aside() : BaseNonVoidDomComponent<HTMLElement, AsideProps, AsideEvents>("aside")
{
}
