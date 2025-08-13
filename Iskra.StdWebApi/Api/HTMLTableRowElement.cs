using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebApi.Api;

[GenerateBindings]
[AddToGlobalFactory]
public class HTMLTableRowElement : HTMLElement
{
    protected HTMLTableRowElement() => throw new();

    public HTMLCollection Cells
    {
        get => throw new();
    }

    public int RowIndex
    {
        get => throw new();
    }

    public int SectionRowIndex
    {
        get => throw new();
    }

    public void DeleteCell() => throw new();

    public void DeleteCell(int index) => throw new();

    public HTMLTableCellElement InsertCell() => throw new();

    public HTMLTableCellElement InsertCell(int index) => throw new();
}