using Iskra.Core.Components;
using Iskra.Core.DomComponents;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.CoreExample.Components;

// [Component]
public partial class NewComponent
{
    public class Props
    {
        public required IReadOnlySignal<string> Fullname { get; init; }
    }

    public partial class Emits
    {
        public partial void FullnameUpdated(string fullname);
    }

    public record Exposed(
        IReadOnlySignal<HTMLDivElement?> DivElement
    );

    protected override IComponent[] Setup(Props props, Emits events, out Exposed exposed)
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

        var fullnameWithIndex = new Computed<string>(() => $"{props.Fullname.Value} ({index.Value})");

        exposed = new Exposed(divRef);

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
                    Click = HandleDivClick,
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
public partial class NewComponent : BaseComponent<NewComponent.Props, NewComponent.Emits, NewComponent.Exposed>
{
    public NewComponent(Props props, Emits events, ISignal<Exposed?>? reference = null) : base(props, events,
        reference)
    {
    }

    public partial class Emits : BaseEmits
    {
        // FullnameUpdated
        public delegate void FullnameUpdatedHandler(string fullname);

        public FullnameUpdatedHandler? OnFullnameUpdated { get; init; } = null;

        public partial void FullnameUpdated(string fullname)
        {
            if (Disabled)
            {
                return;
            }

            OnFullnameUpdated?.Invoke(fullname);
        }
    }
}