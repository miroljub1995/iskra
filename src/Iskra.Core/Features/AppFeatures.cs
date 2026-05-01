namespace Iskra.Core.Features;

/// <summary>
/// Ambient access to the currently mounting component's <see cref="IFeatureCollection"/>.
///
/// Backed by <see cref="ThreadLocal{T}"/>: per-thread state, no propagation across
/// <c>await</c>. The framework sets it synchronously around each component's
/// <c>Mount</c> call and resets it to <c>null</c> when the outermost <c>Mount</c>
/// returns. It is only valid to read inside <c>Setup</c> (or other code paths the
/// framework explicitly re-establishes it for, such as delayed children mounted
/// by <see cref="Components.If"/> / <see cref="Components.ForEach{TElement,TKey}"/>).
/// </summary>
public static class AppFeatures
{
    private static readonly ThreadLocal<IFeatureCollection?> _current = new();

    public static IFeatureCollection? Current
    {
        get => _current.Value;
        set => _current.Value = value;
    }

    /// <summary>
    /// Same as <see cref="Current"/> but throws when there is no active features
    /// collection. Use this from inside component <c>Setup</c> code where a
    /// features collection must be available.
    /// </summary>
    public static IFeatureCollection Features =>
        Current ?? throw new InvalidOperationException(
            "AppFeatures.Features accessed outside of a component Mount. " +
            "It is only valid inside Setup (or code paths the framework re-establishes it for).");
}
