namespace Iskra.Core.Features;

/// <summary>
/// Default <see cref="ISsrConcurrencyGateFeature"/> implementation backed by a
/// <see cref="SerialSynchronizationContext"/>.
/// </summary>
public sealed class SsrConcurrencyGateFeature : ISsrConcurrencyGateFeature, IDisposable
{
    private readonly SerialSynchronizationContext _ctx = new();

    /// <summary>
    /// Raised when a posted continuation that is not part of the awaited work
    /// chain throws (e.g. a fire-and-forget <c>Task.Run</c> whose continuation
    /// faulted). Exceptions inside the work passed to <see cref="RunExclusiveAsync"/>
    /// are surfaced through the returned <see cref="Task"/> instead.
    /// </summary>
    public event Action<Exception>? UnhandledException
    {
        add => _ctx.UnhandledException += value;
        remove => _ctx.UnhandledException -= value;
    }

    public Task RunExclusiveAsync(Func<Task> work)
    {
        ArgumentNullException.ThrowIfNull(work);

        var tcs = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);

        // Post the work into the gate so its very first synchronous segment
        // runs under the serial context (and the gate's semaphore). Awaits
        // inside work() capture this context and re-enter the gate for each
        // continuation, giving end-to-end serialization.
        _ctx.Post(static async s =>
        {
            var (work, tcs) = ((Func<Task>, TaskCompletionSource))s!;
            try
            {
                await work();
                tcs.TrySetResult();
            }
            catch (Exception ex)
            {
                tcs.TrySetException(ex);
            }
        }, (work, tcs));

        return tcs.Task;
    }

    public void Dispose() => _ctx.Dispose();
}
