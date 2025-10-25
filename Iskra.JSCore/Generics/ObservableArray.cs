using System.Runtime.InteropServices.JavaScript;
using Iskra.JSCore.Extensions;

namespace Iskra.JSCore.Generics;

public class ObservableArray<T, TMarshaller>(JSObject obj) : JSObjectProxy(obj)
    where TMarshaller : IArrayLikeElementMarshaller<T>
{
    public static implicit operator ObservableArray<T, TMarshaller>(T[] input) =>
        new(ArrayLikeMarshaller.ToJS<T, TMarshaller>(input));

    public static implicit operator T[](ObservableArray<T, TMarshaller> input) =>
        ArrayLikeMarshaller.ToManaged<T, TMarshaller>(input.JSObject);

    public int Length
    {
        get => Convert.ToInt32(JSObject.GetPropertyAsDoubleV2("length"));
        set => JSObject.SetPropertyAsDoubleV2("length", value);
    }

    public T this[int index]
    {
        get => TMarshaller.Get(JSObject, index);
        set => TMarshaller.Set(JSObject, index, value);
    }
}