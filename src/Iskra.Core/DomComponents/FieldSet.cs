using System.Runtime.Versioning;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class FieldSetProps : GlobalHtmlComponentProps<HTMLFieldSetElement>
{
    public IReadOnlySignal<bool>? Disabled { get; init; }
    public IReadOnlySignal<string>? Name { get; init; }

    [SupportedOSPlatform("browser")]
    protected internal override void RegisterClientEffects(Action<Action<HTMLFieldSetElement>> register)
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
    }
}

public class FieldSetEvents : HtmlElementComponentEvents<HTMLFieldSetElement>
{
}

public class FieldSet() : BaseNonVoidDomComponent<HTMLFieldSetElement, FieldSetProps, FieldSetEvents>("fieldset")
{
}
