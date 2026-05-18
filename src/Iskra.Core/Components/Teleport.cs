using Iskra.Core.Features;
using Iskra.Core.RenderRoot;
using Iskra.Signals;

namespace Iskra.Core.Components;

/// <summary>
/// Renders <see cref="Children"/> at the location occupied by the
/// <c>TeleportSlot</c> component returned by
/// <see cref="CreateTeleport(Guid?)"/>, rather than at the
/// <c>Teleport</c> component's own position in the tree.
///
/// When <see cref="Disabled"/> is <c>true</c> the children are rendered
/// in-place (immediately after the <c>Teleport</c>'s own slot) and moved
/// back to the target slot when it becomes <c>false</c> again — without
/// unmounting or remounting them.
///
/// <see cref="ClientOnly"/> (default <c>true</c>) suppresses rendering on
/// the server; children are shown only once the browser mounts the component.
/// Set it to <c>false</c> to also include the children in SSR output.
/// </summary>
public sealed class Teleport : IComponent
{
    public Guid? Uuid { get; init; }
    public IComponent[] Children { get; init; } = [];
    public IReadOnlySignal<bool>? Disabled { get; init; }
    public bool ClientOnly { get; init; } = true;

    private readonly EffectScope _effectScope = new();

    // -----------------------------------------------------------------------
    // Factory — called during Setup of a component to set up the landing zone.
    // -----------------------------------------------------------------------

    /// <summary>
    /// Creates the landing-zone component that should be placed in the
    /// component tree at the position where teleported content should appear.
    ///
    /// Also registers (or reuses) <see cref="ITeleportFeature"/> in
    /// <see cref="AppFeatures"/> so that descendant <see cref="Teleport"/>
    /// components can locate the feature without any additional host
    /// configuration.
    /// </summary>
    public static IComponent CreateTeleport(Guid? uuid = null)
    {
        var resolvedUuid = uuid ?? Guid.Empty;

        var feature = AppFeatures.Features.Get<ITeleportFeature>();
        if (feature is null)
        {
            feature = new TeleportFeature();
            AppFeatures.Features.Set(feature);
        }

        return new TeleportSlot(resolvedUuid, feature);
    }

    // -----------------------------------------------------------------------
    // IComponent
    // -----------------------------------------------------------------------

    public void Mount(IRenderSlot slot)
    {
        var parentFeatures = AppFeatures.Current
            ?? throw new InvalidOperationException(
                "AppFeatures.Current must be set before mounting Teleport.");

        _effectScope.Run(() =>
        {
            var feature = parentFeatures.Get<ITeleportFeature>()
                ?? throw new InvalidOperationException(
                    "ITeleportFeature not found. Call Teleport.CreateTeleport() in an ancestor component's Setup.");

            var resolvedUuid = Uuid ?? Guid.Empty;

            var shouldRender = new Signal<bool>(!ClientOnly || slot is IDomRenderSlot);
            var targetSlot = new Signal<IRenderSlot?>(null);

            // Deliver the slot immediately if TeleportSlot is already mounted,
            // or queue the action to be invoked once it mounts.
            feature.OnSlotSet(resolvedUuid, s => targetSlot.Value = s);

            // Pre-claim the bracket slots for the children range.
            //
            // This is safe because the parent ComposedComponent claims all
            // sibling slots in a first pass before calling Mount on any of
            // them, so the next sibling's slot is already in the list. The
            // two new slots are inserted between Teleport's own slot and its
            // next sibling — the correct in-place position.
            //
            // ComposedComponent will insert its internally created child slots
            // between childrenStart and childrenEnd (because childrenEnd is
            // already claimed, every ClaimOrCreateSlotAfter from childrenStart
            // creates a new slot via AddAfter, which lands before childrenEnd).
            var childrenStart = slot.ClaimOrCreateSlotAfter();
            var childrenEnd = childrenStart.ClaimOrCreateSlotAfter();

            // Non-signal tracking state for the main Effect.
            var childrenMounted = false;
            IRenderSlot? currentTargetSlot = null;

            // Main reactive Effect.
            // Re-runs whenever shouldRender, Disabled, or targetSlot changes.
            new Effect(_ =>
            {
                if (!shouldRender.Value)
                {
                    // ClientOnly=true and not yet in browser — nothing to do.
                    return;
                }

                var ts = targetSlot.Value;
                var disabled = Disabled?.Value ?? false;

                // Not disabled but the TeleportSlot hasn't mounted yet —
                // wait for the next cycle when ts will be set.
                if (!disabled && ts is null)
                {
                    return;
                }

                var wantTarget = !disabled; // ts is non-null whenever wantTarget is true

                // Move the bracket slots to the desired location.
                // On first render the slots are empty so this only relinks the
                // list — no DOM nodes are touched. On subsequent renders this
                // moves the populated range to the new location.
                if (wantTarget && currentTargetSlot != ts)
                {
                    childrenStart.MoveRangeAfter(childrenEnd, ts!);
                    currentTargetSlot = ts;
                }
                else if (!wantTarget && currentTargetSlot is not null)
                {
                    childrenStart.MoveRangeAfter(childrenEnd, slot);
                    currentTargetSlot = null;
                }

                if (!childrenMounted)
                {
                    childrenMounted = true;

                    _effectScope.Run(() =>
                    {
                        ComposedComponent composed;
                        var prevFeatures = AppFeatures.Current;
                        AppFeatures.Current = parentFeatures;
                        try
                        {
                            composed = new ComposedComponent(Children);
                            composed.Mount(childrenStart);
                        }
                        finally
                        {
                            AppFeatures.Current = prevFeatures;
                        }

                        new Effect(onCleanup => onCleanup(() => composed.Unmount()));
                    });
                }
            });

            // Cleanup: release the bracket slots.
            new Effect(onCleanup => onCleanup(() =>
            {
                childrenEnd.Dispose();
                childrenStart.Dispose();
            }));
        });
    }

    public void Unmount()
    {
        _effectScope.Dispose();
    }
}

/// <summary>
/// Landing-zone component returned by <see cref="Teleport.CreateTeleport"/>.
/// Place this in the component tree at the position where teleported content
/// should appear. Its own slot is registered with <see cref="ITeleportFeature"/>
/// so that <see cref="Teleport"/> components can locate it.
/// </summary>
internal sealed class TeleportSlot(Guid uuid, ITeleportFeature feature) : IComponent
{
    public void Mount(IRenderSlot slot)
    {
        feature.SetSlot(uuid, slot);
    }

    public void Unmount()
    {
    }
}
