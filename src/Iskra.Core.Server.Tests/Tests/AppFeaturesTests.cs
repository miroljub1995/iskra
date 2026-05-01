using Iskra.Core.Components;
using Iskra.Core.DomComponents;
using Iskra.Core.Features;
using Iskra.Core.RenderRoot;
using Iskra.Signals;

namespace Iskra.Core.Server.Tests.Tests;

public class AppFeaturesTests
{
    private sealed record Theme(string Value);
    private sealed record User(string Name);
    private sealed record Counter(int Value);

    /// <summary>
    /// Generic spy component: invokes a callback during Setup with the
    /// ambient <see cref="AppFeatures.Features"/>, allowing tests to observe
    /// what each component sees in the tree.
    /// </summary>
    private sealed class SpyProps
    {
        public required Action<IFeatureCollection> Spy { get; init; }
        public IComponent[] Children { get; init; } = [];
    }

    private sealed class Spy : BaseComponent<SpyProps, BaseEmits, object?>
    {
        protected override IComponent[] Setup(SpyProps props, BaseEmits? events, out object? exposed)
        {
            props.Spy(AppFeatures.Features);
            exposed = null;
            return props.Children;
        }
    }

    [Test]
    public async Task App_level_feature_is_visible_in_root_component()
    {
        Theme? observed = null;

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(new SsrRenderRoot())
            .SetFeature(new Theme("dark"))
            .UseRootComponent(() => new Spy
            {
                Props = new SpyProps { Spy = f => observed = f.Get<Theme>() },
            })
            .Build()
            .Mount();

        await Assert.That(observed).IsEqualTo(new Theme("dark"));
    }

    [Test]
    public async Task Parent_set_is_visible_in_grandchild()
    {
        Theme? observed = null;

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(new SsrRenderRoot())
            .UseRootComponent(() => new Spy
            {
                Props = new SpyProps
                {
                    Spy = f => f.Set(new Theme("dark")),
                    Children =
                    [
                        new Spy
                        {
                            Props = new SpyProps
                            {
                                Spy = _ => { },
                                Children =
                                [
                                    new Spy
                                    {
                                        Props = new SpyProps { Spy = f => observed = f.Get<Theme>() },
                                    },
                                ],
                            },
                        },
                    ],
                },
            })
            .Build()
            .Mount();

        await Assert.That(observed).IsEqualTo(new Theme("dark"));
    }

    [Test]
    public async Task Sibling_isolation()
    {
        Theme? siblingA = null;
        Theme? siblingB = null;

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(new SsrRenderRoot())
            .UseRootComponent(() => new Spy
            {
                Props = new SpyProps
                {
                    Spy = _ => { },
                    Children =
                    [
                        new Spy
                        {
                            Props = new SpyProps
                            {
                                Spy = f =>
                                {
                                    f.Set(new Theme("dark"));
                                    siblingA = f.Get<Theme>();
                                },
                            },
                        },
                        new Spy
                        {
                            Props = new SpyProps { Spy = f => siblingB = f.Get<Theme>() },
                        },
                    ],
                },
            })
            .Build()
            .Mount();

        await Assert.That(siblingA).IsEqualTo(new Theme("dark"));
        await Assert.That(siblingB).IsNull();
    }

    [Test]
    public async Task Subtree_override_does_not_affect_ancestor_or_siblings()
    {
        Theme? observedAtRoot = null;
        Theme? observedInOverridingSubtree = null;
        Theme? observedInUnaffectedSibling = null;

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(new SsrRenderRoot())
            .SetFeature(new Theme("light"))
            .UseRootComponent(() => new Spy
            {
                Props = new SpyProps
                {
                    Spy = f => observedAtRoot = f.Get<Theme>(),
                    Children =
                    [
                        new Spy
                        {
                            Props = new SpyProps
                            {
                                Spy = f => f.Set(new Theme("dark")),
                                Children =
                                [
                                    new Spy
                                    {
                                        Props = new SpyProps { Spy = f => observedInOverridingSubtree = f.Get<Theme>() },
                                    },
                                ],
                            },
                        },
                        new Spy
                        {
                            Props = new SpyProps { Spy = f => observedInUnaffectedSibling = f.Get<Theme>() },
                        },
                    ],
                },
            })
            .Build()
            .Mount();

        await Assert.That(observedAtRoot).IsEqualTo(new Theme("light"));
        await Assert.That(observedInOverridingSubtree).IsEqualTo(new Theme("dark"));
        await Assert.That(observedInUnaffectedSibling).IsEqualTo(new Theme("light"));
    }

    [Test]
    public async Task If_branch_sees_parent_features()
    {
        Theme? observed = null;
        var condition = new Signal<bool>(true);

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(new SsrRenderRoot())
            .SetFeature(new Theme("dark"))
            .UseRootComponent(() => new Spy
            {
                Props = new SpyProps
                {
                    Spy = _ => { },
                    Children =
                    [
                        new If
                        {
                            Condition = condition,
                            Then = () =>
                            [
                                new Spy
                                {
                                    Props = new SpyProps { Spy = f => observed = f.Get<Theme>() },
                                },
                            ],
                        },
                    ],
                },
            })
            .Build()
            .Mount();

        await Assert.That(observed).IsEqualTo(new Theme("dark"));
    }

    [Test]
    public async Task If_flip_after_outermost_mount_returns_still_sees_parent_features()
    {
        Theme? observedThen = null;
        Theme? observedOtherwise = null;
        var condition = new Signal<bool>(true);

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(new SsrRenderRoot())
            .SetFeature(new Theme("dark"))
            .UseRootComponent(() => new Spy
            {
                Props = new SpyProps
                {
                    Spy = _ => { },
                    Children =
                    [
                        new If
                        {
                            Condition = condition,
                            Then = () =>
                            [
                                new Spy
                                {
                                    Props = new SpyProps { Spy = f => observedThen = f.Get<Theme>() },
                                },
                            ],
                            Otherwise = () =>
                            [
                                new Spy
                                {
                                    Props = new SpyProps { Spy = f => observedOtherwise = f.Get<Theme>() },
                                },
                            ],
                        },
                    ],
                },
            })
            .Build()
            .Mount();

        await Assert.That(observedThen).IsEqualTo(new Theme("dark"));
        // After the outermost Mount returned, AppFeatures.Current is null.
        // Flipping the condition triggers the reactive effect to mount the
        // Otherwise branch. The new component must still see the parent's features.
        await Assert.That(AppFeatures.Current).IsNull();

        condition.Value = false;

        await Assert.That(observedOtherwise).IsEqualTo(new Theme("dark"));
        await Assert.That(AppFeatures.Current).IsNull();
    }

    [Test]
    public async Task ForEach_per_item_layering_no_bleed()
    {
        var observedByKey = new Dictionary<int, User?>();
        var items = new Signal<IList<int>>([1, 2]);

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(new SsrRenderRoot())
            .UseRootComponent(() => new Spy
            {
                Props = new SpyProps
                {
                    Spy = _ => { },
                    Children =
                    [
                        new ForEach<int, int>
                        {
                            Items = items,
                            Key = i => i,
                            ElementSetup = el =>
                            [
                                new Spy
                                {
                                    Props = new SpyProps
                                    {
                                        Spy = f =>
                                        {
                                            // Item 1 sets a User; item 2 should NOT see it.
                                            if (el.Value == 1)
                                            {
                                                f.Set(new User("alice"));
                                            }
                                            observedByKey[el.Value] = f.Get<User>();
                                        },
                                    },
                                },
                            ],
                        },
                    ],
                },
            })
            .Build()
            .Mount();

        await Assert.That(observedByKey[1]).IsEqualTo(new User("alice"));
        await Assert.That(observedByKey[2]).IsNull();
    }

    [Test]
    public async Task ForEach_item_added_after_outermost_mount_sees_parent_features()
    {
        var observedByKey = new Dictionary<int, Theme?>();
        var items = new Signal<IList<int>>([1]);

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(new SsrRenderRoot())
            .SetFeature(new Theme("dark"))
            .UseRootComponent(() => new ForEach<int, int>
            {
                Items = items,
                Key = i => i,
                ElementSetup = el =>
                [
                    new Spy
                    {
                        Props = new SpyProps { Spy = f => observedByKey[el.Value] = f.Get<Theme>() },
                    },
                ],
            })
            .Build()
            .Mount();

        await Assert.That(observedByKey[1]).IsEqualTo(new Theme("dark"));
        await Assert.That(AppFeatures.Current).IsNull();

        items.Value = [1, 2];

        await Assert.That(observedByKey[2]).IsEqualTo(new Theme("dark"));
        await Assert.That(AppFeatures.Current).IsNull();
    }

    [Test]
    public async Task AppFeatures_Current_is_null_after_outermost_Mount_returns()
    {
        using var _ = new IskraHostBuilder()
            .UseRootRenderer(new SsrRenderRoot())
            .UseRootComponent(() => new Spy { Props = new SpyProps { Spy = _ => { } } })
            .Build()
            .Mount();

        await Assert.That(AppFeatures.Current).IsNull();
    }

    [Test]
    public async Task Set_null_removes_local_entry_and_parent_value_visible_again()
    {
        Theme? observed = null;

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(new SsrRenderRoot())
            .SetFeature(new Theme("light"))
            .UseRootComponent(() => new Spy
            {
                Props = new SpyProps
                {
                    Spy = f =>
                    {
                        f.Set(new Theme("dark"));
                        f.Set<Theme>(null);
                        observed = f.Get<Theme>();
                    },
                },
            })
            .Build()
            .Mount();

        await Assert.That(observed).IsEqualTo(new Theme("light"));
    }

    [Test]
    public async Task FeatureCollection_with_defaults_falls_back_for_reads_only()
    {
        var parent = new FeatureCollection();
        parent.Set(new Theme("light"));
        var child = new FeatureCollection(parent);

        await Assert.That(child.Get<Theme>()).IsEqualTo(new Theme("light"));

        // Writing to child does not affect parent.
        child.Set(new Theme("dark"));
        await Assert.That(child.Get<Theme>()).IsEqualTo(new Theme("dark"));
        await Assert.That(parent.Get<Theme>()).IsEqualTo(new Theme("light"));
    }

    [Test]
    public async Task Render_consumes_feature_in_dom()
    {
        var root = new SsrRenderRoot();

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
            .SetFeature(new Theme("dark"))
            .UseRootComponent(() => new Spy
            {
                Props = new SpyProps
                {
                    Spy = _ => { },
                    Children =
                    [
                        new Spy
                        {
                            Props = new SpyProps
                            {
                                Spy = _ => { },
                                Children =
                                [
                                    new Div
                                    {
                                        Children =
                                        [
                                            new DomTextFromFeature { Props = null },
                                        ],
                                    },
                                ],
                            },
                        },
                    ],
                },
            })
            .Build()
            .Mount();

        var output = await SsrHelpers.RenderAsync(root);
        await Assert.That(output).IsEqualTo("<div>dark</div>");
    }

    /// <summary>
    /// Tiny helper component that resolves <see cref="Theme"/> from
    /// <see cref="AppFeatures.Features"/> during Setup and renders its value as text.
    /// </summary>
    private sealed class DomTextFromFeature : BaseComponent<object?, BaseEmits, object?>
    {
        protected override IComponent[] Setup(object? props, BaseEmits? events, out object? exposed)
        {
            var theme = AppFeatures.Features.Get<Theme>()!;
            exposed = null;
            return
            [
                new DomText { Text = new Signal<string>(theme.Value) },
            ];
        }
    }
}
