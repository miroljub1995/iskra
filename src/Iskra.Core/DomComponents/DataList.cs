using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class DataListProps : GlobalHtmlComponentProps<HTMLDataListElement>
{
}

public class DataListEvents : HtmlElementComponentEvents<HTMLDataListElement>
{
}

public class DataList() : BaseNonVoidDomComponent<HTMLDataListElement, DataListProps, DataListEvents>("datalist")
{
}
