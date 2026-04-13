using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class TableProps : GlobalHtmlComponentProps<HTMLTableElement>
{
}

public class TableEvents : HtmlElementComponentEvents<HTMLTableElement>
{
}

public class Table() : BaseNonVoidDomComponent<HTMLTableElement, TableProps, TableEvents>("table")
{
}
