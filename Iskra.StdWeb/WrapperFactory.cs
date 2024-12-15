using System.Runtime.InteropServices.JavaScript;
using Iskra.Utils;

namespace Iskra.StdWeb;

public enum JSObjectType
{
    Instance,
    Constructor
}

public static class WrapperFactory
{
    private static readonly Dictionary<JSObject, Func<JSObject, JSObjectWrapper>> Factories = new();
    private static bool _isInitialized;

    private static void EnsureInitializedDefaults()
    {
        if (_isInitialized)
        {
            return;
        }

        AddFactory(GetGlobalConstructor("EventTarget"), obj => new EventTarget(obj));
        AddFactory(GetGlobalConstructor("Window"), obj => new Window(obj));

        _isInitialized = true;
    }

    public static void AddFactory(JSObject constructor, Func<JSObject, JSObjectWrapper> factory)
    {
        Factories.Add(constructor, factory);
    }

    public static JSObjectWrapper GetWrapper(JSObject obj, JSObjectType objType)
    {
        if (objType == JSObjectType.Constructor)
        {
            EnsureInitializedDefaults();

            if (Factories.TryGetValue(obj, out var factory))
            {
                return factory(obj);
            }

            throw new Exception("Failed to find wrapper.");
        }

        if (objType == JSObjectType.Instance)
        {
            var constructor = obj.GetPropertyAsJSObject("constructor")
                              ?? throw new Exception($"No constructor found for {obj}");

            return GetWrapper(constructor, JSObjectType.Constructor);
        }

        throw new Exception($"Unknown object type {objType}.");
    }

    public static TWrapper GetWrapper<TWrapper>(JSObject obj, JSObjectType objType)
        where TWrapper : JSObjectWrapper
    {
        JSLogger.Log(["from main WindowConstructor", JSHost.GlobalThis.GetPropertyAsJSObject("Window")]);
        var wrapper = GetWrapper(obj, objType);
        if (wrapper is TWrapper specificWrapper)
        {
            return specificWrapper;
        }

        throw new Exception($"Wrapper {wrapper} is not of type {typeof(TWrapper).Name}.");
    }

    public static JSObject GetGlobalConstructor(string name)
    {
        if (!JSHost.GlobalThis.HasProperty(name))
        {
            throw new Exception($"Failed to get global constructor '{name}'. Property not defined.");
        }

        if (JSHost.GlobalThis.GetTypeOfProperty(name) != "function")
        {
            throw new Exception($"Failed to get global constructor '{name}'. Property is not a function.");
        }

        var constructor = JSHost.GlobalThis.GetPropertyAsJSObject(name)
                          ?? throw new Exception("This case should be handled above.");

        return constructor;
    }
}