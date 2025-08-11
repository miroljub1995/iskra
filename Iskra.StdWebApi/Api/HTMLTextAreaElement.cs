using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebApi.Api;

[GenerateBindings]
[AddToGlobalFactory]
public class HTMLTextAreaElement : HTMLElement
{
    protected HTMLTextAreaElement() => throw new();

    public string Autocomplete
    {
        get => throw new();
        set => throw new();
    }

    public int Cols
    {
        get => throw new();
        set => throw new();
    }


    public string DefaultValue
    {
        get => throw new();
        set => throw new();
    }

    public string DirName
    {
        get => throw new();
        set => throw new();
    }

    public bool Disabled
    {
        get => throw new();
        set => throw new();
    }

    public HTMLFormElement Form
    {
        get => throw new();
    }

    public NodeList Labels
    {
        get => throw new();
        set => throw new();
    }

    public int MaxLength
    {
        get => throw new();
        set => throw new();
    }

    public int MinLength
    {
        get => throw new();
        set => throw new();
    }

    public string Name
    {
        get => throw new();
        set => throw new();
    }

    public string Placeholder
    {
        get => throw new();
        set => throw new();
    }

    public bool ReadOnly
    {
        get => throw new();
        set => throw new();
    }

    public bool Required
    {
        get => throw new();
        set => throw new();
    }

    public int Rows
    {
        get => throw new();
        set => throw new();
    }

    public string SelectionDirection
    {
        get => throw new();
        set => throw new();
    }

    public int SelectionEnd
    {
        get => throw new();
        set => throw new();
    }

    public int SelectionStart
    {
        get => throw new();
        set => throw new();
    }

    public int TextLength
    {
        get => throw new();
    }

    public string Type
    {
        get => throw new();
    }

    public string ValidationMessage
    {
        get => throw new();
    }

    public ValidityState Validity
    {
        get => throw new();
    }

    public string Value
    {
        get => throw new();
        set => throw new();
    }

    public bool WillValidate
    {
        get => throw new();
    }

    public string Wrap
    {
        get => throw new();
        set => throw new();
    }

    public bool CheckValidity() => throw new();

    public bool ReportValidity() => throw new();

    public void Select() => throw new();

    public void SetCustomValidity(string message) => throw new();

    public void SetRangeText(string replacement) => throw new();

    public void SetRangeText(string replacement, int startSelection) => throw new();

    public void SetRangeText(string replacement, int startSelection, int endSelection) => throw new();

    public void SetRangeText(string replacement, int startSelection, int endSelection, string selectMode) =>
        throw new();

    public void SetSelectionRange(int startSelection, int endSelection) => throw new();

    public void SetSelectionRange(int startSelection, int endSelection, string selectionDirection) => throw new();
}