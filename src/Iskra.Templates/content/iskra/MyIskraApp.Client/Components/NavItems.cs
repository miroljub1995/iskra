using Iskra.Core.Components;
using Iskra.Core.DomComponents;
using Iskra.Core.Features;
using Iskra.Core.Features.Routing;
using Iskra.Signals;

namespace MyIskraApp.Client.Components;

internal record NavItem(string Label, string Href);

public class NavItemsProps
{
    public required IReadOnlySignal<string> LinkClass { get; init; }
    public required IReadOnlySignal<string> ActiveLinkClass { get; init; }
}

[GeneratedEvents]
public partial class NavItemsEvents
{
    public partial void Navigate();
}

public class NavItems : BaseComponent<NavItemsProps, NavItemsEvents, NoSlots, NoExpose>
{
    internal static readonly NavItem[] All =
    [
        new("Home", "/"),
        new("About", "/about"),
    ];

    protected override IComponent[] Setup(out NoExpose exposed)
    {
        exposed = default;

        var navigation = AppFeatures.Features.Get<INavigationFeature>()
            ?? throw new InvalidOperationException("INavigationFeature is not registered.");

        return All.Select(item =>
        {
            var computedClass = new Computed<string>(() =>
                navigation.CurrentPath.Value == item.Href
                    ? Props.ActiveLinkClass.Value
                    : Props.LinkClass.Value);

            return (IComponent)new A
            {
                Props = new AProps
                {
                    Href = item.Href.ToConstSignal(),
                    Class = computedClass,
                },
                Events = new AEvents
                {
                    OnClick = (e) =>
                    {
                        if (!OperatingSystem.IsBrowser()) return;
                        e.PreventDefault();
                        Events?.Navigate();
                        navigation.PushAsync(item.Href);
                    },
                },
                Children = [new DomText { Text = item.Label.ToConstSignal() }],
            };
        }).ToArray();
    }
}
