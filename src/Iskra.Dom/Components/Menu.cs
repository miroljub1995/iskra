using Iskra.StdWeb;

namespace Iskra.Dom.Components;

public class MenuProps : GlobalHtmlComponentProps<HTMLMenuElement>
{
}

public class MenuEvents : HtmlElementComponentEvents<HTMLMenuElement>
{
}

public class Menu() : BaseNonVoidDomComponent<HTMLMenuElement, MenuProps, MenuEvents>("menu")
{
}
