using System.Reflection.Metadata;

[assembly: MetadataUpdateHandler(typeof(Iskra.Core.HotReload.HotReloadManager))]

namespace Iskra.Core.HotReload;

public sealed class HotReloadManager : IHotReloadManager
{
    public static readonly HotReloadManager Default = new();

    public static bool IsSupported => MetadataUpdater.IsSupported;

    public event Action<Type[]?>? OnDeltaApplied;

    public static void UpdateApplication(Type[]? types) => Default.OnDeltaApplied?.Invoke(types);
}
