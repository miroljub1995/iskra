using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;
using Iskra.JSCore.Extensions;

namespace Iskra.JSCore.Generics;

public class FrozenArray<T, TAccessor> : JSObjectProxy
    where TAccessor : IPropertyAccessor<T>
{
    [SupportedOSPlatform("browser")]
    public FrozenArray(JSObject obj) : base(obj)
    {
    }

    [SupportedOSPlatform("browser")]
    public static implicit operator FrozenArray<T, TAccessor>(T[] input) =>
        new(ArrayLikeMarshaller.ToJS<T, TAccessor>(input));

    [SupportedOSPlatform("browser")]
    public static implicit operator T[](FrozenArray<T, TAccessor> input) =>
        ArrayLikeMarshaller.ToManaged<T, TAccessor>(input.JSObject);

    public int Length
    {
        get => Convert.ToInt32(JSObject.GetPropertyAsDoubleV2("length"));
        set => JSObject.SetPropertyAsDoubleV2("length", value);
    }

    public T this[int index]
    {
        get => TAccessor.Get(JSObject, index);
        set => TAccessor.Set(JSObject, index, value);
    }
}