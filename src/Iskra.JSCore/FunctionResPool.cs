using System.Collections.Concurrent;
using System.Runtime.InteropServices.JavaScript;

namespace Iskra.JSCore;

public partial class FunctionResPool
{
    public static FunctionResPool Shared { get; } = new();

    private readonly ConcurrentQueue<JSObject> _pool = [];

    public Owner Rent()
    {
        if (!_pool.TryDequeue(out var obj))
        {
            obj = Construct(JSHost.GlobalThis, "Object");
        }

        return new Owner(obj, this);
    }

    private void Return(Owner owner)
    {
        _pool.Enqueue(owner.JSObject);
    }

    [JSImport("construct", "iskra")]
    private static partial JSObject Construct(JSObject obj, string constructorName);

    public class Owner(JSObject obj, FunctionResPool pool) : JSObjectProxy(obj), IDisposable
    {
        private int _disposed;

        public void Dispose()
        {
            if (Interlocked.CompareExchange(ref _disposed, 1, 0) == 0)
            {
                pool.Return(this);
            }

            GC.SuppressFinalize(this);
        }
    }
}