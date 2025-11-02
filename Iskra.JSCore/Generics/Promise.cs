using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;

namespace Iskra.JSCore.Generics;

public partial class Promise<T, TPropertyAccessor>(JSObject obj) : JSObjectProxy(obj)
    where TPropertyAccessor : IPropertyAccessor<T>
{
    [JSImport("construct", "iskra")]
    private static partial JSObject ConstructObject(JSObject obj, string constructorName);

    [JSImport("wrapPromiseValue", "iskra")]
    private static partial Task<JSObject> WrapPromiseValue(JSObject obj);

    [JSImport("unwrapPromiseValue", "iskra")]
    private static partial JSObject UnwrapPromiseValue(Task<JSObject> task);

    public static implicit operator Task<T>(Promise<T, TPropertyAccessor> promise) => ToManaged(promise.JSObject);

    public static implicit operator Promise<T, TPropertyAccessor>(Task<T> task) => new(ToJS(task));

    public TaskAwaiter<T> GetAwaiter() => ((Task<T>)this).GetAwaiter();

    private static async Task<T> ToManaged(JSObject input)
    {
        using var wrappedValue = await WrapPromiseValue(input);
        return TPropertyAccessor.Get(wrappedValue, "value");
    }

    static JSObject ToJS(Task<T> input)
    {
        static async Task<JSObject> WrapTask(Task<T> task)
        {
            var wrapperObject = ConstructObject(JSHost.GlobalThis, "Object");
            var awaitedValue = await task;
            TPropertyAccessor.Set(wrapperObject, "value", awaitedValue);
            return wrapperObject;
        }

        JSObject promiseObj = UnwrapPromiseValue(WrapTask(input));
        return promiseObj;
    }
}