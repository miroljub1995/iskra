using System.Runtime.InteropServices.JavaScript;
using Iskra.Utils;

namespace Iskra.StdWeb;

public static partial class WrapperFactory
{
    private static readonly Dictionary<JSObject, Func<JSObject, JSObjectWrapper>> Factories = new();
    private static readonly Dictionary<string, Func<JSObject, JSObjectWrapper>> GlobalFactories = new();

    private static bool _areDefaultsInitialized;

    private const string ProxyMethodName = "iskra_isOfGlobalConstructor";
    private static bool _isProxyInitialized;

    private static void EnsureInitializedDefaults()
    {
        if (_areDefaultsInitialized)
        {
            return;
        }

        // AddFactory(GetGlobalConstructor("EventTarget"), obj => new EventTarget(obj));
        // AddFactory(GetGlobalConstructor("Window"), obj => new Window(obj));

        AddGlobalFactory("Document", obj => new Document(obj));
        AddGlobalFactory("Element", obj => new Element(obj));
        AddGlobalFactory("Event", obj => new Event(obj));
        AddGlobalFactory("EventTarget", obj => new EventTarget(obj));
        AddGlobalFactory("HTMLBodyElement", obj => new HTMLBodyElement(obj));
        AddGlobalFactory("HTMLDivElement", obj => new HTMLDivElement(obj));
        AddGlobalFactory("HTMLElement", obj => new HTMLElement(obj));
        AddGlobalFactory("Node", obj => new Node(obj));
        AddGlobalFactory("Window", obj => new Window(obj));

        _areDefaultsInitialized = true;
    }

    public static void AddFactory(JSObject constructor, Func<JSObject, JSObjectWrapper> factory)
    {
        Factories.Add(constructor, factory);
    }

    public static void AddGlobalFactory(string constructorName, Func<JSObject, JSObjectWrapper> factory)
    {
        GlobalFactories.Add(constructorName, factory);
    }

    public static JSObjectWrapper GetWrapper(JSObject obj)
    {
        EnsureInitializedDefaults();
        EnsureMethodProxyInitialized();

        foreach (var keyValue in GlobalFactories)
        {
            if (IsOfGlobalConstructor(keyValue.Key, obj))
            {
                return keyValue.Value(obj);
            }
        }

        var constructor = obj.GetPropertyAsJSObject("constructor")
                          ?? throw new Exception($"No constructor found for {obj}");


        if (Factories.TryGetValue(constructor, out var factory))
        {
            return factory(obj);
        }

        throw new Exception("Failed to find wrapper.");
    }

    public static TWrapper GetWrapper<TWrapper>(JSObject obj)
        where TWrapper : JSObjectWrapper
    {
        var wrapper = GetWrapper(obj);
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


    private static void EnsureMethodProxyInitialized()
    {
        if (!_isProxyInitialized)
        {
            JSHost.GlobalThis.SetProperty(ProxyMethodName,
                JSFunctionConstructor.Function("constructorName", "target",
                    "return globalThis[constructorName] === target.constructor;"));
            _isProxyInitialized = true;
        }
    }

    [JSImport($"globalThis.{ProxyMethodName}")]
    private static partial bool IsOfGlobalConstructor(string constructorName, JSObject target);
}