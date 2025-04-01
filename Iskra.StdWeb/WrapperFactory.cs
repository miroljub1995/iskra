using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;

namespace Iskra.StdWeb;

public static partial class WrapperFactory
{
    private static readonly Dictionary<JSObject, Func<JSObject, JSObjectWrapper>> Factories = new();
    private static readonly Dictionary<string, Func<JSObject, JSObjectWrapper>> GlobalFactories = new();

    private const string ProxyMethodName = "iskra_isOfGlobalConstructor";
    private static bool _isProxyInitialized;

    [Obsolete("Obsolete until https://github.com/dotnet/runtime/issues/110716 is fixed.")]
    public static void AddFactory(JSObject constructor, Func<JSObject, JSObjectWrapper> factory)
    {
        Factories.Add(constructor, factory);
    }

    public static void AddGlobalFactory(string constructorName, Func<JSObject, JSObjectWrapper> factory)
    {
        GlobalFactories.Add(constructorName, factory);
    }

    public static bool TryGetWrapper(JSObject obj, [NotNullWhen(true)] out JSObjectWrapper? wrapper)
    {
        EnsureMethodProxyInitialized();

        foreach (var keyValue in GlobalFactories)
        {
            if (IsOfGlobalConstructor(keyValue.Key, obj))
            {
                wrapper = keyValue.Value(obj);
                return true;
            }
        }

        var constructor = obj.GetPropertyAsJSObject("constructor")
                          ?? throw new Exception($"No constructor found for {obj}");

        if (Factories.TryGetValue(constructor, out var factory))
        {
            wrapper = factory(obj);
            return true;
        }

        throw new Exception("Failed to find wrapper.");
    }

    public static TWrapper GetWrapper<TWrapper>(JSObject obj)
    {
        RuntimeHelpers.RunClassConstructor(typeof(TWrapper).TypeHandle);

        if (!TryGetWrapper(obj, out var wrapper))
        {
            throw new Exception($"Failed to find wrapper for {typeof(TWrapper).Name}.");
        }

        if (wrapper is not TWrapper specificWrapper)
        {
            throw new Exception($"Wrapper {wrapper} is not of type {typeof(TWrapper).Name}.");
        }

        return specificWrapper;
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
            var proxyMethod = new Function("constructorName", "target",
                "return globalThis[constructorName] === target.constructor;");

            JSHost.GlobalThis.SetProperty(ProxyMethodName, proxyMethod.JSObject);

            _isProxyInitialized = true;
        }
    }

    [JSImport($"globalThis.{ProxyMethodName}")]
    private static partial bool IsOfGlobalConstructor(string constructorName, JSObject target);
}