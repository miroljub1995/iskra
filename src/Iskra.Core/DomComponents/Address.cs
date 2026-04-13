using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class AddressProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class AddressEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class Address() : BaseNonVoidDomComponent<HTMLElement, AddressProps, AddressEvents>("address")
{
}
