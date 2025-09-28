using System.Runtime.InteropServices.JavaScript;

namespace Iskra.JSCore.Generics;

public class JSArray<T, TMarshaller>(JSObject obj) : JSObjectProxy(obj)
    where TMarshaller : IGenericMarshaller<T[]>
{
    public static implicit operator JSArray<T, TMarshaller>(T[] input) => new(TMarshaller.ToJS(input));
    public static implicit operator T[](JSArray<T, TMarshaller> input) => TMarshaller.ToManaged(input.JSObject);
}