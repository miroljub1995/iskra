using System.Runtime.InteropServices.JavaScript;

namespace Iskra.JSCore;

public static partial class JSCoreShims
{
    [JSImport("globalThis.Reflect.set")]
    private static partial void
        InitManagedTypeConstructor(JSObject module, string name, [JSMarshalAs<JSType.Any>] object value);

    private static int _isInitialized;

    public static async Task InitializeAsync()
    {
        if (Interlocked.CompareExchange(ref _isInitialized, 1, 0) != 0)
        {
            return;
        }

        const string moduleContent = """
                                     let managedTypeConstructor = null;

                                     export const getSelf = (obj) => obj;
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
                                             if (value.constructor === managedTypeConstructor) {
                                                 return { type: 8, value, };
                                             }

                                             return { type: 7, value, };
                                         }
                                         
                                         throw new Error(`Unknown type of ${propertyName} on ${obj}`);
                                     }
                                     export const setPropertyAsUnion = (obj, propertyName, value) => obj[propertyName] = (value === null ? null : value.value);

                                     export const createArgsArray = () => {
                                         const array = [];
                                         const target = { length: array.length };
                                         return new Proxy(target, {
                                             get(target, prop) {
                                                 if (Number.isInteger(prop)) {
                                                     return Reflect.get(array, prop);
                                                 }

                                                 return Reflect.get(target, prop);
                                             },
                                             set(target, prop, value) {
                                                 if (Number.isInteger(prop)) {
                                                     Reflect.set(array, prop, value);
                                                 }

                                                 if (prop === 'length' && value > array.length) {
                                                     array.length = value;
                                                 }

                                                 return Reflect.set(target, prop, value);
                                             }
                                         });
                                     }

                                     // We need this to support dotnet < 10
                                     // https://github.com/dotnet/runtime/issues/110716
                                     export const getPropertyAsConstructorProxy = (obj, constructorName) => {
                                         return new Proxy({ value: Reflect.get(obj, constructorName) }, {
                                             get(target, prop, receiver) {
                                               const value = Reflect.get(target.value, prop, receiver);
                                               return typeof value === 'function' ? value.bind(target.value) : value;
                                             },
                                             set(target, prop, newValue) {
                                                 return Reflect.set(target.value, prop, newValue);
                                             },
                                             construct(target, args) {
                                                 return Reflect.construct(target.value, args);
                                             },
                                         })
                                     }

                                     export const wrapPromiseValue = (obj) => obj.then(x => ({ value: x }));
                                     export const unwrapPromiseValue = (obj) => obj.then(x => x.value);

                                     export default {
                                       set initManagedTypeConstructor(v) {
                                         managedTypeConstructor = v.constructor;
                                       }
                                     };
                                     """;

        var encoded = Uri.EscapeDataString(moduleContent);
        var dataUrl = $"data:text/javascript,{encoded}";
        var module = await JSHost.ImportAsync("iskra", dataUrl);
        var defaultExport = module.GetPropertyAsJSObject("default") ?? throw new Exception("Default export is null");
        InitManagedTypeConstructor(defaultExport, "initManagedTypeConstructor", new object());
    }
}