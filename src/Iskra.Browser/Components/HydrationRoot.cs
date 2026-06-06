using Iskra.Core;
using Iskra.Core.Components;
using Iskra.Core.Features;
using Iskra.Browser.Abstractions.Features.HydrationState;
using Iskra.Core.RenderRoot;

namespace Iskra.Browser.Components;

public sealed class HydrationRoot : IComponent
{
    public IComponent[] Children { get; init; } = [];
    private ComposedComponent? _composed;

    public void Mount(IRenderSlot slot)
    {
        if (!OperatingSystem.IsBrowser())
        {
            throw new PlatformNotSupportedException();
        }

        if (_composed is not null)
        {
            throw new InvalidOperationException("Component is already mounted.");
        }

        if (slot is not DomRenderSlot domSlot)
        {
            throw new InvalidOperationException("HydrationRoot requires DomRenderSlot in browser rendering.");
        }

        var root = domSlot.Root;

        var hydrationState = AppFeatures.Features.Get<IClientHydrationStateFeature>();
        if (hydrationState is not null && (bool?)hydrationState.Value["hydrate"] == true)
        {
            root.BeginHydration();
        }

        _composed = new ComposedComponent(Children);
        _composed.Mount(slot);

        root.EndHydration();
    }

    public void Unmount()
    {
        _composed?.Unmount();
        _composed = null;
    }
}
