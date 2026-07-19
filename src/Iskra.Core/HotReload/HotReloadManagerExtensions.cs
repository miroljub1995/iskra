using System.Diagnostics.CodeAnalysis;
using Iskra.Core.Components;
using Iskra.Core.Features;
using Iskra.Signals;

namespace Iskra.Core.HotReload;

public static class HotReloadManagerExtensions
{
    public static void SetupComponentHotReload(
        this IFeatureCollection features,
        IComponent component,
        Func<EffectScope> mount)
    {
        var manager = features.Get<IHotReloadManager>();
        if (manager is null)
        {
            // No hot reload manager available: just mount once.
            mount();
            return;
        }

        manager.SetupComponentHotReload(component, mount);
    }

    [UnconditionalSuppressMessage("Trimming", "IL2026", Justification = "Only used during hot reload with the interpreter; no trimming occurs.")]
    public static void SetupComponentHotReload(
        this IHotReloadManager hotReloadManager,
        IComponent component,
        Func<EffectScope> mount)
    {
        if (!HotReloadManager.IsSupported)
        {
            mount();
            return;
        }

        var graph = hotReloadManager.Graph;
        var componentType = component.GetType();

        // The current mount scope, owned here: disposed on before-delta and recreated
        // on after-delta, and disposed for good when the component is really unmounted.
        EffectScope? mountScope = null;

        // Set once this component is really unmounted (its outer scope disposed, e.g.
        // via a parent's rebuild). Event dispatch iterates a snapshot of subscribers,
        // so a handler can still fire after the component is gone; this makes it a no-op.
        var disposed = false;

        void OnBeforeDeltaApplied(Type[]? types)
        {
            if (disposed)
            {
                return;
            }

            if (types is null || graph.IsDependentTo(componentType, types))
            {
                Console.WriteLine("[HotReload] Remounting " + componentType);
                mountScope?.Dispose();
                mountScope = null;
            }
        }

        void OnDeltaApplied(Type[]? types)
        {
            if (disposed)
            {
                return;
            }

            if (types is null || graph.IsDependentTo(componentType, types))
            {
                mountScope = mount();
            }
        }

        // Subscribe BEFORE the initial mount so a parent registers ahead of the
        // descendants it mounts: parent-first dispatch.
        hotReloadManager.OnBeforeDeltaApplied += OnBeforeDeltaApplied;
        hotReloadManager.OnDeltaApplied += OnDeltaApplied;
        new Effect(onCleanup => onCleanup(() =>
        {
            disposed = true;
            hotReloadManager.OnBeforeDeltaApplied -= OnBeforeDeltaApplied;
            hotReloadManager.OnDeltaApplied -= OnDeltaApplied;
            mountScope?.Dispose();
            mountScope = null;
        }));

        mountScope = mount();
    }
}
