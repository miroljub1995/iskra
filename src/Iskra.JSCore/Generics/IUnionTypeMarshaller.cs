using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices.JavaScript;

namespace Iskra.JSCore.Generics;

public interface IUnionTypeMarshaller<T>
    where T : notnull
{
    static abstract bool TryToManaged(JSObject obj, [MaybeNullWhen(false)] out T result);
    static abstract JSObject ToJS(T obj);
}