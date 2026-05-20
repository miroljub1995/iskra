using System.Reflection.Metadata;
using Iskra.Core.Components;
using Iskra.Core.DomComponents;
using Iskra.Core.RenderRoot;
using Iskra.Signals;

namespace Iskra.Core.HotReload;

public sealed class BrowserRefreshScript : IComponent
{
    private Script? _script = MetadataUpdater.IsSupported
        ? new Script
        {
            Props = new ScriptProps
            {
                Src = new Signal<string>("/_framework/aspnetcore-browser-refresh.js"),
            },
        }
        : null;

    public void Mount(IRenderSlot slot)
    {
        _script?.Mount(slot);
    }

    public void Unmount()
    {
        _script?.Unmount();
        _script = null;
    }
}
