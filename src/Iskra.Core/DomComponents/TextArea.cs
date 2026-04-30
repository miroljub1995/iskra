using System.Runtime.Versioning;
using Iskra.Core.RenderRoot;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class TextAreaProps : GlobalHtmlComponentProps<HTMLTextAreaElement>
{
    public IReadOnlySignal<string>? Autocomplete { get; init; }
    public IReadOnlySignal<uint>? Cols { get; init; }
    public IReadOnlySignal<string>? DirName { get; init; }
    public IReadOnlySignal<bool>? Disabled { get; init; }
    public IReadOnlySignal<int>? MaxLength { get; init; }
    public IReadOnlySignal<int>? MinLength { get; init; }
    public IReadOnlySignal<string>? Name { get; init; }
    public IReadOnlySignal<string>? Placeholder { get; init; }
    public IReadOnlySignal<bool>? ReadOnly { get; init; }
    public IReadOnlySignal<bool>? Required { get; init; }
    public IReadOnlySignal<uint>? Rows { get; init; }
    public IReadOnlySignal<string>? Wrap { get; init; }
    public IReadOnlySignal<string>? Value { get; init; }
    public IReadOnlySignal<string>? DefaultValue { get; init; }

    [SupportedOSPlatform("browser")]
    protected internal override void RegisterClientEffects(Action<Action<HTMLTextAreaElement>> register)
    {
        base.RegisterClientEffects(register);

        if (Autocomplete != null)
        {
            register(el => el.Autocomplete = Autocomplete.Value);
        }

        if (Cols != null)
        {
            register(el => el.Cols = Cols.Value);
        }

        if (DirName != null)
        {
            register(el => el.DirName = DirName.Value);
        }

        if (Disabled != null)
        {
            register(el => el.Disabled = Disabled.Value);
        }

        if (MaxLength != null)
        {
            register(el => el.MaxLength = MaxLength.Value);
        }

        if (MinLength != null)
        {
            register(el => el.MinLength = MinLength.Value);
        }

        if (Name != null)
        {
            register(el => el.Name = Name.Value);
        }

        if (Placeholder != null)
        {
            register(el => el.Placeholder = Placeholder.Value);
        }

        if (ReadOnly != null)
        {
            register(el => el.ReadOnly = ReadOnly.Value);
        }

        if (Required != null)
        {
            register(el => el.Required = Required.Value);
        }

        if (Rows != null)
        {
            register(el => el.Rows = Rows.Value);
        }

        if (Wrap != null)
        {
            register(el => el.Wrap = Wrap.Value);
        }

        if (Value != null)
        {
            register(el => el.Value = Value.Value);
        }

        if (DefaultValue != null)
        {
            register(el => el.DefaultValue = DefaultValue.Value);
        }
    }

    protected internal override void RegisterServerEffects(Action<Action<SsrElementNode>> register)
    {
        base.RegisterServerEffects(register);

        if (Autocomplete != null)
        {
            register(el => el.SetAttribute("autocomplete", Autocomplete.Value));
        }

        if (Cols != null)
        {
            register(el => SsrAttributes.SetUInt(el, "cols", Cols.Value));
        }

        if (DirName != null)
        {
            register(el => el.SetAttribute("dirname", DirName.Value));
        }

        if (Disabled != null)
        {
            register(el => SsrAttributes.SetBoolean(el, "disabled", Disabled.Value));
        }

        if (MaxLength != null)
        {
            register(el => SsrAttributes.SetInt(el, "maxlength", MaxLength.Value));
        }

        if (MinLength != null)
        {
            register(el => SsrAttributes.SetInt(el, "minlength", MinLength.Value));
        }

        if (Name != null)
        {
            register(el => el.SetAttribute("name", Name.Value));
        }

        if (Placeholder != null)
        {
            register(el => el.SetAttribute("placeholder", Placeholder.Value));
        }

        if (ReadOnly != null)
        {
            register(el => SsrAttributes.SetBoolean(el, "readonly", ReadOnly.Value));
        }

        if (Required != null)
        {
            register(el => SsrAttributes.SetBoolean(el, "required", Required.Value));
        }

        if (Rows != null)
        {
            register(el => SsrAttributes.SetUInt(el, "rows", Rows.Value));
        }

        if (Wrap != null)
        {
            register(el => el.SetAttribute("wrap", Wrap.Value));
        }

        if (Value != null)
        {
            register(el => el.SetAttribute("value", Value.Value));
        }

        if (DefaultValue != null)
        {
            register(el => el.SetAttribute("value", DefaultValue.Value));
        }
    }
}

public class TextAreaEvents : HtmlElementComponentEvents<HTMLTextAreaElement>
{
}

public class TextArea() : BaseNonVoidDomComponent<HTMLTextAreaElement, TextAreaProps, TextAreaEvents>("textarea")
{
}
