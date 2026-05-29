using Iskra.Core.Client.Tests.TestUtils;
using Iskra.Core.Components;
using Iskra.Core.DomComponents;
using Iskra.Core.Features;
using Iskra.Core.Features.Routing;
using Iskra.Core.RenderRoot;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.Client.Tests;

public class RoutesTests
{
    private sealed class Harness : IDisposable
    {
        public required Element Container { get; init; }
        public required FakeNavigationFeature Navigation { get; init; }
        public required Dictionary<string, int> MountedCounts { get; init; }
        public required Dictionary<string, int> UnmountedCounts { get; init; }
        public required IDisposable Host { get; init; }

        public void Dispose() => Host.Dispose();
    }

    private static IComponent[] BuildPage(
        string label,
        Dictionary<string, int> mounted,
        Dictionary<string, int> unmounted,
        IComponent[]? extra = null)
    {
        return
        [
            new Span
            {
                Children = [new DomText { Text = new Computed<string>(() => label) }],
            },
            new LifecycleProbe
            {
                Props = new LifecycleProbeProps
                {
                    OnMounted = () => mounted[label] = mounted.GetValueOrDefault(label) + 1,
                    OnUnmounted = () => unmounted[label] = unmounted.GetValueOrDefault(label) + 1,
                },
            },
            .. extra ?? [],
        ];
    }

    private static Harness BuildHost(string initialPath, Func<Dictionary<string, int>, Dictionary<string, int>, Route[]> routeFactory)
    {
        var container = DomHelpers.CreateContainer();
        var navigation = new FakeNavigationFeature(initialPath);
        var mounted = new Dictionary<string, int>();
        var unmounted = new Dictionary<string, int>();
        var routes = routeFactory(mounted, unmounted);

        var host = new IskraHostBuilder()
            .UseRootRenderer(new DomRenderRoot(container))
            .SetFeature<INavigationFeature>(navigation)
            .UseRootComponent(() => new Routes
            {
                Items = routes,
            })
            .Build()
            .Mount();

        return new Harness
        {
            Container = container,
            Navigation = navigation,
            MountedCounts = mounted,
            UnmountedCounts = unmounted,
            Host = host,
        };
    }

    [Test]
    public async Task Renders_matching_route()
    {
        using var h = BuildHost("/", (m, u) =>
        [
            new Route
            {
                Pattern = "/",
                Render = () => BuildPage("home", m, u),
            },
        ]);

        await Assert.That(h.Container.TextContent).IsEqualTo("home");
        await Assert.That(h.MountedCounts).IsEquivalentTo(new Dictionary<string, int>
        {
            ["home"] = 1,
        });
    }

    [Test]
    public async Task Renders_nothing_when_no_route_matches()
    {
        using var h = BuildHost("/unknown", (m, u) =>
        [
            new Route
            {
                Pattern = "/home",
                Render = () => BuildPage("home", m, u),
            },
        ]);

        await Assert.That(h.Container.TextContent).IsEqualTo("");
        await Assert.That(h.MountedCounts).IsEmpty();
    }

    [Test]
    public async Task Switches_route_on_navigation()
    {
        using var h = BuildHost("/", (m, u) =>
        [
            new Route
            {
                Pattern = "/",
                Render = () => BuildPage("home", m, u),
            },
            new Route
            {
                Pattern = "/about",
                Render = () => BuildPage("about", m, u),
            },
        ]);

        await Assert.That(h.Container.TextContent).IsEqualTo("home");

        await h.Navigation.PushAsync("/about");

        await Assert.That(h.Container.TextContent).IsEqualTo("about");
        await Assert.That(h.MountedCounts["home"]).IsEqualTo(1);
        await Assert.That(h.MountedCounts["about"]).IsEqualTo(1);
        await Assert.That(h.UnmountedCounts).IsEquivalentTo(new Dictionary<string, int>
        {
            ["home"] = 1,
        });
    }

    [Test]
    public async Task Route_with_parameter_exposes_route_values()
    {
        IReadOnlySignal<IReadOnlyDictionary<string, string>>? capturedRouteValues = null;

        using var h = BuildHost("/users/42", (m, u) =>
        [
            new Route
            {
                Pattern = "/users/{id}",
                Render = () =>
                {
                    var feature = AppFeatures.Features.Get<IRouteFeature>()!;
                    capturedRouteValues = feature.RouteValues;

                    var text = new Computed<string>(() => $"user:{feature.RouteValues.Value["id"]}");
                    return
                    [
                        new Span
                        {
                            Children = [new DomText { Text = text }],
                        },
                    ];
                },
            },
        ]);

        await Assert.That(h.Container.TextContent).IsEqualTo("user:42");
        await Assert.That(capturedRouteValues).IsNotNull();
    }

    [Test]
    public async Task Route_values_update_reactively_without_remount()
    {
        var mountCount = 0;

        using var h = BuildHost("/users/1", (m, u) =>
        [
            new Route
            {
                Pattern = "/users/{id}",
                Render = () =>
                {
                    mountCount++;
                    var feature = AppFeatures.Features.Get<IRouteFeature>()!;
                    var text = new Computed<string>(() => $"user:{feature.RouteValues.Value["id"]}");
                    return
                    [
                        new Span
                        {
                            Children = [new DomText { Text = text }],
                        },
                    ];
                },
            },
        ]);

        await Assert.That(h.Container.TextContent).IsEqualTo("user:1");
        await Assert.That(mountCount).IsEqualTo(1);

        await h.Navigation.PushAsync("/users/2");

        await Assert.That(h.Container.TextContent).IsEqualTo("user:2");
        await Assert.That(mountCount).IsEqualTo(1);
    }

    [Test]
    public async Task Nested_routes_with_outlet()
    {
        using var h = BuildHost("/app/dashboard", (m, u) =>
        [
            new Route
            {
                Pattern = "/app",
                Render = () =>
                [
                    new Span
                    {
                        Children = [new DomText { Text = new Computed<string>(() => "layout:") }],
                    },
                    new Outlet(),
                ],
                Children =
                [
                    new Route
                    {
                        Pattern = "/dashboard",
                        Render = () => BuildPage("dashboard", m, u),
                    },
                    new Route
                    {
                        Pattern = "/settings",
                        Render = () => BuildPage("settings", m, u),
                    },
                ],
            },
        ]);

        await Assert.That(h.Container.TextContent).IsEqualTo("layout:dashboard");

        await h.Navigation.PushAsync("/app/settings");

        await Assert.That(h.Container.TextContent).IsEqualTo("layout:settings");
        await Assert.That(h.MountedCounts["dashboard"]).IsEqualTo(1);
        await Assert.That(h.MountedCounts["settings"]).IsEqualTo(1);
        await Assert.That(h.UnmountedCounts).IsEquivalentTo(new Dictionary<string, int>
        {
            ["dashboard"] = 1,
        });
    }

    [Test]
    public async Task Navigating_away_unmounts_previous_route()
    {
        using var h = BuildHost("/a", (m, u) =>
        [
            new Route
            {
                Pattern = "/a",
                Render = () => BuildPage("a", m, u),
            },
            new Route
            {
                Pattern = "/b",
                Render = () => BuildPage("b", m, u),
            },
        ]);

        await h.Navigation.PushAsync("/b");
        await h.Navigation.PushAsync("/a");

        await Assert.That(h.Container.TextContent).IsEqualTo("a");
        await Assert.That(h.MountedCounts["a"]).IsEqualTo(2);
        await Assert.That(h.UnmountedCounts["a"]).IsEqualTo(1);
        await Assert.That(h.MountedCounts["b"]).IsEqualTo(1);
        await Assert.That(h.UnmountedCounts["b"]).IsEqualTo(1);
    }

    [Test]
    public async Task Disposing_host_unmounts_active_route()
    {
        var unmounted = new Dictionary<string, int>();
        var mounted = new Dictionary<string, int>();

        var h = BuildHost("/", (m, u) =>
        [
            new Route
            {
                Pattern = "/",
                Render = () => BuildPage("home", mounted, unmounted),
            },
        ]);

        await Assert.That(mounted["home"]).IsEqualTo(1);

        h.Dispose();

        await Assert.That(unmounted["home"]).IsEqualTo(1);
    }

    [Test]
    public async Task Catch_all_route_matches_remaining_segments()
    {
        using var h = BuildHost("/docs/getting-started/installation", (m, u) =>
        [
            new Route
            {
                Pattern = "/docs/{**path}",
                Render = () =>
                {
                    var feature = AppFeatures.Features.Get<IRouteFeature>()!;
                    var text = new Computed<string>(() => $"docs:{feature.RouteValues.Value["path"]}");
                    return
                    [
                        new Span
                        {
                            Children = [new DomText { Text = text }],
                        },
                    ];
                },
            },
        ]);

        await Assert.That(h.Container.TextContent).IsEqualTo("docs:getting-started/installation");
    }

    [Test]
    public async Task Root_layout_with_nested_index_route()
    {
        using var h = BuildHost("/", (m, u) =>
        [
            new Route
            {
                Pattern = "/",
                Render = () =>
                [
                    new Span
                    {
                        Children = [new DomText { Text = new Computed<string>(() => "root:") }],
                    },
                    new Outlet(),
                ],
                Children =
                [
                    new Route
                    {
                        Pattern = "/",
                        Render = () => BuildPage("index", m, u),
                    },
                ],
            },
        ]);

        await Assert.That(h.Container.TextContent).IsEqualTo("root:index");
    }
}
