using Iskra.Core.RenderRoot;

namespace Iskra.Core.Features;

public interface ITeleportFeature
{
    /// <summary>
    /// Called by <c>TeleportSlot</c> when it mounts. Registers the slot at
    /// <paramref name="uuid"/> and immediately delivers it to any
    /// <see cref="OnSlotSet"/> callbacks that were registered before the slot
    /// was available.
    /// </summary>
    void SetSlot(Guid uuid, IRenderSlot slot);

    /// <summary>
    /// Called by <c>Teleport</c> during its mount. If the slot for
    /// <paramref name="uuid"/> is already registered the <paramref name="action"/>
    /// is invoked immediately; otherwise it is queued and invoked once the slot
    /// is registered via <see cref="SetSlot"/>.
    ///
    /// Before invoking <paramref name="action"/>, a new slot is claimed after the
    /// current one so that subsequent callers each receive their own slot.
    /// </summary>
    void OnSlotSet(Guid uuid, Action<IRenderSlot> action);
}
