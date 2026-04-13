using System.Runtime.Versioning;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class ButtonProps : GlobalHtmlComponentProps<HTMLButtonElement>
{
    public IReadOnlySignal<bool>? Disabled { get; init; }
    public IReadOnlySignal<string>? Name { get; init; }
    public IReadOnlySignal<string>? Type { get; init; }
    public IReadOnlySignal<string>? Value { get; init; }
    public IReadOnlySignal<string>? FormAction { get; init; }
    public IReadOnlySignal<string>? FormEnctype { get; init; }
    public IReadOnlySignal<string>? FormMethod { get; init; }
    public IReadOnlySignal<bool>? FormNoValidate { get; init; }
    public IReadOnlySignal<string>? FormTarget { get; init; }

    [SupportedOSPlatform("browser")]
    protected internal override void RegisterClientEffects(Action<Action<HTMLButtonElement>> register)
    {
        base.RegisterClientEffects(register);

        if (Disabled != null)
        {
            register(el => el.Disabled = Disabled.Value);
        }

        if (Name != null)
        {
            register(el => el.Name = Name.Value);
        }

        if (Type != null)
        {
            register(el => el.Type = Type.Value);
        }

        if (Value != null)
        {
            register(el => el.Value = Value.Value);
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
    }
}

public class ButtonEvents : HtmlElementComponentEvents<HTMLButtonElement>
{
}

public class Button() : BaseNonVoidDomComponent<HTMLButtonElement, ButtonProps, ButtonEvents>("button")
{
}
