// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class Proofreader: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public Proofreader(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public static global::Iskra.JSCore.Generics.Promise<global::Iskra.StdWeb.Proofreader, global::Iskra.StdWeb.PropertyAccessor> Create()
    {
        using global::Iskra.JSCore.FunctionResPool.Owner ___resOwner_1 = global::Iskra.JSCore.FunctionResPool.Shared.Rent();

        global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallEmptyNonVoidFunctionProperty(global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsConstructorProxy(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "Proofreader"), "create", global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsConstructorProxy(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "Proofreader"), ___resOwner_1.JSObject);

        // Return Value
        return global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.Promise<global::Iskra.StdWeb.Proofreader, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(___resOwner_1.JSObject, "value");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public static global::Iskra.JSCore.Generics.Promise<global::Iskra.StdWeb.Proofreader, global::Iskra.StdWeb.PropertyAccessor> Create(global::Iskra.StdWeb.ProofreaderCreateOptions options)
    {
        int ___argsArrayLength_2 = 1;

        using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_2);

        // Argument 1
        global::System.Runtime.InteropServices.JavaScript.JSObject ___marshalledValue_3;
        ___marshalledValue_3 = options.JSObject;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2(___argsArray_0.JSObject, 0, ___marshalledValue_3);

        using global::Iskra.JSCore.FunctionResPool.Owner ___resOwner_1 = global::Iskra.JSCore.FunctionResPool.Shared.Rent();

        global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallNonEmptyNonVoidFunctionProperty(global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsConstructorProxy(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "Proofreader"), "create", global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsConstructorProxy(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "Proofreader"), ___argsArray_0.JSObject, ___resOwner_1.JSObject);

        // Return Value
        return global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.Promise<global::Iskra.StdWeb.Proofreader, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(___resOwner_1.JSObject, "value");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public static global::Iskra.JSCore.Generics.Promise<global::Iskra.StdWeb.Availability, global::Iskra.StdWeb.PropertyAccessor> Availability()
    {
        using global::Iskra.JSCore.FunctionResPool.Owner ___resOwner_1 = global::Iskra.JSCore.FunctionResPool.Shared.Rent();

        global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallEmptyNonVoidFunctionProperty(global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsConstructorProxy(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "Proofreader"), "availability", global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsConstructorProxy(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "Proofreader"), ___resOwner_1.JSObject);

        // Return Value
        return global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.Promise<global::Iskra.StdWeb.Availability, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(___resOwner_1.JSObject, "value");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public static global::Iskra.JSCore.Generics.Promise<global::Iskra.StdWeb.Availability, global::Iskra.StdWeb.PropertyAccessor> Availability(global::Iskra.StdWeb.ProofreaderCreateCoreOptions options)
    {
        int ___argsArrayLength_2 = 1;

        using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_2);

        // Argument 1
        global::System.Runtime.InteropServices.JavaScript.JSObject ___marshalledValue_3;
        ___marshalledValue_3 = options.JSObject;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2(___argsArray_0.JSObject, 0, ___marshalledValue_3);

        using global::Iskra.JSCore.FunctionResPool.Owner ___resOwner_1 = global::Iskra.JSCore.FunctionResPool.Shared.Rent();

        global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallNonEmptyNonVoidFunctionProperty(global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsConstructorProxy(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "Proofreader"), "availability", global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsConstructorProxy(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "Proofreader"), ___argsArray_0.JSObject, ___resOwner_1.JSObject);

        // Return Value
        return global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.Promise<global::Iskra.StdWeb.Availability, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(___resOwner_1.JSObject, "value");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.Promise<global::Iskra.StdWeb.ProofreadResult, global::Iskra.StdWeb.PropertyAccessor> Proofread(string input)
    {
        int ___argsArrayLength_2 = 1;

        using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_2);

        // Argument 1
        string ___marshalledValue_3;
        ___marshalledValue_3 = input;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsStringV2(___argsArray_0.JSObject, 0, ___marshalledValue_3);

        using global::Iskra.JSCore.FunctionResPool.Owner ___resOwner_1 = global::Iskra.JSCore.FunctionResPool.Shared.Rent();

        global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallNonEmptyNonVoidFunctionProperty(JSObject, "proofread", JSObject, ___argsArray_0.JSObject, ___resOwner_1.JSObject);

        // Return Value
        return global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.Promise<global::Iskra.StdWeb.ProofreadResult, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(___resOwner_1.JSObject, "value");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.Promise<global::Iskra.StdWeb.ProofreadResult, global::Iskra.StdWeb.PropertyAccessor> Proofread(string input, global::Iskra.StdWeb.ProofreaderProofreadOptions options)
    {
        int ___argsArrayLength_2 = 2;

        using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_2);

        // Argument 1
        string ___marshalledValue_3;
        ___marshalledValue_3 = input;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsStringV2(___argsArray_0.JSObject, 0, ___marshalledValue_3);

        // Argument 2
        global::System.Runtime.InteropServices.JavaScript.JSObject ___marshalledValue_4;
        ___marshalledValue_4 = options.JSObject;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2(___argsArray_0.JSObject, 1, ___marshalledValue_4);

        using global::Iskra.JSCore.FunctionResPool.Owner ___resOwner_1 = global::Iskra.JSCore.FunctionResPool.Shared.Rent();

        global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallNonEmptyNonVoidFunctionProperty(JSObject, "proofread", JSObject, ___argsArray_0.JSObject, ___resOwner_1.JSObject);

        // Return Value
        return global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.Promise<global::Iskra.StdWeb.ProofreadResult, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(___resOwner_1.JSObject, "value");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool IncludeCorrectionTypes
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "includeCorrectionTypes");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool IncludeCorrectionExplanations
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "includeCorrectionExplanations");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.FrozenArray<string, global::Iskra.StdWeb.PropertyAccessor>? ExpectedInputLanguages
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.FrozenArray<string, global::Iskra.StdWeb.PropertyAccessor>?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "expectedInputLanguages");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? CorrectionExplanationLanguage
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "correctionExplanationLanguage");
    }
}

#nullable disable