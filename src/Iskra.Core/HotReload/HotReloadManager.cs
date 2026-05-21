using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata;

[assembly: MetadataUpdateHandler(typeof(Iskra.Core.HotReload.HotReloadManager))]

namespace Iskra.Core.HotReload;

public sealed class HotReloadManager : IHotReloadManager
{
    public static readonly HotReloadManager Default = new();

    public static bool IsSupported => MetadataUpdater.IsSupported;

    public event Action<Type[]?>? OnDeltaApplied;

    [UnconditionalSuppressMessage("Trimming", "IL2026", Justification = "Only used during hot reload with the interpreter; no trimming occurs.")]
    public TypeDependencyGraph Graph { get; } = new();

    [UnconditionalSuppressMessage("Trimming", "IL2026", Justification = "Only used during hot reload with the interpreter; no trimming occurs.")]
    public static void UpdateApplication(Type[]? types)
    {
        Default.OnDeltaApplied?.Invoke(types);

        if (types is not null)
        {
            Default.Graph.Invalidate(types);
        }
    }
}
