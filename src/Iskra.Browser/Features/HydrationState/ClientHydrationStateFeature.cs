using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;
using System.Text.Json.Nodes;
using Iskra.Browser.Abstractions.Features.HydrationState;
using Iskra.Dom.Features.HydrationState;
using Iskra.JSCore;
using Iskra.StdWeb;

namespace Iskra.Browser.Features.HydrationState;

/// <summary>
/// Client-side <see cref="IClientHydrationStateFeature"/> implementation.
/// Create one instance per app and register it on the <see cref="IskraHostBuilder"/>
/// before mounting. <see cref="Value"/> is populated lazily on first access by reading
/// the <c>&lt;script type="application/json"&gt;</c> element identified by
/// <see cref="ScriptElementId"/> from the DOM. If no element is found,
/// <see cref="Value"/> remains an empty <see cref="JsonObject"/>.
/// </summary>
[SupportedOSPlatform("browser")]
public sealed class ClientHydrationStateFeature : IClientHydrationStateFeature
{
    /// <summary>
    /// The <c>id</c> of the <c>&lt;script&gt;</c> element to read from.
    /// Defaults to <see cref="HydrationStateDefaults.ScriptElementId"/>.
    /// Must match the value used when rendering the server-side hydration state script.
    /// </summary>
    public string ScriptElementId { get; init; } = HydrationStateDefaults.ScriptElementId;

    private JsonObject? _value;

    public JsonObject Value
    {
        get
        {
            _value ??= LoadFromDom();
            return _value;
        }
    }

    [SupportedOSPlatform("browser")]
    private JsonObject LoadFromDom()
    {
        var window = JSObjectProxyFactory.GetProxy<Window>(JSHost.GlobalThis);
        var element = window.Document.GetElementById(ScriptElementId);
        if (element is null)
        {
            return [];
        }

        var text = element.TextContent ?? string.Empty;
        return JsonNode.Parse(text)?.AsObject() ?? [];
    }
}
