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

    protected internal override void RegisterServerEffects(SsrElementNode el)
    {
        base.RegisterServerEffects(el);

        if (Accept != null)
        {
            el.SetAttribute("accept", Accept);
        }

        if (Alt != null)
        {
            el.SetAttribute("alt", Alt);
        }

        if (Autocomplete != null)
        {
            el.SetAttribute("autocomplete", Autocomplete);
        }

        if (Capture != null)
        {
            el.SetAttribute("capture", Capture);
        }

        if (Checked != null)
        {
            el.SetBoolean("checked", Checked);
        }

        if (DefaultChecked != null)
        {
            el.SetBoolean("checked", DefaultChecked);
        }

        if (DirName != null)
        {
            el.SetAttribute("dirname", DirName);
        }

        if (Disabled != null)
        {
            el.SetBoolean("disabled", Disabled);
        }

        if (FormAction != null)
        {
            el.SetAttribute("formaction", FormAction);
        }

        if (FormEnctype != null)
        {
            el.SetAttribute("formenctype", FormEnctype);
        }

        if (FormMethod != null)
        {
            el.SetAttribute("formmethod", FormMethod);
        }

        if (FormNoValidate != null)
        {
            el.SetBoolean("formnovalidate", FormNoValidate);
        }

        if (FormTarget != null)
        {
            el.SetAttribute("formtarget", FormTarget);
        }

        if (Height != null)
        {
            el.SetUInt("height", Height);
        }

        if (Max != null)
        {
            el.SetAttribute("max", Max);
        }

        if (MaxLength != null)
        {
            el.SetInt("maxlength", MaxLength);
        }

        if (Min != null)
        {
            el.SetAttribute("min", Min);
        }

        if (MinLength != null)
        {
            el.SetInt("minlength", MinLength);
        }

        if (Multiple != null)
        {
            el.SetBoolean("multiple", Multiple);
        }

        if (Name != null)
        {
            el.SetAttribute("name", Name);
        }

        if (Pattern != null)
        {
            el.SetAttribute("pattern", Pattern);
        }

        if (Placeholder != null)
        {
            el.SetAttribute("placeholder", Placeholder);
        }

        if (ReadOnly != null)
        {
            el.SetBoolean("readonly", ReadOnly);
        }

        if (Required != null)
        {
            el.SetBoolean("required", Required);
        }

        if (Size != null)
        {
            el.SetUInt("size", Size);
        }

        if (Src != null)
        {
            el.SetAttribute("src", Src);
        }

        if (Step != null)
        {
            el.SetAttribute("step", Step);
        }

        if (Type != null)
        {
            el.SetAttribute("type", Type);
        }

        if (Value != null)
        {
            el.SetAttribute("value", Value);
        }

        if (DefaultValue != null)
        {
            el.SetAttribute("value", DefaultValue);
        }

        if (Width != null)
        {
            el.SetUInt("width", Width);
        }
    }
}

public class InputEvents : HtmlElementComponentEvents<HTMLInputElement>
{
}

public class Input() : BaseVoidDomComponent<HTMLInputElement, InputProps, InputEvents>("input")
{
}