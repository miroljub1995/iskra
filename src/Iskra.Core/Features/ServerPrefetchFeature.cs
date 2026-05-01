using System.Collections.Concurrent;

namespace Iskra.Core.Features;

/// <summary>
/// Default <see cref="IServerPrefetchFeature"/> implementation backed by a
/// <see cref="ConcurrentQueue{T}"/>. Single-consumer drain with potentially
/// multi-threaded producers (continuations resuming on threadpool threads).
/// </summary>
public sealed class ServerPrefetchFeature : IServerPrefetchFeature
{
    private readonly ConcurrentQueue<Func<Task>> _pending = new();

    public void Register(Func<Task> callback)
    {
        ArgumentNullException.ThrowIfNull(callback);
        _pending.Enqueue(callback);
    }

    public async Task WaitForCompletionAsync(CancellationToken cancellationToken = default)
    {
        List<Exception>? errors = null;

        while (_pending.TryDequeue(out var factory))
        {
            cancellationToken.ThrowIfCancellationRequested();

            try
            {
                await factory().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                errors ??= [];
                errors.Add(ex);
            }
        }

        if (errors is { Count: > 0 })
        {
            throw new AggregateException(errors);
        }
    }
}
