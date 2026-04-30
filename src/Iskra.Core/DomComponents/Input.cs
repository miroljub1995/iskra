using System.Runtime.Versioning;
using Iskra.Core.RenderRoot;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class InputProps : GlobalHtmlComponentProps<HTMLInputElement>
{
    public IReadOnlySignal<string>? Accept { get; init; }
    public IReadOnlySignal<string>? Alt { get; init; }
    public IReadOnlySignal<string>? Autocomplete { get; init; }
    public IReadOnlySignal<string>? Capture { get; init; }
    public IReadOnlySignal<bool>? Checked { get; init; }
    public IReadOnlySignal<bool>? DefaultChecked { get; init; }
    public IReadOnlySignal<string>? DirName { get; init; }
    public IReadOnlySignal<bool>? Disabled { get; init; }
    public IReadOnlySignal<string>? FormAction { get; init; }
    public IReadOnlySignal<string>? FormEnctype { get; init; }
    public IReadOnlySignal<string>? FormMethod { get; init; }
    public IReadOnlySignal<bool>? FormNoValidate { get; init; }
    public IReadOnlySignal<string>? FormTarget { get; init; }
    public IReadOnlySignal<uint>? Height { get; init; }
    public IReadOnlySignal<string>? Max { get; init; }
    public IReadOnlySignal<int>? MaxLength { get; init; }
    public IReadOnlySignal<string>? Min { get; init; }
    public IReadOnlySignal<int>? MinLength { get; init; }
    public IReadOnlySignal<bool>? Multiple { get; init; }
    public IReadOnlySignal<string>? Name { get; init; }
    public IReadOnlySignal<string>? Pattern { get; init; }
    public IReadOnlySignal<string>? Placeholder { get; init; }
    public IReadOnlySignal<bool>? ReadOnly { get; init; }
    public IReadOnlySignal<bool>? Required { get; init; }
    public IReadOnlySignal<uint>? Size { get; init; }
    public IReadOnlySignal<string>? Src { get; init; }
    public IReadOnlySignal<string>? Step { get; init; }
    public IReadOnlySignal<string>? Type { get; init; }
    public IReadOnlySignal<string>? Value { get; init; }
    public IReadOnlySignal<string>? DefaultValue { get; init; }
    public IReadOnlySignal<uint>? Width { get; init; }

    [SupportedOSPlatform("browser")]
    protected internal override void RegisterClientEffects(Action<Action<HTMLInputElement>> register)
    {
        base.RegisterClientEffects(register);

        if (Accept != null)
        {
            register(el => el.Accept = Accept.Value);
        }

        if (Alt != null)
        {
            register(el => el.Alt = Alt.Value);
        }

        if (Autocomplete != null)
        {
            register(el => el.Autocomplete = Autocomplete.Value);
        }

        if (Capture != null)
        {
            register(el => el.Capture = Capture.Value);
        }

        if (Checked != null)
        {
            register(el => el.Checked = Checked.Value);
        }

        if (DefaultChecked != null)
        {
            register(el => el.DefaultChecked = DefaultChecked.Value);
        }

        if (DirName != null)
        {
            register(el => el.DirName = DirName.Value);
        }

        if (Disabled != null)
        {
            register(el => el.Disabled = Disabled.Value);
        }

        if (FormAction != null)
        {
            register(el => el.FormAction = FormAction.Value);
        }

        if (FormEnctype != null)
        {
            register(el => el.FormEnctype = FormEnctype.Value);
        }

        if (FormMethod != null)
        {
            register(el => el.FormMethod = FormMethod.Value);
        }

        if (FormNoValidate != null)
        {
            register(el => el.FormNoValidate = FormNoValidate.Value);
        }

        if (FormTarget != null)
        {
            register(el => el.FormTarget = FormTarget.Value);
        }

        if (Height != null)
        {
            register(el => el.Height = Height.Value);
        }

        if (Max != null)
        {
            register(el => el.Max = Max.Value);
        }

        if (MaxLength != null)
        {
            register(el => el.MaxLength = MaxLength.Value);
        }

        if (Min != null)
        {
            register(el => el.Min = Min.Value);
        }

        if (MinLength != null)
        {
            register(el => el.MinLength = MinLength.Value);
        }

        if (Multiple != null)
        {
            register(el => el.Multiple = Multiple.Value);
        }

        if (Name != null)
        {
            register(el => el.Name = Name.Value);
        }

        if (Pattern != null)
        {
            register(el => el.Pattern = Pattern.Value);
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

        if (Size != null)
        {
            register(el => el.Size = Size.Value);
        }

        if (Src != null)
        {
            register(el => el.Src = Src.Value);
        }

        if (Step != null)
        {
            register(el => el.Step = Step.Value);
        }

        if (Type != null)
        {
            register(el => el.Type = Type.Value);
        }

        if (Value != null)
        {
            register(el => el.Value = Value.Value);
        }

        if (DefaultValue != null)
        {
            register(el => el.DefaultValue = DefaultValue.Value);
        }

        if (Width != null)
        {
            register(el => el.Width = Width.Value);
        }
    }

    protected internal override void RegisterServerEffects(Action<Action<SsrElementNode>> register)
    {
        base.RegisterServerEffects(register);

        if (Accept != null)
        {
            register(el => el.SetAttribute("accept", Accept.Value));
        }

        if (Alt != null)
        {
            register(el => el.SetAttribute("alt", Alt.Value));
        }

        if (Autocomplete != null)
        {
            register(el => el.SetAttribute("autocomplete", Autocomplete.Value));
        }

        if (Capture != null)
        {
            register(el => el.SetAttribute("capture", Capture.Value));
        }

        if (Checked != null)
        {
            register(el => SsrAttributes.SetBoolean(el, "checked", Checked.Value));
        }

        if (DefaultChecked != null)
        {
            register(el => SsrAttributes.SetBoolean(el, "checked", DefaultChecked.Value));
        }

        if (DirName != null)
        {
            register(el => el.SetAttribute("dirname", DirName.Value));
        }

        if (Disabled != null)
        {
            register(el => SsrAttributes.SetBoolean(el, "disabled", Disabled.Value));
        }

        if (FormAction != null)
        {
            register(el => el.SetAttribute("formaction", FormAction.Value));
        }

        if (FormEnctype != null)
        {
            register(el => el.SetAttribute("formenctype", FormEnctype.Value));
        }

        if (FormMethod != null)
        {
            register(el => el.SetAttribute("formmethod", FormMethod.Value));
        }

        if (FormNoValidate != null)
        {
            register(el => SsrAttributes.SetBoolean(el, "formnovalidate", FormNoValidate.Value));
        }

        if (FormTarget != null)
        {
            register(el => el.SetAttribute("formtarget", FormTarget.Value));
        }

        if (Height != null)
        {
            register(el => SsrAttributes.SetUInt(el, "height", Height.Value));
        }

        if (Max != null)
        {
            register(el => el.SetAttribute("max", Max.Value));
        }

        if (MaxLength != null)
        {
            register(el => SsrAttributes.SetInt(el, "maxlength", MaxLength.Value));
        }

        if (Min != null)
        {
            register(el => el.SetAttribute("min", Min.Value));
        }

        if (MinLength != null)
        {
            register(el => SsrAttributes.SetInt(el, "minlength", MinLength.Value));
        }

        if (Multiple != null)
        {
            register(el => SsrAttributes.SetBoolean(el, "multiple", Multiple.Value));
        }

        if (Name != null)
        {
            register(el => el.SetAttribute("name", Name.Value));
        }

        if (Pattern != null)
        {
            register(el => el.SetAttribute("pattern", Pattern.Value));
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

        if (Size != null)
        {
            register(el => SsrAttributes.SetUInt(el, "size", Size.Value));
        }

        if (Src != null)
        {
            register(el => el.SetAttribute("src", Src.Value));
        }

        if (Step != null)
        {
            register(el => el.SetAttribute("step", Step.Value));
        }

        if (Type != null)
        {
            register(el => el.SetAttribute("type", Type.Value));
        }

        if (Value != null)
        {
            register(el => el.SetAttribute("value", Value.Value));
        }

        if (DefaultValue != null)
        {
            register(el => el.SetAttribute("value", DefaultValue.Value));
        }

        if (Width != null)
        {
            register(el => SsrAttributes.SetUInt(el, "width", Width.Value));
        }
    }
}

public class InputEvents : HtmlElementComponentEvents<HTMLInputElement>
{
}

public class Input() : BaseVoidDomComponent<HTMLInputElement, InputProps, InputEvents>("input")
{
}