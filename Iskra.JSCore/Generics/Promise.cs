using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;

namespace Iskra.JSCore.Generics;

public partial class Promise<T, TMarshaller>(JSObject obj) : JSObjectProxy(obj)
    where TMarshaller : IGenericMarshaller<Task<T>>
{
    public static implicit operator Task<T>(Promise<T, TMarshaller> promise) => TMarshaller.ToManaged(promise.JSObject);
    public static implicit operator Promise<T, TMarshaller>(Task<T> task) => new(TMarshaller.ToJS(task));

    public TaskAwaiter<T> GetAwaiter() => ((Task<T>)this).GetAwaiter();
}