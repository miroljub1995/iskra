using Iskra.Dom.Components;
using Iskra.Core.RenderRoot;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Browser.Tests;

public class SignalBindingExtensionsTests
{
    [Test]
    public async Task ToDomInputEvent_updates_signal_on_input_event()
    {
        var container = DomHelpers.CreateContainer();
        var text = new Signal<string>("");

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(new DomRenderRoot(container))
            .UseRootComponent(() => new Input
            {
                Props = new InputProps { Value = text },
                Events = new InputEvents
                {
                    OnInput = text.ToDomInputEvent(),
                },
            })
            .Build()
            .Mount();

        var input = (HTMLInputElement)container.Children.Item(0)!;
        input.Value = "hello";
        input.DispatchEvent(InputEvent.New("input"));

        await Assert.That(text.Value).IsEqualTo("hello");
    }

    [Test]
    public async Task ToDomInputEvent_resets_dom_value_to_signal_value()
    {
        var container = DomHelpers.CreateContainer();
        var text = new Signal<string>("", new StringLengthComparer());

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(new DomRenderRoot(container))
            .UseRootComponent(() => new Input
            {
                Props = new InputProps { Value = text },
                Events = new InputEvents
                {
                    OnInput = text.ToDomInputEvent(reset: true),
                },
            })
            .Build()
            .Mount();

        var input = (HTMLInputElement)container.Children.Item(0)!;

        // Set signal to "ab"
        input.Value = "ab";
        input.DispatchEvent(InputEvent.New("input"));

        await Assert.That(text.Value).IsEqualTo("ab");

        // Now type "cd" which has the same length — comparer treats as equal,
        // so signal.Value stays "ab". Reset should write "ab" back to DOM.
        input.Value = "cd";
        input.DispatchEvent(InputEvent.New("input"));

        await Assert.That(text.Value).IsEqualTo("ab");
        await Assert.That(input.Value).IsEqualTo("ab");
    }

    /// <summary>
    /// Comparer that considers strings equal when they have the same length.
    /// Used to verify that reset writes signal.Value back when the setter is a no-op.
    /// </summary>
    private sealed class StringLengthComparer : IEqualityComparer<string>
    {
        public bool Equals(string? x, string? y) => x?.Length == y?.Length;
        public int GetHashCode(string obj) => obj.Length;
    }

    [Test]
    public async Task ToDomInputEvent_without_reset_does_not_write_back()
    {
        var text = new Signal<string>("");
        var container = DomHelpers.CreateContainer();

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(new DomRenderRoot(container))
            .UseRootComponent(() => new Input
            {
                Props = new InputProps { Value = text },
                Events = new InputEvents
                {
                    OnInput = text.ToDomInputEvent(reset: false),
                },
            })
            .Build()
            .Mount();

        var input = (HTMLInputElement)container.Children.Item(0)!;
        input.Value = "typed";
        input.DispatchEvent(InputEvent.New("input"));

        await Assert.That(text.Value).IsEqualTo("typed");
    }

    [Test]
    public async Task ToDomEvent_updates_signal_on_change_event()
    {
        var container = DomHelpers.CreateContainer();
        var text = new Signal<string>("");

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(new DomRenderRoot(container))
            .UseRootComponent(() => new Input
            {
                Props = new InputProps { Value = text },
                Events = new InputEvents
                {
                    OnChange = text.ToDomEvent(),
                },
            })
            .Build()
            .Mount();

        var input = (HTMLInputElement)container.Children.Item(0)!;
        input.Value = "changed";
        input.DispatchEvent(Event.New("change"));

        await Assert.That(text.Value).IsEqualTo("changed");
    }

    [Test]
    public async Task ToDomInputEvent_works_with_textarea()
    {
        var container = DomHelpers.CreateContainer();
        var text = new Signal<string>("");

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(new DomRenderRoot(container))
            .UseRootComponent(() => new TextArea
            {
                Props = new TextAreaProps { Value = text },
                Events = new TextAreaEvents
                {
                    OnInput = text.ToDomInputEvent(),
                },
            })
            .Build()
            .Mount();

        var textArea = (HTMLTextAreaElement)container.Children.Item(0)!;
        textArea.Value = "textarea text";
        textArea.DispatchEvent(InputEvent.New("input"));

        await Assert.That(text.Value).IsEqualTo("textarea text");
    }

    [Test]
    public async Task ToDomEvent_works_with_select()
    {
        var container = DomHelpers.CreateContainer();
        var selected = new Signal<string>("");

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(new DomRenderRoot(container))
            .UseRootComponent(() => new Select
            {
                Props = new SelectProps { Value = selected },
                Events = new SelectEvents
                {
                    OnChange = selected.ToDomEvent(),
                },
                Children =
                [
                    new Option { Props = new OptionProps { Value = new Signal<string>("a") }, Children = [new DomText { Text = new Signal<string>("A") }] },
                    new Option { Props = new OptionProps { Value = new Signal<string>("b") }, Children = [new DomText { Text = new Signal<string>("B") }] },
                ],
            })
            .Build()
            .Mount();

        var select = (HTMLSelectElement)container.Children.Item(0)!;
        select.Value = "b";
        select.DispatchEvent(Event.New("change"));

        await Assert.That(selected.Value).IsEqualTo("b");
    }
}
