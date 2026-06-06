using Iskra.Core;
using Iskra.Core.Components;
using Iskra.Dom.Components;
using Iskra.Core.RenderRoot;
using Iskra.Ssr.RenderRoot;
using Iskra.Signals;

namespace Iskra.Ssr.Tests.Tests;

public class ForEachTests
{
    // Each item renders two <span> elements so that ComposedComponent holds
    // multiple slots per item — the same configuration that exercises MoveRangeAfter.
    private static ForEach<string, string> MultiSlotForEach(IReadOnlySignal<IList<string>> items) =>
        new()
        {
            Items = items,
            Key = s => s,
            ElementSetup = s =>
            [
                new Span { Children = [new DomText { Text = new Computed<string>(() => s.Value + "-first") }] },
                new Span { Children = [new DomText { Text = new Computed<string>(() => s.Value + "-second") }] },
            ],
        };

    [Test]
    public async Task Renders_initial_multi_slot_items()
    {
        var root = new SsrRenderRoot();
        var items = new Signal<IList<string>>(["a", "b", "c"]);

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
            .UseRootComponent(() => MultiSlotForEach(items))
            .Build()
            .Mount();

        var output = await SsrHelpers.RenderAsync(root);

        await Assert.That(output).IsEqualTo(
            "<!--[-->" +
            "<span>a-first</span><span>a-second</span>" +
            "<span>b-first</span><span>b-second</span>" +
            "<span>c-first</span><span>c-second</span>" +
            "<!--]-->");
    }

    [Test]
    public async Task Reorder_moves_all_slots_for_each_item()
    {
        var root = new SsrRenderRoot();
        var items = new Signal<IList<string>>(["a", "b", "c"]);

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
            .UseRootComponent(() => MultiSlotForEach(items))
            .Build()
            .Mount();

        items.Value = ["c", "a", "b"];

        var output = await SsrHelpers.RenderAsync(root);

        await Assert.That(output).IsEqualTo(
            "<!--[-->" +
            "<span>c-first</span><span>c-second</span>" +
            "<span>a-first</span><span>a-second</span>" +
            "<span>b-first</span><span>b-second</span>" +
            "<!--]-->");
    }

    [Test]
    public async Task Reorder_to_start_moves_all_slots()
    {
        var root = new SsrRenderRoot();
        var items = new Signal<IList<string>>(["b", "c"]);

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
            .UseRootComponent(() => MultiSlotForEach(items))
            .Build()
            .Mount();

        items.Value = ["a", "b", "c"];

        var output = await SsrHelpers.RenderAsync(root);

        await Assert.That(output).IsEqualTo(
            "<!--[-->" +
            "<span>a-first</span><span>a-second</span>" +
            "<span>b-first</span><span>b-second</span>" +
            "<span>c-first</span><span>c-second</span>" +
            "<!--]-->");
    }

    [Test]
    public async Task Reverse_order_moves_all_slots()
    {
        var root = new SsrRenderRoot();
        var items = new Signal<IList<string>>(["a", "b", "c"]);

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
            .UseRootComponent(() => MultiSlotForEach(items))
            .Build()
            .Mount();

        items.Value = ["c", "b", "a"];

        var output = await SsrHelpers.RenderAsync(root);

        await Assert.That(output).IsEqualTo(
            "<!--[-->" +
            "<span>c-first</span><span>c-second</span>" +
            "<span>b-first</span><span>b-second</span>" +
            "<span>a-first</span><span>a-second</span>" +
            "<!--]-->");
    }

    [Test]
    public async Task Remove_item_with_multiple_slots()
    {
        var root = new SsrRenderRoot();
        var items = new Signal<IList<string>>(["a", "b", "c"]);

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
            .UseRootComponent(() => MultiSlotForEach(items))
            .Build()
            .Mount();

        items.Value = ["a", "c"];

        var output = await SsrHelpers.RenderAsync(root);

        await Assert.That(output).IsEqualTo(
            "<!--[-->" +
            "<span>a-first</span><span>a-second</span>" +
            "<span>c-first</span><span>c-second</span>" +
            "<!--]-->");
    }

    [Test]
    public async Task Insert_in_middle_places_all_slots_correctly()
    {
        var root = new SsrRenderRoot();
        var items = new Signal<IList<string>>(["a", "c"]);

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
            .UseRootComponent(() => MultiSlotForEach(items))
            .Build()
            .Mount();

        items.Value = ["a", "b", "c"];

        var output = await SsrHelpers.RenderAsync(root);

        await Assert.That(output).IsEqualTo(
            "<!--[-->" +
            "<span>a-first</span><span>a-second</span>" +
            "<span>b-first</span><span>b-second</span>" +
            "<span>c-first</span><span>c-second</span>" +
            "<!--]-->");
    }
}
