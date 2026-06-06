using Iskra.Core.Components;
using Iskra.Core.Features;
using Iskra.Dom.Features.HydrationState;
using Iskra.Ssr.Abstractions.Features.HydrationState;
using Iskra.Core.RenderRoot;
using Iskra.Signals;
using Iskra.Ssr.Abstractions.RenderRoot;

namespace Iskra.Ssr.Features.HydrationState;

public sealed class HydrationStateScript : IComponent
{
    public const string DefaultScriptElementId = HydrationStateDefaults.ScriptElementId;

    public IReadOnlySignal<string> ScriptElementId { get; init; } = new Signal<string>(DefaultScriptElementId);

    private IRenderSlot? _slot;

    public void Mount(IRenderSlot slot)
    {
        if (_slot is not null)
        {
            throw new InvalidOperationException("Component is already mounted.");
        }

        var serverFeature = AppFeatures.Features.Get<IServerHydrationStateFeature>()
            ?? throw new InvalidOperationException(
                $"{nameof(IServerHydrationStateFeature)} is not registered. " +
                $"Register {nameof(ServerHydrationStateFeature)} before mounting.");

        var jsonText = serverFeature.Dehydrate().ToJsonString();

        if (slot is not ISsrRenderSlot ssrRenderSlot)
        {
            throw new InvalidOperationException("HydrationStateScript requires an ISsrRenderSlot in SSR rendering.");
        }

        var scriptNode = new SsrElementNode { TagName = "script", IsVoid = false };
        scriptNode.SetAttribute("id", ScriptElementId);
        scriptNode.SetAttribute("type", new Signal<string>("application/json"));

        var childRoot = ssrRenderSlot.CreateChildRoot(scriptNode);
        if (childRoot.CreateFirstSlot() is ISsrRenderSlot textSlot)
        {
            textSlot.Populate(new SsrTextNode { TextContent = new Signal<string>(jsonText) });
        }

        ssrRenderSlot.Populate(scriptNode);

        _slot = slot;
    }

    public void Unmount()
    {
        if (_slot is not ISsrRenderSlot ssrRenderSlot)
        {
            throw new InvalidOperationException("HydrationStateScript expected ISsrRenderSlot during unmount.");
        }

        ssrRenderSlot.Empty();
        _slot = null;
    }
}