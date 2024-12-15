using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices.JavaScript;

namespace Iskra.StdWeb.Utils;

public static class JSObjectsCache
{
    private static readonly Dictionary<object, WeakReference<JSObject>> Cache = new();

    public static JSObject GetOrAdd(object managedObject, Func<JSObject> factory)
    {
        // TODO: Remove all keys that do not have target

        if (TryGetValue(managedObject, out var jsObject))
        {
            return jsObject;
        }

        var newJSObject = factory();
        Cache[managedObject] = new WeakReference<JSObject>(newJSObject);

        return newJSObject;
    }

    public static bool TryGetValue(object managedObject, [NotNullWhen(true)] out JSObject? value)
    {
        if (Cache.TryGetValue(managedObject, out var jsObjectRef) && jsObjectRef.TryGetTarget(out var jsObject))
        {
            value = jsObject;
            return true;
        }

        value = null;
        return false;
    }
}