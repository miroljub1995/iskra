using Iskra.Core.RenderRoot;

namespace Iskra.Core.Features;

/// <summary>
/// Default <see cref="ITeleportFeature"/> implementation.
///
/// Coordinates the handshake between <c>TeleportSlot</c> (which registers
/// the target <see cref="IRenderSlot"/> via <see cref="SetSlot"/>) and
/// <c>Teleport</c> components (which request a slot via
/// <see cref="OnSlotSet"/>).
///
/// When multiple <c>Teleport</c> components share the same UUID, each
/// receives its own slot allocated via <see cref="IRenderSlot.CreateSlotAfter"/>
/// so their children are rendered consecutively inside the
/// <c>TeleportSlot</c> region.
/// </summary>
public sealed class TeleportFeature : ITeleportFeature
{
    private readonly Dictionary<Guid, IRenderSlot> _currentSlot = [];
    private readonly Dictionary<Guid, List<Action<IRenderSlot>>> _pending = [];

    public void SetSlot(Guid uuid, IRenderSlot slot)
    {
        _currentSlot[uuid] = slot;

        if (!_pending.TryGetValue(uuid, out var callbacks))
        {
            return;
        }

        _pending.Remove(uuid);

        foreach (var callback in callbacks)
        {
            var current = _currentSlot[uuid];
            _currentSlot[uuid] = current.CreateSlotAfter();
            callback(current);
        }
    }

    public void OnSlotSet(Guid uuid, Action<IRenderSlot> action)
    {
        if (_currentSlot.TryGetValue(uuid, out var slot))
        {
            _currentSlot[uuid] = slot.CreateSlotAfter();
            action(slot);
            return;
        }

        if (!_pending.TryGetValue(uuid, out var list))
        {
            list = [];
            _pending[uuid] = list;
        }

        list.Add(action);
    }
}
