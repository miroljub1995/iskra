namespace Iskra.Core.Features;

/// <summary>
/// SSR-only feature that serializes asynchronous host-managed work to a
/// single in-flight operation per host.
///
/// Implementations install a <see cref="SerialSynchronizationContext"/> for
/// the duration of <see cref="RunExclusiveAsync"/>, so any <c>await</c>
/// continuation captured during the work is automatically posted back through
/// the same gate. This allows reactive primitives (signals, effects, scopes)
/// to remain lock-free while still being safe under SSR pipelines that resume
/// continuations on thread-pool threads.
///
/// Typical usage: register a single instance on the host's
/// <see cref="IFeatureCollection"/>; the framework wraps prefetch drains and
/// other host-managed callbacks in <see cref="RunExclusiveAsync"/>.
/// </summary>
public interface ISsrConcurrencyGateFeature
{
    /// <summary>
    /// Installs the gate's <see cref="SynchronizationContext"/> on the calling
    /// thread, invokes <paramref name="work"/>, and asynchronously waits for
    /// it to complete. While installed, every awaited continuation produced by
    /// <paramref name="work"/> (or by code it awaits) is serialized through
    /// the gate — at most one runs at a time per host.
    /// </summary>
    Task RunExclusiveAsync(Func<Task> work);
}
