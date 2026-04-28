using Iskra.Core.Components;

namespace Iskra.Core.Client.Tests.TestUtils;

public class LifecycleProbeProps
{
    public Action? OnSetup { get; init; }
    public Action? OnMounted { get; init; }
    public Action? OnUnmounted { get; init; }
}

public sealed class LifecycleProbeExpose;

/// <summary>
/// Test-only component that invokes the supplied callbacks when its
/// Setup, Mounted and Unmounted lifecycle phases run. Useful for
/// asserting lifecycle behaviour in unit tests.
/// </summary>
public class LifecycleProbe : BaseComponent<LifecycleProbeProps, BaseEmits, LifecycleProbeExpose>
{
    protected override IComponent[] Setup(
        LifecycleProbeProps props,
        BaseEmits? events,
        out LifecycleProbeExpose exposed)
    {
        exposed = new LifecycleProbeExpose();

        props.OnSetup?.Invoke();

        OnMounted(_ =>
        {
            props.OnMounted?.Invoke();
        });

        OnUnmounted(() =>
        {
            props.OnUnmounted?.Invoke();
        });

        return [];
    }
}
