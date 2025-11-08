using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;

namespace Iskra.JSCore;

public partial class Promise
{
    public static implicit operator Task(Promise promise) => ToTask_Bridge(promise.JSObject);

    public TaskAwaiter GetAwaiter() => ((Task)this).GetAwaiter();

    [JSImport("getSelf", "iskra")]
    private static partial Task ToTask_Bridge(JSObject promise);
}