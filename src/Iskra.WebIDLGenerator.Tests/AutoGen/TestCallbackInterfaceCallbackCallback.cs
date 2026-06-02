// ReSharper disable All

namespace Iskra.WebIDLGenerator.Tests;

#nullable enable

public delegate string TestCallbackInterfaceCallbackCallbackManaged(int value);

public partial class TestCallbackInterfaceCallbackCallback: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public TestCallbackInterfaceCallbackCallback(global::System.Runtime.InteropServices.JavaScript.JSObject obj) : base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public TestCallbackInterfaceCallbackCallback(TestCallbackInterfaceCallbackCallbackManaged input): this(ToJSObject(input))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public static implicit operator TestCallbackInterfaceCallbackCallback(TestCallbackInterfaceCallbackCallbackManaged input)
    {
        return new global::Iskra.WebIDLGenerator.Tests.TestCallbackInterfaceCallbackCallback(ToJSObject(input));
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool TryGetManaged([global::System.Diagnostics.CodeAnalysis.NotNullWhenAttribute(true)] out global::Iskra.WebIDLGenerator.Tests.TestCallbackInterfaceCallbackCallbackManaged? managed, bool allowConversion = false)
    {
        managed = global::Iskra.JSCore.Extensions.JSFunctionExtensions.GetManagedFunctionFromProperty(JSObject) as global::Iskra.WebIDLGenerator.Tests.TestCallbackInterfaceCallbackCallbackManaged;
        if (managed is not null)
        {
            return true;
        }

        if (!allowConversion)
        {
            return false;
        }

        managed = (value) =>
        {
            int ___argsArrayLength_3 = 1;

            using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_3);

            // Argument 1
            double ___marshalledValue_4;
            ___marshalledValue_4 = Convert.ToDouble(value);
            global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsDoubleV2(___argsArray_0.JSObject, 0, ___marshalledValue_4);

            using global::Iskra.JSCore.FunctionResPool.Owner ___resOwner_1 = global::Iskra.JSCore.FunctionResPool.Shared.Rent();

            global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallNonEmptyNonVoidFunction(JSObject, null, ___argsArray_0.JSObject, ___resOwner_1.JSObject);

            // Return Value
            string ___res_2;
            string ___res_5 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsStringV2(___resOwner_1.JSObject, "value");
            ___res_2 = ___res_5;
            return ___res_2;
        };
        return true;
    }
    
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    private static global::System.Runtime.InteropServices.JavaScript.JSObject ToJSObject(TestCallbackInterfaceCallbackCallbackManaged input)
    {
        Action<global::System.Runtime.InteropServices.JavaScript.JSObject, global::System.Runtime.InteropServices.JavaScript.JSObject> callback = (___args_0, ___res_5) =>
        {
            using (___args_0)
            using (___res_5)
            {
                // Argument 1
                int ___arg_2;
                double ___res_3 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsDoubleV2(___args_0, 0);
                ___arg_2 = Convert.ToInt32(___res_3);

                string ___managedRes_6 = input(___arg_2);

                string ___marshalledValue_7;
                ___marshalledValue_7 = ___managedRes_6;
                global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsStringV2(___res_5, "value", ___marshalledValue_7);
            }
        };

        global::System.Runtime.InteropServices.JavaScript.JSObject ___funcObj_4 = global::Iskra.JSCore.Extensions.JSFunctionExtensions.WrapAsNonVoidFunction(callback);
        global::Iskra.JSCore.Extensions.JSFunctionExtensions.StoreManagedFunctionToProperty(___funcObj_4, input); 

        return ___funcObj_4;
    }
}

#nullable disable