using System.Runtime.InteropServices.JavaScript;

namespace Iskra.JSCore.Generics;

public interface IArrayLikeElementMarshaller<TElement>
{
    static abstract TElement Get(JSObject array, int index);
    static abstract void Set(JSObject array, int index, TElement value);
}