using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class MenuProps : GlobalHtmlComponentProps<HTMLMenuElement>
{
}

public class MenuEvents : HtmlElementComponentEvents<HTMLMenuElement>
{
}

public class Menu() : BaseNonVoidDomComponent<HTMLMenuElement, MenuProps, MenuEvents>("menu")
{
}
