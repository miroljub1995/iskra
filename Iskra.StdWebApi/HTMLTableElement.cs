using Iskra.StdWebApi.Api;
using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebApi;

[GenerateBindings]
[AddToGlobalFactory]
public class HTMLTableElement : HTMLElement
{
    protected HTMLTableElement() => throw new();

    public string? Caption
    {
        get => throw new();
        set => throw new();
    }

    public HTMLCollection Rows
    {
        get => throw new();
    }

    public HTMLCollection TBodies
    {
        get => throw new();
    }

    public HTMLTableSectionElement? TFoot
    {
        get => throw new();
        set => throw new();
    }

    public HTMLTableSectionElement? THead
    {
        get => throw new();
        set => throw new();
    }
    
    public HTMLTableCaptionElement CreateCaption() => throw new();
    
    public HTMLTableSectionElement CreateTBody() => throw new();
    
    public HTMLTableSectionElement CreateTFoot() => throw new();
    
    public HTMLTableSectionElement CreateTHead() => throw new();
    
    public void DeleteCaption() => throw new();
    
    public void DeleteRow(int index) => throw new();
    
    public void DeleteTFoot() => throw new();
    
    public void DeleteTHead() => throw new();
    
    public HTMLTableRowElement InsertRow() => throw new();

    public HTMLTableRowElement InsertRow(int index) => throw new();
}