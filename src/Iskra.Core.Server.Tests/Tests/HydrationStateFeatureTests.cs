using System.Text.Json.Nodes;
using Iskra.Core.Features.HydrationState;
using Iskra.Core.RenderRoot;
using Iskra.Signals;

namespace Iskra.Core.Server.Tests.Tests;

public class HydrationStateFeatureTests
{
    [Test]
    public async Task Renders_empty_script_when_value_is_empty()
    {
        var root = new SsrRenderRoot();
        var feature = new ServerHydrationStateFeature();

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
            .SetFeature<IHydrationStateFeature>(feature)
            .UseRootComponent(() => new HydrationStateScript())
            .Build()
            .Mount();

        var output = await SsrHelpers.RenderAsync(root);

        await Assert.That(output).IsEqualTo(
            $"<script id=\"{HydrationStateScript.DefaultScriptElementId}\" type=\"application/json\">{{}}"+ "</script>");
    }

    [Test]
    public async Task Renders_serialized_json_when_value_is_populated()
    {
        var root = new SsrRenderRoot();
        var feature = new ServerHydrationStateFeature();
        feature.Value["count"] = 42;
        feature.Value["name"] = "iskra";

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
            .SetFeature<IHydrationStateFeature>(feature)
            .UseRootComponent(() => new HydrationStateScript())
            .Build()
            .Mount();

        var output = await SsrHelpers.RenderAsync(root);

        await Assert.That(output).IsEqualTo(
            $"<script id=\"{HydrationStateScript.DefaultScriptElementId}\" type=\"application/json\">{{\"count\":42,\"name\":\"iskra\"}}</script>");
    }

    [Test]
    public async Task Value_starts_as_empty_json_object()
    {
        var feature = new ServerHydrationStateFeature();

        await Assert.That(feature.Value.Count).IsEqualTo(0);
    }

    [Test]
    public async Task Value_reflects_in_place_mutations()
    {
        var feature = new ServerHydrationStateFeature();
        feature.Value["key"] = "value";

        await Assert.That((string?)feature.Value["key"]).IsEqualTo("value");
    }

    [Test]
    public async Task State_survives_unmount_and_can_be_re_read()
    {
        var root = new SsrRenderRoot();
        var feature = new ServerHydrationStateFeature();
        feature.Value["x"] = 7;

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
            .SetFeature<IHydrationStateFeature>(feature)
            .UseRootComponent(() => new HydrationStateScript())
            .Build()
            .Mount();

        await Assert.That(feature.Value.Count).IsEqualTo(1);
        await Assert.That((int?)feature.Value["x"]).IsEqualTo(7);
    }

    [Test]
    public async Task Renders_script_with_custom_element_id()
    {
        var root = new SsrRenderRoot();
        var feature = new ServerHydrationStateFeature();
        const string customId = "my-custom-hydration-id";

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
            .SetFeature<IHydrationStateFeature>(feature)
            .UseRootComponent(() => new HydrationStateScript
            {
                ScriptElementId = new Signal<string>(customId),
            })
            .Build()
            .Mount();

        var output = await SsrHelpers.RenderAsync(root);

        await Assert.That(output).IsEqualTo(
            $"<script id=\"{customId}\" type=\"application/json\">{{}}</script>");
    }
}
