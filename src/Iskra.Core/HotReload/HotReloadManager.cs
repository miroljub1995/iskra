using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata;

[assembly: MetadataUpdateHandler(typeof(Iskra.Core.HotReload.HotReloadManager))]

namespace Iskra.Core.HotReload;

public sealed class HotReloadManager : IHotReloadManager
{
    public static readonly HotReloadManager Default = new();

    public static bool IsSupported => MetadataUpdater.IsSupported;

    public event Action<Type[]?>? OnBeforeDeltaApplied;

    public event Action<Type[]?>? OnDeltaApplied;

    [UnconditionalSuppressMessage("Trimming", "IL2026", Justification = "Only used during hot reload with the interpreter; no trimming occurs.")]
    public TypeDependencyGraph Graph { get; } = new();

    public void FireBeforeUpdate(Type[]? types)
    {
        Console.WriteLine("[Iskra] BeforeUpdate — old code still in memory 2");
        OnBeforeDeltaApplied?.Invoke(types);
    }

    [UnconditionalSuppressMessage("Trimming", "IL2026", Justification = "Only used during hot reload with the interpreter; no trimming occurs.")]
    public static void UpdateApplication(Type[]? types)
    {
        // Remount using the same (pre-delta) graph the before-phase used, so the
        // set of components remounted matches the set that was unmounted.
        Default.OnDeltaApplied?.Invoke(types);

        // Then invalidate the changed types so the next cycle rescans them against
        // the newly applied code.
        if (types is not null)
        {
            Default.Graph.Invalidate(types);
        }
    }
}
