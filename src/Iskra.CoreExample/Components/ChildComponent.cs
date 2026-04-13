using Iskra.Core.Components;
using Iskra.Core.DomComponents;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.CoreExample.Components;

public class ChildComponentProps
{
    public required IReadOnlySignal<string> FirstName { get; init; }
    public required IReadOnlySignal<string> LastName { get; init; }
}

public partial class ChildComponentEvents
{
    public partial void UpdateFirstName(string firstName);
    public partial void UpdateLastName(string lastName);
}

public record ChildComponentExpose(
    IReadOnlySignal<HTMLDivElement?> DivElement
);

// [Component]
public class ChildComponent : BaseComponent<ChildComponentProps, ChildComponentEvents, ChildComponentExpose>
{
    protected override IComponent[] Setup(ChildComponentProps props, ChildComponentEvents? events,
        out ChildComponentExpose exposed)
    {
        var divRef = new Signal<HTMLDivElement?>(null);
        var index = new Signal<int>(0);

        OnMounted(onUnmounted =>
        {
            var timer = new PeriodicTimer(TimeSpan.FromSeconds(1));
            _ = Task.Run(async () =>
            {
                while (await timer.WaitForNextTickAsync())
                {
                    Console.WriteLine("Incrementing index...");
                    index.Value++;
                }
            });

            onUnmounted(timer.Dispose);
        });

        var fullnameWithIndex = new Computed<string>(() => $"{props.FirstName.Value} {props.LastName.Value} ({index.Value})");

        exposed = new ChildComponentExpose(divRef);

        void HandleDivClick(PointerEvent ev)
        {
            if (!OperatingSystem.IsBrowser())
            {
                return;
            }

            Console.WriteLine("Div clicked! {0}", ev.Target is HTMLDivElement div ? div.InnerText : "null");
        }

        return
        [
            new DomText { Text = fullnameWithIndex },
            new Label
            {
                Children = [new DomText { Text = new Signal<string>("First name") }],
            },
            new Br(),
            new Input
            {
                Props = new InputProps { Value = props.FirstName },
                Events = new InputEvents
                {
                    OnInput = ev =>
                    {
                        if (!OperatingSystem.IsBrowser()) return;
                        if (ev.Target is HTMLInputElement input)
                        {
                            events?.UpdateFirstName(input.Value);
                        }
                    },
                },
            },
            new Br(),
            new Br(),
            new Label
            {
                Children = [new DomText { Text = new Signal<string>("Last name") }],
            },
            new Br(),
            new Input
            {
                Props = new InputProps { Value = props.LastName },
                Events = new InputEvents
                {
                    OnInput = ev =>
                    {
                        if (!OperatingSystem.IsBrowser()) return;
                        if (ev.Target is HTMLInputElement input)
                        {
                            events?.UpdateLastName(input.Value);
                        }
                    },
                },
            },
            new Br(),
            new Br(),
            new Div
            {
                Ref = divRef,
                Props = new DivProps
                {
                    Class = new Computed<string>(() => index.Value % 2 == 0 ? "even" : "odd"),
                    Draggable = new Computed<bool>(() => index.Value % 2 == 0),
                    Data = new Computed<IDictionary<string, string>>(() => new Dictionary<string, string>
                    {
                        ["custom-index"] = index.Value.ToString(),
                    }),
                },
                Events = new DivEvents
                {
                    OnClick = HandleDivClick,
                },
                Children =
                [
                    new DomText { Text = new Signal<string>("Click me!") },
                ]
            }
        ];
    }
}

// Generated
public partial class ChildComponentEvents : BaseEmits
{
    public Action<string>? OnUpdateFirstName { get; init; } = null;
    public Action<string>? OnUpdateLastName { get; init; } = null;

    public partial void UpdateFirstName(string firstName)
    {
        if (Disabled) return;
        OnUpdateFirstName?.Invoke(firstName);
    }

    public partial void UpdateLastName(string lastName)
    {
        if (Disabled) return;
        OnUpdateLastName?.Invoke(lastName);
    }
}