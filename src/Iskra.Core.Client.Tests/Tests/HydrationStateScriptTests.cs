using System.Runtime.InteropServices.JavaScript;
using System.Text.Json.Nodes;
using Iskra.Core.Features.HydrationState;
using Iskra.JSCore;
using Iskra.StdWeb;

namespace Iskra.Core.Client.Tests;

public class HydrationStateScriptTests
{
    [Test]
    public async Task Value_is_empty_when_no_script_in_document()
    {
        var feature = new ClientHydrationStateFeature();

        await Assert.That(feature.Value.Count).IsEqualTo(0);
    }

    [Test]
    public async Task Populates_value_from_document_script()
    {
        var window = JSObjectProxyFactory.GetProxy<Window>(JSHost.GlobalThis);
        var script = CreateAndInsertScript(window, "{\"count\":42,\"name\":\"iskra\"}");
        try
        {
            var feature = new ClientHydrationStateFeature();

            await Assert.That(feature.Value.Count).IsEqualTo(2);
            await Assert.That((int?)feature.Value["count"]).IsEqualTo(42);
            await Assert.That((string?)feature.Value["name"]).IsEqualTo("iskra");
        }
        finally
        {
            window.Document.Body!.RemoveChild(script);
        }
    }

    [Test]
    public async Task Nested_json_object_is_deserialized()
    {
        var window = JSObjectProxyFactory.GetProxy<Window>(JSHost.GlobalThis);
        var script = CreateAndInsertScript(window, "{\"user\":{\"id\":1,\"role\":\"admin\"}}");
        try
        {
            var feature = new ClientHydrationStateFeature();

            var user = feature.Value["user"]?.AsObject();
            await Assert.That(user).IsNotNull();
            await Assert.That((int?)user!["id"]).IsEqualTo(1);
            await Assert.That((string?)user["role"]).IsEqualTo("admin");
        }
        finally
        {
            window.Document.Body!.RemoveChild(script);
        }
    }

    [Test]
    public async Task Value_is_mutable_after_initialization()
    {
        var window = JSObjectProxyFactory.GetProxy<Window>(JSHost.GlobalThis);
        var script = CreateAndInsertScript(window, "{\"x\":1}");
        try
        {
            var feature = new ClientHydrationStateFeature();
            feature.Value["y"] = 2;

            await Assert.That((int?)feature.Value["x"]).IsEqualTo(1);
            await Assert.That((int?)feature.Value["y"]).IsEqualTo(2);
        }
        finally
        {
            window.Document.Body!.RemoveChild(script);
        }
    }

    [Test]
    public async Task Reads_from_custom_script_element_id()
    {
        var window = JSObjectProxyFactory.GetProxy<Window>(JSHost.GlobalThis);
        const string customId = "my-custom-hydration-id";
        var script = CreateAndInsertScript(window, "{\"a\":1}", customId);
        try
        {
            var feature = new ClientHydrationStateFeature { ScriptElementId = customId };

            await Assert.That((int?)feature.Value["a"]).IsEqualTo(1);
        }
        finally
        {
            window.Document.Body!.RemoveChild(script);
        }
    }

    private static Element CreateAndInsertScript(
        Window window,
        string json,
        string id = HydrationStateScript.DefaultScriptElementId)
    {
        var script = window.Document.CreateElement("script");
        script.SetAttribute("type", "application/json");
        script.SetAttribute("id", id);
        script.TextContent = json;
        window.Document.Body!.AppendChild(script);
        return script;
    }
}
