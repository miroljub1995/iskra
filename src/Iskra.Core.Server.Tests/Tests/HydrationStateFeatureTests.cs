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
            .SetFeature<IServerHydrationStateFeature>(feature)
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
        feature.RegisterDehydrateCallback(obj =>
        {
            obj["count"] = 42;
            obj["name"] = "iskra";
        });

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
            .SetFeature<IServerHydrationStateFeature>(feature)
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

        await Assert.That(feature.Dehydrate().Count).IsEqualTo(0);
    }

    [Test]
    public async Task Value_reflects_in_place_mutations()
    {
        var feature = new ServerHydrationStateFeature();
        feature.RegisterDehydrateCallback(obj => obj["key"] = "value");

        await Assert.That((string?)feature.Dehydrate()["key"]).IsEqualTo("value");
    }

    [Test]
    public async Task State_survives_unmount_and_can_be_re_read()
    {
        var root = new SsrRenderRoot();
        var feature = new ServerHydrationStateFeature();
        feature.RegisterDehydrateCallback(obj => obj["x"] = 7);

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
            .SetFeature<IServerHydrationStateFeature>(feature)
            .UseRootComponent(() => new HydrationStateScript())
            .Build()
            .Mount();

        await Assert.That(feature.Dehydrate().Count).IsEqualTo(1);
        await Assert.That((int?)feature.Dehydrate()["x"]).IsEqualTo(7);
    }

    [Test]
    public async Task Deregistered_callback_is_not_invoked()
    {
        var feature = new ServerHydrationStateFeature();

        void First(JsonObject obj) => obj["first"] = 1;
        void Middle(JsonObject obj) => obj["middle"] = 2;
        void Last(JsonObject obj) => obj["last"] = 3;

        feature.RegisterDehydrateCallback(First);
        feature.RegisterDehydrateCallback(Middle);
        feature.RegisterDehydrateCallback(Last);
        feature.DeregisterDehydrateCallback(Middle);

        var result = feature.Dehydrate();

        await Assert.That(result.Count).IsEqualTo(2);
        await Assert.That((int?)result["first"]).IsEqualTo(1);
        await Assert.That((int?)result["last"]).IsEqualTo(3);
        await Assert.That(result.ContainsKey("middle")).IsEqualTo(false);
    }

    [Test]
    public async Task Renders_script_with_custom_element_id()
    {
        var root = new SsrRenderRoot();
        var feature = new ServerHydrationStateFeature();
        const string customId = "my-custom-hydration-id";

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
            .SetFeature<IServerHydrationStateFeature>(feature)
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
