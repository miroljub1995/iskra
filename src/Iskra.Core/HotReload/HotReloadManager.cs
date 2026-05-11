using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata;

[assembly: MetadataUpdateHandler(typeof(Iskra.Core.HotReload.HotReloadManager))]

namespace Iskra.Core.HotReload;

public sealed class HotReloadManager : IHotReloadManager
{
    public static readonly HotReloadManager Default = new();

    [FeatureSwitchDefinition("System.Reflection.Metadata.MetadataUpdater.IsSupported")]
    internal static bool IsSupported =>
        AppContext.TryGetSwitch("System.Reflection.Metadata.MetadataUpdater.IsSupported", out bool isSupported) ? isSupported : true;

    public event Action<Type[]?>? OnDeltaApplied;

    public static void UpdateApplication(Type[]? types) => Default.OnDeltaApplied?.Invoke(types);
}
