using Iskra.Core.RenderRoot;

namespace Iskra.Core.Components;

public class ComposedComponent(IComponent[] components) : IComponent
{
    private IRenderSlot[]? _slots;

    public void Mount(IRenderSlot slot)
    {
        if (components.Length > 0)
        {
            _slots = new IRenderSlot[components.Length];
            _slots[0] = slot;

            for (int i = 1; i < components.Length; i++)
            {
                _slots[i] = _slots[i - 1].ClaimOrCreateSlotAfter();
            }

            for (int i = 0; i < components.Length; i++)
            {
                components[i].Mount(_slots[i]);
            }
        }
    }

    public void Unmount()
    {
        for (int i = components.Length - 1; i >= 0; i--)
        {
            components[i].Unmount();
        }

        if (_slots is not null)
        {
            for (int i = _slots.Length - 1; i >= 1; i--)
            {
                _slots[i].Dispose();
            }

            _slots = null;
        }
    }
}
