using Iskra.Core.Components;
using Iskra.Core.DomComponents;
using Iskra.Core.RenderRoot;
using Iskra.Signals;

namespace Iskra.Core.Server.Tests.Tests;

/// <summary>
/// Tests for SSR attribute rendering: boolean, enumerated boolean, int, uint, double, nullable string, and enum-mapped attributes.
/// </summary>
public class SsrAttributesTests
{
    // ── Boolean attributes ─────────────────────────────────────────────────────

    [Test]
    public async Task Boolean_attribute_is_bare_when_true()
    {
        var root = new SsrRenderRoot();

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
            .UseRootComponent(() => new Dialog
            {
                Props = new DialogProps { Open = new Signal<bool>(true) },
            })
            .Build()
            .Mount();

        var output = await SsrHelpers.RenderAsync(root);

        await Assert.That(output).IsEqualTo("<dialog open></dialog>");
    }

    [Test]
    public async Task Boolean_attribute_is_absent_when_false()
    {
        var root = new SsrRenderRoot();

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
            .UseRootComponent(() => new Dialog
            {
                Props = new DialogProps { Open = new Signal<bool>(false) },
            })
            .Build()
            .Mount();

        var output = await SsrHelpers.RenderAsync(root);

        await Assert.That(output).IsEqualTo("<dialog></dialog>");
    }

    [Test]
    public async Task Boolean_attribute_is_absent_when_prop_not_set()
    {
        var root = new SsrRenderRoot();

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
            .UseRootComponent(() => new Dialog())
            .Build()
            .Mount();

        var output = await SsrHelpers.RenderAsync(root);

        await Assert.That(output).IsEqualTo("<dialog></dialog>");
    }

    // ── Enumerated boolean attributes ──────────────────────────────────────────

    [Test]
    public async Task Enumerated_boolean_attribute_renders_true_value()
    {
        var root = new SsrRenderRoot();

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
            .UseRootComponent(() => new Div
            {
                Props = new DivProps { Draggable = new Signal<bool>(true) },
            })
            .Build()
            .Mount();

        var output = await SsrHelpers.RenderAsync(root);

        await Assert.That(output).IsEqualTo("<div draggable=\"true\"></div>");
    }

    [Test]
    public async Task Enumerated_boolean_attribute_renders_false_value()
    {
        var root = new SsrRenderRoot();

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
            .UseRootComponent(() => new Div
            {
                Props = new DivProps { Draggable = new Signal<bool>(false) },
            })
            .Build()
            .Mount();

        var output = await SsrHelpers.RenderAsync(root);

        await Assert.That(output).IsEqualTo("<div draggable=\"false\"></div>");
    }

    [Test]
    public async Task Enumerated_boolean_attribute_with_custom_values_renders_yes()
    {
        var root = new SsrRenderRoot();

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
            .UseRootComponent(() => new Div
            {
                Props = new DivProps { Translate = new Signal<bool>(true) },
            })
            .Build()
            .Mount();

        var output = await SsrHelpers.RenderAsync(root);

        await Assert.That(output).IsEqualTo("<div translate=\"yes\"></div>");
    }

    [Test]
    public async Task Enumerated_boolean_attribute_with_custom_values_renders_no()
    {
        var root = new SsrRenderRoot();

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
            .UseRootComponent(() => new Div
            {
                Props = new DivProps { Translate = new Signal<bool>(false) },
            })
            .Build()
            .Mount();

        var output = await SsrHelpers.RenderAsync(root);

        await Assert.That(output).IsEqualTo("<div translate=\"no\"></div>");
    }

    // ── Integer attributes ─────────────────────────────────────────────────────

    [Test]
    public async Task Int_attribute_renders_value()
    {
        var root = new SsrRenderRoot();

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
            .UseRootComponent(() => new Div
            {
                Props = new DivProps { TabIndex = new Signal<int>(3) },
            })
            .Build()
            .Mount();

        var output = await SsrHelpers.RenderAsync(root);

        await Assert.That(output).IsEqualTo("<div tabindex=\"3\"></div>");
    }

    [Test]
    public async Task Int_attribute_renders_negative_value()
    {
        var root = new SsrRenderRoot();

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
            .UseRootComponent(() => new Div
            {
                Props = new DivProps { TabIndex = new Signal<int>(-1) },
            })
            .Build()
            .Mount();

        var output = await SsrHelpers.RenderAsync(root);

        await Assert.That(output).IsEqualTo("<div tabindex=\"-1\"></div>");
    }

    // ── Unsigned integer attributes ────────────────────────────────────────────

    [Test]
    public async Task UInt_attribute_renders_value()
    {
        var root = new SsrRenderRoot();

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
            .UseRootComponent(() => new Canvas
            {
                Props = new CanvasProps
                {
                    Width = new Signal<uint>(800),
                    Height = new Signal<uint>(600),
                },
            })
            .Build()
            .Mount();

        var output = await SsrHelpers.RenderAsync(root);

        await Assert.That(output).IsEqualTo("<canvas height=\"600\" width=\"800\"></canvas>");
    }

    // ── Double attributes ──────────────────────────────────────────────────────

    [Test]
    public async Task Double_attribute_renders_value()
    {
        var root = new SsrRenderRoot();

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
            .UseRootComponent(() => new Meter
            {
                Props = new MeterProps { Value = new Signal<double>(0.5) },
            })
            .Build()
            .Mount();

        var output = await SsrHelpers.RenderAsync(root);

        await Assert.That(output).IsEqualTo("<meter value=\"0.5\"></meter>");
    }

    [Test]
    public async Task Double_attribute_renders_integer_value_without_decimal()
    {
        var root = new SsrRenderRoot();

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
            .UseRootComponent(() => new Meter
            {
                Props = new MeterProps
                {
                    Min = new Signal<double>(0),
                    Max = new Signal<double>(100),
                    Value = new Signal<double>(42),
                },
            })
            .Build()
            .Mount();

        var output = await SsrHelpers.RenderAsync(root);

        await Assert.That(output).IsEqualTo("<meter max=\"100\" min=\"0\" value=\"42\"></meter>");
    }

    // ── Nullable string attributes ─────────────────────────────────────────────

    [Test]
    public async Task Nullable_string_attribute_is_absent_when_null()
    {
        var root = new SsrRenderRoot();

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
            .UseRootComponent(() => new Div
            {
                Props = new DivProps { Popover = new Signal<string?>(null) },
            })
            .Build()
            .Mount();

        var output = await SsrHelpers.RenderAsync(root);

        await Assert.That(output).IsEqualTo("<div></div>");
    }

    [Test]
    public async Task Nullable_string_attribute_renders_when_non_null()
    {
        var root = new SsrRenderRoot();

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
            .UseRootComponent(() => new Div
            {
                Props = new DivProps { Popover = new Signal<string?>("auto") },
            })
            .Build()
            .Mount();

        var output = await SsrHelpers.RenderAsync(root);

        await Assert.That(output).IsEqualTo("<div popover=\"auto\"></div>");
    }

    // ── Hidden attribute (enum-mapped, 3-way) ──────────────────────────────────

    [Test]
    public async Task Hidden_true_renders_bare_attribute()
    {
        var root = new SsrRenderRoot();

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
            .UseRootComponent(() => new Div
            {
                Props = new DivProps { Hidden = new Signal<HiddenOption>(HiddenOption.True) },
            })
            .Build()
            .Mount();

        var output = await SsrHelpers.RenderAsync(root);

        await Assert.That(output).IsEqualTo("<div hidden></div>");
    }

    [Test]
    public async Task Hidden_false_attribute_is_absent()
    {
        var root = new SsrRenderRoot();

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
            .UseRootComponent(() => new Div
            {
                Props = new DivProps { Hidden = new Signal<HiddenOption>(HiddenOption.False) },
            })
            .Build()
            .Mount();

        var output = await SsrHelpers.RenderAsync(root);

        await Assert.That(output).IsEqualTo("<div></div>");
    }

    [Test]
    public async Task Hidden_until_found_renders_with_value()
    {
        var root = new SsrRenderRoot();

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
            .UseRootComponent(() => new Div
            {
                Props = new DivProps { Hidden = new Signal<HiddenOption>(HiddenOption.UntilFound) },
            })
            .Build()
            .Mount();

        var output = await SsrHelpers.RenderAsync(root);

        await Assert.That(output).IsEqualTo("<div hidden=\"until-found\"></div>");
    }

    // ── Reactive signal updates before render ──────────────────────────────────

    [Test]
    public async Task Signal_value_is_read_at_render_time()
    {
        var root = new SsrRenderRoot();
        var idSignal = new Signal<string>("initial");

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
            .UseRootComponent(() => new Div
            {
                Props = new DivProps { Id = idSignal },
            })
            .Build()
            .Mount();

        idSignal.Value = "updated";

        var output = await SsrHelpers.RenderAsync(root);

        await Assert.That(output).IsEqualTo("<div id=\"updated\"></div>");
    }

    // ── Data attributes ────────────────────────────────────────────────────────

    [Test]
    public async Task Data_attributes_render_all_entries()
    {
        var root = new SsrRenderRoot();

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
            .UseRootComponent(() => new Div
            {
                Props = new DivProps
                {
                    Data = new Signal<IDictionary<string, string>>(
                        new Dictionary<string, string> { ["foo"] = "bar", ["baz"] = "qux" }),
                },
            })
            .Build()
            .Mount();

        var output = await SsrHelpers.RenderAsync(root);

        await Assert.That(output).IsEqualTo("<div data-baz=\"qux\" data-foo=\"bar\"></div>");
    }

    [Test]
    public async Task Data_attributes_render_empty_dictionary()
    {
        var root = new SsrRenderRoot();

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
            .UseRootComponent(() => new Div
            {
                Props = new DivProps
                {
                    Data = new Signal<IDictionary<string, string>>(new Dictionary<string, string>()),
                },
            })
            .Build()
            .Mount();

        var output = await SsrHelpers.RenderAsync(root);

        await Assert.That(output).IsEqualTo("<div></div>");
    }

    [Test]
    public async Task Data_attributes_are_reactive()
    {
        var root = new SsrRenderRoot();
        var dataSignal = new Signal<IDictionary<string, string>>(
            new Dictionary<string, string> { ["before"] = "old" });

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
            .UseRootComponent(() => new Div
            {
                Props = new DivProps { Data = dataSignal },
            })
            .Build()
            .Mount();

        dataSignal.Value = new Dictionary<string, string> { ["after"] = "new" };

        var output = await SsrHelpers.RenderAsync(root);

        await Assert.That(output).IsEqualTo("<div data-after=\"new\"></div>");
    }

    [Test]
    public async Task Data_attributes_absent_when_prop_not_set()
    {
        var root = new SsrRenderRoot();

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
            .UseRootComponent(() => new Div())
            .Build()
            .Mount();

        var output = await SsrHelpers.RenderAsync(root);

        await Assert.That(output).IsEqualTo("<div></div>");
    }
}
