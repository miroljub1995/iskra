using System.Collections.Concurrent;
using System.Runtime.InteropServices.JavaScript;
using Iskra.JSCore.Extensions;

namespace Iskra.JSCore;

public partial class ArgsArrayPool
{
    public static ArgsArrayPool Shared { get; } = new();

    private readonly ConcurrentQueue<JSObject> _pool = [];

    public Owner Rent(int length)
    {
        var argsArrayObj = _pool.TryDequeue(out var obj) ? obj : CreateArgsArray();

        argsArrayObj.SetPropertyAsDoubleV2("length", length);

        return new Owner(argsArrayObj, this);
    }

    private void Return(Owner owner)
    {
        _pool.Enqueue(owner.JSObject);
    }

    [JSImport("createArgsArray", "iskra")]
    private static partial JSObject CreateArgsArray();

    public class Owner(JSObject obj, ArgsArrayPool pool) : JSObjectProxy(obj), IDisposable
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