namespace Iskra.Ssr.Abstractions.Features;

/// <summary>
/// SSR-only feature that lets components register asynchronous prefetch
/// callbacks during their <c>Setup</c> phase. Modeled after Vue's
/// <c>onServerPrefetch</c>.
/// </summary>
public interface IServerPrefetchFeature
{
    /// <summary>
    /// Enqueues a prefetch callback to be invoked during
    /// <see cref="WaitForCompletionAsync"/>.
    /// </summary>
    void Register(Func<Task> callback);

    /// <summary>
    /// Drains all registered callbacks one at a time. Callbacks registered
    /// while draining (e.g. from cascading prefetches or dynamically mounted
    /// subtrees) are appended to the queue and consumed by the same loop.
    ///
    /// Continues draining even when individual callbacks fault; if one or
    /// more callbacks throw, an <see cref="AggregateException"/> containing
    /// every collected error is thrown after the drain completes.
    /// </summary>
    Task WaitForCompletionAsync(CancellationToken cancellationToken = default);
}
