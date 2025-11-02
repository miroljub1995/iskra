using System.Runtime.InteropServices.JavaScript;
using Iskra.JSCore.Extensions;

namespace Iskra.JSCore.Generics;

public class ObservableArray<T, TAccessor>(JSObject obj) : JSObjectProxy(obj)
    where TAccessor : IPropertyAccessor<T>
{
    public static implicit operator ObservableArray<T, TAccessor>(T[] input) =>
        new(ArrayLikeMarshaller.ToJS<T, TAccessor>(input));

    public static implicit operator T[](ObservableArray<T, TAccessor> input) =>
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