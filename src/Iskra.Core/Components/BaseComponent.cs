using Iskra.Core.RenderRoot;
using Iskra.Signals;

namespace Iskra.Core.Components;

public abstract class BaseComponent<TProps, TEvents, TExpose> : IComponent
    where TEvents : BaseEmits
{
    private readonly EffectScope _effectScope = new();
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
        _effectScope.Run(() =>
        {
            var instances = Setup(Props, Events, out var exposed);
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

            foreach (var callback in _onMountedCallbacks)
            {
                callback(OnUnmounted);
            }

            new Effect(onCleanup => onCleanup(() =>
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
            }));
        });
    }

    public void Unmount()
    {
        _effectScope.Dispose();
    }

    protected abstract IComponent[] Setup(TProps props, TEvents? events, out TExpose exposed);
}