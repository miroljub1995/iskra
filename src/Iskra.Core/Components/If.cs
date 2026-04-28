using Iskra.Core.RenderRoot;
using Iskra.Signals;

namespace Iskra.Core.Components;

public class If : IComponent
{
    public required IReadOnlySignal<bool> Condition { get; init; }
    public required Func<IComponent[]> Then { get; init; }
    public Func<IComponent[]>? Otherwise { get; init; }

    private readonly EffectScope _effectScope = new();

    private sealed record BranchState(bool Value, EffectScope Scope, IReadOnlyList<IRenderSlot> Slots, IReadOnlyList<IComponent> Components);

    public void Mount(IRenderSlot slot)
    {
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
                    current = new BranchState(value, new EffectScope(), Array.Empty<IRenderSlot>(), Array.Empty<IComponent>());
                    return;
                }

                var branchSlots = new List<IRenderSlot>();
                var branchComponents = new List<IComponent>();
                var branchScope = new EffectScope();
                branchScope.Run(() =>
                {
                    var children = factory();
                    var prevSlot = slot;
                    for (int i = 0; i < children.Length; i++)
                    {
                        var compSlot = prevSlot.CreateSlotAfter();
                        branchSlots.Add(compSlot);
                        branchComponents.Add(children[i]);
                        children[i].Mount(compSlot);
                        prevSlot = compSlot;
                        var child = children[i];
                        new Effect(onCleanup => onCleanup(() =>
                        {
                            child.Unmount();
                            compSlot.Dispose();
                        }));
                    }
                });

                current = new BranchState(value, branchScope, branchSlots, branchComponents);
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
