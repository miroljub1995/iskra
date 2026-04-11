// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class XPathResult: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public XPathResult(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    public const ushort ANY_TYPE = 0;

    public const ushort NUMBER_TYPE = 1;

    public const ushort STRING_TYPE = 2;

    public const ushort BOOLEAN_TYPE = 3;

    public const ushort UNORDERED_NODE_ITERATOR_TYPE = 4;

    public const ushort ORDERED_NODE_ITERATOR_TYPE = 5;

    public const ushort UNORDERED_NODE_SNAPSHOT_TYPE = 6;

    public const ushort ORDERED_NODE_SNAPSHOT_TYPE = 7;

    public const ushort ANY_UNORDERED_NODE_TYPE = 8;

    public const ushort FIRST_ORDERED_NODE_TYPE = 9;

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ushort ResultType
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<ushort, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "resultType");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double NumberValue
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "numberValue");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string StringValue
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "stringValue");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool BooleanValue
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "booleanValue");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.Node? SingleNodeValue
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.Node?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "singleNodeValue");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool InvalidIteratorState
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "invalidIteratorState");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public uint SnapshotLength
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<uint, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "snapshotLength");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.Node? IterateNext()
    {
        using global::Iskra.JSCore.FunctionResPool.Owner ___resOwner_1 = global::Iskra.JSCore.FunctionResPool.Shared.Rent();

        global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallEmptyNonVoidFunctionProperty(JSObject, "iterateNext", JSObject, ___resOwner_1.JSObject);

        // Return Value
        return global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.Node?, global::Iskra.StdWeb.PropertyAccessorNullable>(___resOwner_1.JSObject, "value");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.Node? SnapshotItem(uint index)
    {
        int ___argsArrayLength_2 = 1;

        using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_2);

        // Argument 1
        double ___marshalledValue_3;
        ___marshalledValue_3 = Convert.ToDouble(index);
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsDoubleV2(___argsArray_0.JSObject, 0, ___marshalledValue_3);

        using global::Iskra.JSCore.FunctionResPool.Owner ___resOwner_1 = global::Iskra.JSCore.FunctionResPool.Shared.Rent();

        global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallNonEmptyNonVoidFunctionProperty(JSObject, "snapshotItem", JSObject, ___argsArray_0.JSObject, ___resOwner_1.JSObject);

        // Return Value
        return global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.Node?, global::Iskra.StdWeb.PropertyAccessorNullable>(___resOwner_1.JSObject, "value");
    }
}

#nullable disable