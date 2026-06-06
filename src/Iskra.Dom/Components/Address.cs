using Iskra.StdWeb;

namespace Iskra.Dom.Components;

public class AddressProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class AddressEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class Address() : BaseNonVoidDomComponent<HTMLElement, AddressProps, AddressEvents>("address")
{
}
