namespace Iskra.Core.Features;

/// <summary>
/// A <see cref="SynchronizationContext"/> that runs at most one posted callback
/// at a time, gated by a <see cref="SemaphoreSlim"/>.
///
/// Continuations of <c>await</c>s captured under this context are posted back
/// here automatically by the async machinery, so a chain of awaits in user
/// code is serialized end-to-end without any explicit synchronization at the
/// reactive primitive level.
///
/// No thread affinity: callbacks may run on any thread-pool thread, but never
/// concurrently with another callback posted to the same instance.
///
/// Caveats:
/// <list type="bullet">
///   <item>Synchronous fan-out (e.g. <c>Task.Run(() =&gt; signal.Value++)</c>
///   with no awaits) bypasses the gate. Wrap such work in
///   <see cref="SsrConcurrencyGateFeature"/> if it must serialize.</item>
///   <item>User callbacks that synchronously block on a posted continuation
///   (<c>.Result</c>, <c>.Wait()</c>) will deadlock.</item>
///   <item><see cref="SemaphoreSlim"/> does not guarantee FIFO ordering of
///   waiters; relative ordering of two near-simultaneous <see cref="Post"/>
///   calls is unspecified.</item>
/// </list>
/// </summary>
public sealed class SerialSynchronizationContext : SynchronizationContext, IDisposable
{
    private readonly SemaphoreSlim _semaphore = new(1, 1);

    /// <summary>
    /// Raised when a posted callback throws. Because <see cref="Post"/> is
    /// fire-and-forget by contract, exceptions cannot be propagated back to
    /// the caller; subscribe here to surface them (e.g. fault the SSR pump).
    /// </summary>
    public event Action<Exception>? UnhandledException;

    public override SynchronizationContext CreateCopy() => this;

    public override void Post(SendOrPostCallback d, object? state)
    {
        _ = RunAsync(d, state);
    }

    private async Task RunAsync(SendOrPostCallback callback, object? state)
    {
        await _semaphore.WaitAsync().ConfigureAwait(false);
        try
        {
            SetSynchronizationContext(this);
            callback(state);
        }
        catch (Exception ex)
        {
            UnhandledException?.Invoke(ex);
        }
        finally
        {
            SetSynchronizationContext(null);
            _semaphore.Release();
        }
    }

    public override void Send(SendOrPostCallback d, object? state)
        => throw new NotSupportedException(
            $"{nameof(SerialSynchronizationContext)} does not support synchronous {nameof(Send)}.");

    public void Dispose() => _semaphore.Dispose();
}
