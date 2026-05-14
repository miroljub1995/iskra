using Iskra.Core.Features;
using Iskra.Core.RenderRoot;
using Iskra.Signals;

namespace Iskra.Core.Components;

public class If : IComponent
{
    public required IReadOnlySignal<bool> Condition { get; init; }
    public required Func<IComponent[]> Then { get; init; }
    public Func<IComponent[]>? Otherwise { get; init; }

    private readonly EffectScope _effectScope = new();

    private sealed record BranchState(bool Value, EffectScope Scope);

    public void Mount(IRenderSlot slot)
    {
        // Capture the parent features at mount time so that delayed branch flips
        // (e.g., from click handlers / awaited tasks) still see the correct
        // features hierarchy. AppFeatures.Current is null when the effect re-runs
        // outside of a Mount path.
        var parentFeatures = AppFeatures.Current
            ?? throw new InvalidOperationException(
                "AppFeatures.Current must be set before mounting If.");

        _effectScope.Run(() =>
        {
            BranchState? current = null;

            // Reactive Effect: re-runs whenever signals read inside Condition change.
            // On a flip, unmounts the previous branch and mounts the new one.
            new Effect(_ =>
            {
                var value = Condition.Value;

                if (current is not null && current.Value == value)
                {
                    return;
                }

                current?.Scope.Dispose();
                current = null;

                var factory = value ? Then : Otherwise;
                if (factory is null)
                {
                    current = new BranchState(value, new EffectScope());
                    return;
                }

                var branchScope = new EffectScope();
                branchScope.Run(() =>
                {
                    // Re-establish the parent features as the ambient before mounting
                    // children. This is required because the effect can re-run later
                    // (after await / click) when AppFeatures.Current is null.
                    var prevFeatures = AppFeatures.Current;
                    AppFeatures.Current = parentFeatures;
                    try
                    {
                        var composed = new ComposedComponent(factory());
                        composed.Mount(slot);
                        new Effect(onCleanup => onCleanup(() =>
                        {
                            composed.Unmount();
                        }));
                    }
                    finally
                    {
                        AppFeatures.Current = prevFeatures;
                    }
                });

                current = new BranchState(value, branchScope);
            });

            // Cleanup Effect: no signals tracked — only registers teardown for when this component is unmounted.
            new Effect(onCleanup => onCleanup(() =>
            {
                current?.Scope.Dispose();
                current = null;
            }));
        });
    }

    public void Unmount()
    {
        _effectScope.Dispose();
    }
}
