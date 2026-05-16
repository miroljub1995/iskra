using Iskra.Core.Components;
using Iskra.Core.DomComponents;
using Iskra.Core.RenderRoot;
using Iskra.Signals;

namespace Iskra.Core.Features.HydrationState;

/// <summary>
/// Component that bridges hydration state between server and client.
///
/// Place this component early in the root component's child list so that
/// <see cref="IHydrationStateFeature.Value"/> is populated before any sibling
/// or descendant components mount.
///
/// <list type="bullet">
///   <item>
///     <b>SSR</b>: serializes the current <see cref="IHydrationStateFeature.Value"/>
///     into a <c>&lt;script type="application/json" id="<see cref="ScriptElementId"/>"&gt;</c>
///     element embedded in the SSR output.
///   </item>
///   <item>
///     <b>Client</b>: looks up the element by <see cref="ScriptElementId"/> in the document,
///     deserializes its content, and populates the registered
///     <see cref="ClientHydrationStateFeature"/>. If the element is not found,
///     <see cref="IHydrationStateFeature.Value"/> remains an empty object.
///   </item>
/// </list>
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

        var feature = AppFeatures.Features.Get<IHydrationStateFeature>()
            ?? throw new InvalidOperationException(
                $"{nameof(IHydrationStateFeature)} is not registered. " +
                $"Register {nameof(ServerHydrationStateFeature)} (server) or " +
                $"{nameof(ClientHydrationStateFeature)} (client) before mounting.");

        _script = new Script
        {
            Props = new ScriptProps
            {
                Id = ScriptElementId,
                Type = new Signal<string>("application/json"),
            },
            Children = [new DomText { Text = new Computed<string>(() => feature.Value.ToJsonString()) }],
        };

        _script.Mount(slot);
    }

    public void Unmount()
    {
        _script?.Unmount();
        _script = null;
    }
}
