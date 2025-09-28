using System.Runtime.InteropServices.JavaScript;

namespace Iskra.JSCore.Generics;

public class FrozenArray<T, TMarshaller>(JSObject obj) : JSObjectProxy(obj)
    where TMarshaller : IGenericMarshaller<T[]>
{
    public static implicit operator FrozenArray<T, TMarshaller>(T[] input) => new(TMarshaller.ToJS(input));
    public static implicit operator T[](FrozenArray<T, TMarshaller> input) => TMarshaller.ToManaged(input.JSObject);
}