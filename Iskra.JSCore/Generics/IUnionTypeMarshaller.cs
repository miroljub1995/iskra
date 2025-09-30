using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices.JavaScript;

namespace Iskra.JSCore.Generics;

public interface IUnionTypeMarshaller<T>
{
    static abstract bool TryToManaged(JSObject obj, [NotNullWhen(true)] out T? result);
    static abstract JSObject ToJS(T obj);
}