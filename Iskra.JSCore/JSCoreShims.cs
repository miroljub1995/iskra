using System.Runtime.InteropServices.JavaScript;

namespace Iskra.JSCore;

public static class JSCoreShims
{
    private static int _isInitialized;

    public static async Task InitializeAsync()
    {
        if (Interlocked.CompareExchange(ref _isInitialized, 1, 0) != 0)
        {
            return;
        }

        const string moduleContent = """
                                     export const constructGlobalObject = (constructorName, ...args) => new globalThis[constructorName](...args);
                                     export const isGlobalConstructor = (constructorName, target) => globalThis[constructorName] === target.constructor;
                                     export const arrowFunctionProxy = (fun) => (...args) => fun(...args);
                                     export const constructorMap = (() => {
                                         let nextId = 0;
                                         const map = new Map();
                                         return {
                                             addConstructorFromProp: (obj, propName) => {
                                                 const id = nextId++;
                                                 map.set(obj[propName], id);
                                                 return id;
                                             },
                                             getConstructorId: (obj) => map.get(obj.constructor),
                                         }
                                     })();
                                     """;

        var encoded = Uri.EscapeDataString(moduleContent);
        var dataUrl = $"data:text/javascript,{encoded}";
        await JSHost.ImportAsync("iskra", dataUrl);
    }
}