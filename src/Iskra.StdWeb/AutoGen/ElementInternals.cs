// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class ElementInternals: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ElementInternals(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.ShadowRoot? ShadowRoot
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.ShadowRoot?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "shadowRoot");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public void SetFormValue(global::Iskra.JSCore.Generics.Union<global::Iskra.StdWeb.File, string, global::Iskra.StdWeb.FormData, global::Iskra.StdWeb.GenericMarshaller.Union>? value)
    {
        int ___argsArrayLength_2 = 1;

        using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_2);

        // Argument 1
        global::System.Runtime.InteropServices.JavaScript.JSObject? ___propObject_3;
        if (value is null)
        {
            ___propObject_3 = null;
        }
        else
        {
            ___propObject_3 = value.JSObject;
        }

        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsUnionAsNullable(___argsArray_0.JSObject, 0, ___propObject_3);

        global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallNonEmptyVoidFunctionProperty(JSObject, "setFormValue", JSObject, ___argsArray_0.JSObject);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public void SetFormValue(global::Iskra.JSCore.Generics.Union<global::Iskra.StdWeb.File, string, global::Iskra.StdWeb.FormData, global::Iskra.StdWeb.GenericMarshaller.Union>? value, global::Iskra.JSCore.Generics.Union<global::Iskra.StdWeb.File, string, global::Iskra.StdWeb.FormData, global::Iskra.StdWeb.GenericMarshaller.Union>? state)
    {
        int ___argsArrayLength_2 = 2;

        using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_2);

        // Argument 1
        global::System.Runtime.InteropServices.JavaScript.JSObject? ___propObject_3;
        if (value is null)
        {
            ___propObject_3 = null;
        }
        else
        {
            ___propObject_3 = value.JSObject;
        }

        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsUnionAsNullable(___argsArray_0.JSObject, 0, ___propObject_3);

        // Argument 2
        global::System.Runtime.InteropServices.JavaScript.JSObject? ___propObject_4;
        if (state is null)
        {
            ___propObject_4 = null;
        }
        else
        {
            ___propObject_4 = state.JSObject;
        }

        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsUnionAsNullable(___argsArray_0.JSObject, 1, ___propObject_4);

        global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallNonEmptyVoidFunctionProperty(JSObject, "setFormValue", JSObject, ___argsArray_0.JSObject);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.HTMLFormElement? Form
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.HTMLFormElement?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "form");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public void SetValidity()
    {
        global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallEmptyVoidFunctionProperty(JSObject, "setValidity", JSObject);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public void SetValidity(global::Iskra.StdWeb.ValidityStateFlags flags)
    {
        int ___argsArrayLength_2 = 1;

        using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_2);

        // Argument 1
        global::System.Runtime.InteropServices.JavaScript.JSObject ___marshalledValue_3;
        ___marshalledValue_3 = flags.JSObject;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2(___argsArray_0.JSObject, 0, ___marshalledValue_3);

        global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallNonEmptyVoidFunctionProperty(JSObject, "setValidity", JSObject, ___argsArray_0.JSObject);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public void SetValidity(global::Iskra.StdWeb.ValidityStateFlags flags, string message)
    {
        int ___argsArrayLength_2 = 2;

        using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_2);

        // Argument 1
        global::System.Runtime.InteropServices.JavaScript.JSObject ___marshalledValue_3;
        ___marshalledValue_3 = flags.JSObject;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2(___argsArray_0.JSObject, 0, ___marshalledValue_3);

        // Argument 2
        string ___marshalledValue_4;
        ___marshalledValue_4 = message;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsStringV2(___argsArray_0.JSObject, 1, ___marshalledValue_4);

        global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallNonEmptyVoidFunctionProperty(JSObject, "setValidity", JSObject, ___argsArray_0.JSObject);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public void SetValidity(global::Iskra.StdWeb.ValidityStateFlags flags, string message, global::Iskra.StdWeb.HTMLElement anchor)
    {
        int ___argsArrayLength_2 = 3;

        using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_2);

        // Argument 1
        global::System.Runtime.InteropServices.JavaScript.JSObject ___marshalledValue_3;
        ___marshalledValue_3 = flags.JSObject;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2(___argsArray_0.JSObject, 0, ___marshalledValue_3);

        // Argument 2
        string ___marshalledValue_4;
        ___marshalledValue_4 = message;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsStringV2(___argsArray_0.JSObject, 1, ___marshalledValue_4);

        // Argument 3
        global::System.Runtime.InteropServices.JavaScript.JSObject ___marshalledValue_5;
        ___marshalledValue_5 = anchor.JSObject;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2(___argsArray_0.JSObject, 2, ___marshalledValue_5);

        global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallNonEmptyVoidFunctionProperty(JSObject, "setValidity", JSObject, ___argsArray_0.JSObject);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool WillValidate
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "willValidate");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.ValidityState Validity
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.ValidityState, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "validity");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string ValidationMessage
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "validationMessage");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool CheckValidity()
    {
        using global::Iskra.JSCore.FunctionResPool.Owner ___resOwner_1 = global::Iskra.JSCore.FunctionResPool.Shared.Rent();

        global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallEmptyNonVoidFunctionProperty(JSObject, "checkValidity", JSObject, ___resOwner_1.JSObject);

        // Return Value
        return global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(___resOwner_1.JSObject, "value");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool ReportValidity()
    {
        using global::Iskra.JSCore.FunctionResPool.Owner ___resOwner_1 = global::Iskra.JSCore.FunctionResPool.Shared.Rent();

        global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallEmptyNonVoidFunctionProperty(JSObject, "reportValidity", JSObject, ___resOwner_1.JSObject);

        // Return Value
        return global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(___resOwner_1.JSObject, "value");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.NodeList Labels
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.NodeList, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "labels");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.CustomStateSet States
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.CustomStateSet, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "states");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? Role
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "role");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "role", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.Element? AriaActiveDescendantElement
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.Element?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaActiveDescendantElement");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.Element?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaActiveDescendantElement", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? AriaAtomic
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaAtomic");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaAtomic", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? AriaAutoComplete
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaAutoComplete");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaAutoComplete", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? AriaBrailleLabel
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaBrailleLabel");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaBrailleLabel", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? AriaBrailleRoleDescription
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaBrailleRoleDescription");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaBrailleRoleDescription", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? AriaBusy
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaBusy");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaBusy", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? AriaChecked
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaChecked");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaChecked", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? AriaColCount
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaColCount");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaColCount", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? AriaColIndex
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaColIndex");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaColIndex", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? AriaColIndexText
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaColIndexText");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaColIndexText", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? AriaColSpan
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaColSpan");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaColSpan", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.FrozenArray<global::Iskra.StdWeb.Element, global::Iskra.StdWeb.PropertyAccessor>? AriaControlsElements
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.FrozenArray<global::Iskra.StdWeb.Element, global::Iskra.StdWeb.PropertyAccessor>?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaControlsElements");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.JSCore.Generics.FrozenArray<global::Iskra.StdWeb.Element, global::Iskra.StdWeb.PropertyAccessor>?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaControlsElements", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? AriaCurrent
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaCurrent");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaCurrent", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.FrozenArray<global::Iskra.StdWeb.Element, global::Iskra.StdWeb.PropertyAccessor>? AriaDescribedByElements
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.FrozenArray<global::Iskra.StdWeb.Element, global::Iskra.StdWeb.PropertyAccessor>?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaDescribedByElements");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.JSCore.Generics.FrozenArray<global::Iskra.StdWeb.Element, global::Iskra.StdWeb.PropertyAccessor>?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaDescribedByElements", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? AriaDescription
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaDescription");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaDescription", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.FrozenArray<global::Iskra.StdWeb.Element, global::Iskra.StdWeb.PropertyAccessor>? AriaDetailsElements
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.FrozenArray<global::Iskra.StdWeb.Element, global::Iskra.StdWeb.PropertyAccessor>?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaDetailsElements");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.JSCore.Generics.FrozenArray<global::Iskra.StdWeb.Element, global::Iskra.StdWeb.PropertyAccessor>?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaDetailsElements", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? AriaDisabled
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaDisabled");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaDisabled", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.FrozenArray<global::Iskra.StdWeb.Element, global::Iskra.StdWeb.PropertyAccessor>? AriaErrorMessageElements
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.FrozenArray<global::Iskra.StdWeb.Element, global::Iskra.StdWeb.PropertyAccessor>?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaErrorMessageElements");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.JSCore.Generics.FrozenArray<global::Iskra.StdWeb.Element, global::Iskra.StdWeb.PropertyAccessor>?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaErrorMessageElements", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? AriaExpanded
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaExpanded");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaExpanded", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.FrozenArray<global::Iskra.StdWeb.Element, global::Iskra.StdWeb.PropertyAccessor>? AriaFlowToElements
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.FrozenArray<global::Iskra.StdWeb.Element, global::Iskra.StdWeb.PropertyAccessor>?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaFlowToElements");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.JSCore.Generics.FrozenArray<global::Iskra.StdWeb.Element, global::Iskra.StdWeb.PropertyAccessor>?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaFlowToElements", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? AriaHasPopup
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaHasPopup");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaHasPopup", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? AriaHidden
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaHidden");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaHidden", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? AriaInvalid
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaInvalid");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaInvalid", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? AriaKeyShortcuts
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaKeyShortcuts");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaKeyShortcuts", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? AriaLabel
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaLabel");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaLabel", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.FrozenArray<global::Iskra.StdWeb.Element, global::Iskra.StdWeb.PropertyAccessor>? AriaLabelledByElements
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.FrozenArray<global::Iskra.StdWeb.Element, global::Iskra.StdWeb.PropertyAccessor>?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaLabelledByElements");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.JSCore.Generics.FrozenArray<global::Iskra.StdWeb.Element, global::Iskra.StdWeb.PropertyAccessor>?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaLabelledByElements", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? AriaLevel
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaLevel");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaLevel", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? AriaLive
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaLive");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaLive", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? AriaModal
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaModal");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaModal", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? AriaMultiLine
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaMultiLine");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaMultiLine", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? AriaMultiSelectable
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaMultiSelectable");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaMultiSelectable", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? AriaOrientation
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaOrientation");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaOrientation", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.FrozenArray<global::Iskra.StdWeb.Element, global::Iskra.StdWeb.PropertyAccessor>? AriaOwnsElements
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.FrozenArray<global::Iskra.StdWeb.Element, global::Iskra.StdWeb.PropertyAccessor>?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaOwnsElements");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.JSCore.Generics.FrozenArray<global::Iskra.StdWeb.Element, global::Iskra.StdWeb.PropertyAccessor>?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaOwnsElements", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? AriaPlaceholder
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaPlaceholder");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaPlaceholder", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? AriaPosInSet
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaPosInSet");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaPosInSet", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? AriaPressed
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaPressed");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaPressed", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? AriaReadOnly
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaReadOnly");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaReadOnly", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? AriaRelevant
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaRelevant");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaRelevant", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? AriaRequired
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaRequired");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaRequired", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? AriaRoleDescription
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaRoleDescription");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaRoleDescription", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? AriaRowCount
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaRowCount");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaRowCount", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? AriaRowIndex
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaRowIndex");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaRowIndex", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? AriaRowIndexText
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaRowIndexText");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaRowIndexText", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? AriaRowSpan
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaRowSpan");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaRowSpan", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? AriaSelected
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaSelected");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaSelected", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? AriaSetSize
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaSetSize");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaSetSize", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? AriaSort
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaSort");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaSort", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? AriaValueMax
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaValueMax");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaValueMax", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? AriaValueMin
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaValueMin");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaValueMin", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? AriaValueNow
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaValueNow");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaValueNow", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? AriaValueText
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaValueText");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "ariaValueText", value);
    }
}

#nullable disable