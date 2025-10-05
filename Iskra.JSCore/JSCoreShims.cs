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
                                     export const construct = (obj, constructorName, ...args) => new obj[constructorName](...args);
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

                                     export const getPropertyAsUnion = (obj, propertyName) => {
                                         // boolean = 1
                                         // number = 2
                                         // bigint = 3
                                         // string = 4
                                         // symbol = 5
                                         // function = 6
                                         // object = 7
                                         // managed object = 8

                                         const value = obj[propertyName];
                                         if (value === null || value === undefined) {
                                             return null;
                                         }
                                         
                                         // TODO: handle manged object
                                         
                                         if (typeof value === 'boolean') {
                                             return { type: 1, value, };
                                         }
                                         
                                         if (typeof value === 'number') {
                                             return { type: 2, value, };
                                         }
                                         
                                         if (typeof value === 'bigint') {
                                             return { type: 3, value, };
                                         }
                                         
                                         if (typeof value === 'string') {
                                             return { type: 4, value, };
                                         }
                                         
                                         if (typeof value === 'symbol') {
                                             return { type: 5, value, };
                                         }
                                         
                                         if (typeof value === 'function') {
                                             return { type: 6, value, };
                                         }
                                         
                                         if (typeof value === 'object') {
                                             return { type: 7, value, };
                                         }
                                         
                                         throw new Error(`Unknown type of ${propertyName} on ${obj}`);
                                     }
                                     export const setPropertyAsUnion = (obj, propertyName, value) => obj[propertyName] = (value === null ? null : value.value);
                                     """;

        var encoded = Uri.EscapeDataString(moduleContent);
        var dataUrl = $"data:text/javascript,{encoded}";
        await JSHost.ImportAsync("iskra", dataUrl);
    }
}