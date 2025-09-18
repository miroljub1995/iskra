using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices.JavaScript;

namespace Iskra.JSCore;

public static partial class JSObjectProxyFactory
{
    private static readonly Dictionary<int, Func<JSObject, JSObjectProxy>> GlobalFactories = new();

    public static void AddConstructorFromProp(JSObject obj, string propName, Func<JSObject, JSObjectProxy> factory)
    {
        var id = AddConstructorFromProp_Bridge(obj, propName);
        GlobalFactories.Add(id, factory);
    }

    public static bool TryGetProxy(JSObject obj, [NotNullWhen(true)] out JSObjectProxy? wrapper)
    {
        var id = GetConstructorId_Bridge(obj);
        if (id.HasValue && GlobalFactories[id.Value] is { } factory)
        {
            wrapper = factory(obj);
            return true;
        }

        wrapper = null;
        return false;
    }

    public static TProxy GetProxy<TProxy>(JSObject obj)
        where TProxy : JSObjectProxy
    {
        if (!TryGetProxy(obj, out var proxy))
        {
            throw new Exception($"Failed to find wrapper for {typeof(TProxy).Name}.");
        }

        if (proxy is not TProxy specificProxy)
        {
            throw new Exception($"Proxy {proxy} is not of type {typeof(TProxy).Name}.");
        }

        return specificProxy;
    }

    [JSImport("addConstructorFromProp", "iskra")]
    private static partial int AddConstructorFromProp_Bridge(JSObject obj, string propName);

    [JSImport("getConstructorId", "iskra")]
    private static partial int? GetConstructorId_Bridge(JSObject obj);
}