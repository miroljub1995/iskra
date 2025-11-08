using System.Runtime.InteropServices.JavaScript;

namespace Iskra.JSCore.Generics;

public class PropertyAccessor
{
    public static TElement Get<TElement, TAccessor>(JSObject obj, string propertyName)
        where TAccessor : IPropertyAccessor<TElement>
        => TAccessor.Get(obj, propertyName);

    public static TElement Get<TElement, TAccessor>(JSObject obj, int propertyIndex)
        where TAccessor : IPropertyAccessor<TElement>
        => TAccessor.Get(obj, propertyIndex);

    public static void Set<TElement, TAccessor>(JSObject obj, string propertyName, TElement value)
        where TAccessor : IPropertyAccessor<TElement>
        => TAccessor.Set(obj, propertyName, value);

    public static void Set<TElement, TAccessor>(JSObject obj, int propertyIndex, TElement value)
        where TAccessor : IPropertyAccessor<TElement>
        => TAccessor.Set(obj, propertyIndex, value);
}