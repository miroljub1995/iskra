using Iskra.StdWeb;

namespace Iskra.Dom.Components;

public class TbodyProps : GlobalHtmlComponentProps<HTMLTableSectionElement>
{
}

public class TbodyEvents : HtmlElementComponentEvents<HTMLTableSectionElement>
{
}

public class Tbody() : BaseNonVoidDomComponent<HTMLTableSectionElement, TbodyProps, TbodyEvents>("tbody")
{
}
