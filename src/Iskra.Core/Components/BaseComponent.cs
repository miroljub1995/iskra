using Iskra.Core.DomComponents;
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

        if (_effectScope is not null)
        {
            throw new InvalidOperationException("Component is already mounted.");
        }

        _effectScope = new();
        _effectScope.Run(() =>
        {
            ComposedComponent composedComponent;

            var prevFeatures = AppFeatures.Current;
            AppFeatures.Current = ownFeatures;
            try
            {
                var setupResult = Setup(Props, Events, out TExpose exposed);

                var openComment = new DomComment { Data = new Signal<string>("[") };
                var closeComment = new DomComment { Data = new Signal<string>("]") };

                composedComponent = new ComposedComponent([openComment, .. setupResult, closeComment]);


                if (Ref is not null)
                {
                    Ref.Value = exposed;
                    new Effect(onCleanup => onCleanup(() => Ref.Value = default));
                }

                composedComponent.Mount(slot);

                parentFeatures.SetupComponentHotReload(this, slot);
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

                    onCleanup(() =>
                    {
                        Events?.Disable();

                        composedComponent?.Unmount();

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

    protected abstract IComponent[] Setup(TProps props, TEvents? events, out TExpose exposed);
}