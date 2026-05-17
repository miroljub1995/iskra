using Iskra.Core.Components;
using Iskra.Core.DomComponents;
using Iskra.Core.RenderRoot;
using Iskra.Signals;

namespace Iskra.Core.Features.HydrationState;

/// <summary>
/// Server-side component that serializes hydration state into the SSR output.
///
/// Place this component early in the root component's child list. On render,
/// it calls <see cref="IServerHydrationStateFeature.Dehydrate"/> and emits a
/// <c>&lt;script type="application/json" id="<see cref="ScriptElementId"/>"&gt;</c>
/// element containing the serialized JSON. The client reads that element via
/// <see cref="ClientHydrationStateFeature"/>.
/// </summary>
public sealed class HydrationStateScript : IComponent
{
    /// <summary>
    /// The default <c>id</c> attribute value used for the injected <c>&lt;script&gt;</c> element.
    /// See <see cref="HydrationStateDefaults.ScriptElementId"/>.
    /// </summary>
    public const string DefaultScriptElementId = HydrationStateDefaults.ScriptElementId;

    /// <summary>
    /// The <c>id</c> attribute value used for the injected <c>&lt;script&gt;</c> element.
    /// Defaults to <see cref="DefaultScriptElementId"/>. Override to avoid conflicts with other instances.
    /// </summary>
    public IReadOnlySignal<string> ScriptElementId { get; init; } = new Signal<string>(DefaultScriptElementId);

    private Script? _script;

    public void Mount(IRenderSlot slot)
    {
        if (_script is not null)
        {
            throw new InvalidOperationException("Component is already mounted.");
        }

        var serverFeature = AppFeatures.Features.Get<IServerHydrationStateFeature>()
            ?? throw new InvalidOperationException(
                $"{nameof(IServerHydrationStateFeature)} is not registered. " +
                $"Register {nameof(ServerHydrationStateFeature)} before mounting.");

        var jsonText = new Computed<string>(() => serverFeature.Dehydrate().ToJsonString());

        _script = new Script
        {
            Props = new ScriptProps
            {
                Id = ScriptElementId,
                Type = new Signal<string>("application/json"),
            },
            Children = [new DomText { Text = jsonText }],
        };

        _script.Mount(slot);
    }

    public void Unmount()
    {
        _script?.Unmount();
        _script = null;
    }
}
