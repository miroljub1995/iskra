using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class TbodyProps : GlobalHtmlComponentProps<HTMLTableSectionElement>
{
}

public class TbodyEvents : HtmlElementComponentEvents<HTMLTableSectionElement>
{
}

public class Tbody() : BaseNonVoidDomComponent<HTMLTableSectionElement, TbodyProps, TbodyEvents>("tbody")
{
}
