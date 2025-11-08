using System.Runtime.InteropServices.JavaScript;

namespace Iskra.JSCore.Generics;

public interface IPropertyAccessor<TElement>
{
    static abstract TElement Get(JSObject obj, string propertyName);
    static abstract TElement Get(JSObject obj, int propertyIndex);
    static abstract void Set(JSObject obj, string propertyName, TElement value);
    static abstract void Set(JSObject obj, int propertyIndex, TElement value);
}