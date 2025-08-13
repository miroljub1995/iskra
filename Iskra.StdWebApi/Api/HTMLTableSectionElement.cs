using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebApi.Api;

[GenerateBindings]
[AddToGlobalFactory]
public class HTMLTableSectionElement : HTMLElement
{
    protected HTMLTableSectionElement() => throw new();

    public HTMLCollection Rows
    {
        get => throw new();
    }

    public void DeleteRow(int index) => throw new();

    public HTMLTableRowElement InsertRow() => throw new();

    public HTMLTableRowElement InsertRow(int index) => throw new();
}