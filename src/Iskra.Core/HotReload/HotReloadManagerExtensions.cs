using System.Diagnostics.CodeAnalysis;
using Iskra.Core.Components;
using Iskra.Core.Features;
using Iskra.Core.RenderRoot;
using Iskra.Signals;

namespace Iskra.Core.HotReload;

public static class HotReloadManagerExtensions
{
    public static void SetupComponentHotReload(
        this IFeatureCollection features,
        IComponent component,
        IRenderSlot slot)
    {
        features.Get<IHotReloadManager>()?.SetupComponentHotReload(component, slot, features);
    }

    [UnconditionalSuppressMessage("Trimming", "IL2026", Justification = "Only used during hot reload with the interpreter; no trimming occurs.")]
    public static void SetupComponentHotReload(
        this IHotReloadManager hotReloadManager,
        IComponent component,
        IRenderSlot slot,
        IFeatureCollection parentFeatures)
    {
        if (!HotReloadManager.IsSupported)
        {
            return;
        }

        var graph = hotReloadManager.Graph;
        var componentType = component.GetType();

        void OnDeltaApplied(Type[]? types)
        {
            if (types is null || graph.IsDependentTo(componentType, types))
            {
                component.Unmount();

                var prev = AppFeatures.Current;
                AppFeatures.Current = parentFeatures;
                try
                {
                    component.Mount(slot);
                }
                finally
                {
                    AppFeatures.Current = prev;
                }
            }
        }

        hotReloadManager.OnDeltaApplied += OnDeltaApplied;
        new Effect(onCleanup => onCleanup(() => hotReloadManager.OnDeltaApplied -= OnDeltaApplied));
    }
}
