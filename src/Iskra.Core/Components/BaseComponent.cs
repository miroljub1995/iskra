using Iskra.Core.Features;
using Iskra.Core.HotReload;
using Iskra.Core.RenderRoot;
using Iskra.Signals;

namespace Iskra.Core.Components;

public abstract class BaseComponent<TProps, TEvents, TExpose> : IComponent
    where TEvents : BaseEmits
{
    private EffectScope? _effectScope;
    private readonly List<Action<Action<Action>>> _onMountedCallbacks = [];
    private readonly List<Action> _onUnmountedActions = [];

    public required TProps Props { get; init; }
    public TEvents? Events { get; init; }
    public ISignal<TExpose?>? Ref { get; init; }

    protected void OnMounted(Action<Action<Action>> callback)
    {
        if (OperatingSystem.IsBrowser())
        {
            _onMountedCallbacks.Add(callback);
        }
    }

    protected void OnUnmounted(Action callback)
    {
        if (OperatingSystem.IsBrowser())
        {
            _onUnmountedActions.Add(callback);
        }
    }

    public void Mount(IRenderSlot slot)
    {
        var parentFeatures = AppFeatures.Current
            ?? throw new InvalidOperationException(
                "AppFeatures.Current must be set before mounting a component. " +
                "Components must be mounted via IskraHost.Mount or as a child of another mounting component.");

        // Each component gets its own layer that falls back to the parent's features.
        // Writes inside Setup land only in this layer, so siblings are isolated.
        var ownFeatures = new FeatureCollection(parentFeatures);
        var hotReloadManager = parentFeatures.Get<IHotReloadManager>();

        if (_effectScope is not null)
        {
            throw new InvalidOperationException("Component is already mounted.");
        }

        _effectScope = new();
        _effectScope.Run(() =>
        {
            IComponent[] instances;
            TExpose exposed;

            var prevFeatures = AppFeatures.Current;
            AppFeatures.Current = ownFeatures;
            try
            {
                instances = Setup(Props, Events, out exposed);
                if (Ref is not null)
                {
                    Ref.Value = exposed;
                    new Effect(onCleanup => onCleanup(() => Ref.Value = default));
                }

                // Mount instances
                foreach (var instance in instances)
                {
                    instance.Mount(slot);
                }
            }
            finally
            {
                AppFeatures.Current = prevFeatures;
            }

            if (slot is IDomRenderSlot)
            {
                new Effect(onCleanup =>
                {
                    foreach (var callback in _onMountedCallbacks)
                    {
                        callback(OnUnmounted);
                    }

                    SetupHotReload(hotReloadManager, slot, parentFeatures, onCleanup);

                    onCleanup(() =>
                    {
                        Events?.Disable();

                        // Unmount instances
                        foreach (var instance in instances)
                        {
                            instance.Unmount();
                        }

                        foreach (var action in _onUnmountedActions)
                        {
                            action();
                        }
                    });
                });
            }
        });
    }

    public void Unmount()
    {
        if (_effectScope is null)
        {
            throw new InvalidOperationException("Component is not mounted.");
        }

        _effectScope.Dispose();
        _effectScope = null;
        _onMountedCallbacks.Clear();
        _onUnmountedActions.Clear();
    }

    private void SetupHotReload(
        IHotReloadManager? hotReloadManager,
        IRenderSlot slot,
        IFeatureCollection parentFeatures,
        Action<Action> onCleanup)
    {
        if (hotReloadManager is null)
        {
            return;
        }

        void OnDeltaApplied(Type[]? types)
        {
            if (types is null || types.Contains(GetType()))
            {
                Unmount();

                var prev = AppFeatures.Current;
                AppFeatures.Current = parentFeatures;
                try
                {
                    Mount(slot);
                }
                finally
                {
                    AppFeatures.Current = prev;
                }
            }
        }

        hotReloadManager.OnDeltaApplied += OnDeltaApplied;
        onCleanup(() => hotReloadManager.OnDeltaApplied -= OnDeltaApplied);
    }

    protected abstract IComponent[] Setup(TProps props, TEvents? events, out TExpose exposed);
}