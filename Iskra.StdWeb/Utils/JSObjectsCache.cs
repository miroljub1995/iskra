using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices.JavaScript;

namespace Iskra.StdWeb.Utils;

public static class JSObjectsCache
{
    private static readonly Dictionary<object, WeakReference<JSObject>> Cache = new();

    public static JSObject GetOrAdd(object managedObject, Func<JSObject> factory)
    {
        if (TryGetValue(managedObject, out var jsObject))
        {
            return jsObject;
        }

        RemoveCollectedObjects();

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

    private static void RemoveCollectedObjects()
    {
        var keysToRemove = Cache
            .Where(kvp => !kvp.Value.TryGetTarget(out _))
            .Select(kvp => kvp.Key)
            .ToArray();

        foreach (var key in keysToRemove)
        {
            Cache.Remove(key);
        }
    }
}