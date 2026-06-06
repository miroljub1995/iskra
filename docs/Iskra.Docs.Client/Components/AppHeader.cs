using Iskra.Core.Components;
using Iskra.Dom.Components;
using Iskra.Core.Features;
using Iskra.Core.Features.Routing;
using Iskra.Signals;

namespace Iskra.Docs.Client.Components;

public class AppHeaderProps { }

public class AppHeader : BaseComponent<AppHeaderProps, NoEvents, NoSlots, NoExpose>
{
    protected override IComponent[] Setup(out NoExpose exposed)
    {
        exposed = default;

        var navigation = AppFeatures.Features.Get<INavigationFeature>()
            ?? throw new InvalidOperationException("INavigationFeature is not registered.");

        var mobileMenuOpen = new Signal<bool>(false);

        var mobileMenuClass = new Computed<string>(() =>
            mobileMenuOpen.Value
                ? "flex flex-col gap-2 px-4 pb-4 md:hidden"
                : "hidden");

        return
        [
            new Header
            {
                Props = new HeaderProps
                {
                    Class = "bg-white/80 dark:bg-gray-900/80 backdrop-blur-md border-b border-gray-200 dark:border-gray-700 sticky top-0 z-50".ToConstSignal(),
                },
                Children =
                [
                    // Top bar
                    new Div
                    {
                        Props = new DivProps
                        {
                            Class = "flex items-center justify-between h-16 px-4 sm:px-6".ToConstSignal(),
                        },
                        Children =
                        [
                            // Logo + brand
                            new A
                            {
                                Props = new AProps
                                {
                                    Href = "/".ToConstSignal(),
                                    Class = "flex items-center gap-3 shrink-0".ToConstSignal(),
                                },
                                Events = new AEvents
                                {
                                    OnClick = (e) =>
                                    {
                                        if (!OperatingSystem.IsBrowser()) return;
                                        e.PreventDefault();
                                        mobileMenuOpen.Value = false;
                                        navigation.PushAsync("/");
                                    },
                                },
                                Children =
                                [
                                    new Img
                                    {
                                        Props = new ImgProps
                                        {
                                            Src = WwwRoot.Assets_Icon_Png.ToConstSignal(),
                                            Class = "h-8 w-8".ToConstSignal(),
                                        },
                                    },
                                    new Span
                                    {
                                        Props = new SpanProps
                                        {
                                            Class = "text-xl font-bold text-gray-900 dark:text-white tracking-tight".ToConstSignal(),
                                        },
                                        Children = [new DomText { Text = "Iskra".ToConstSignal() }],
                                    },
                                ],
                            },
                            // Mobile burger button
                            new Button
                            {
                                Props = new ButtonProps
                                {
                                    Class = "md:hidden inline-flex items-center justify-center rounded-lg p-2 text-gray-600 dark:text-gray-400 hover:text-gray-900 dark:hover:text-white hover:bg-gray-100 dark:hover:bg-gray-800 transition-colors".ToConstSignal(),
                                },
                                Events = new ButtonEvents
                                {
                                    OnClick = (_) =>
                                    {
                                        mobileMenuOpen.Value = !mobileMenuOpen.Value;
                                    },
                                },
                                Children =
                                [
                                    new Span
                                    {
                                        Props = new SpanProps
                                        {
                                            Class = "flex flex-col gap-1 w-5".ToConstSignal(),
                                        },
                                        Children =
                                        [
                                            new Span
                                            {
                                                Props = new SpanProps
                                                {
                                                    Class = "block h-0.5 w-full bg-current rounded-full".ToConstSignal(),
                                                },
                                            },
                                            new Span
                                            {
                                                Props = new SpanProps
                                                {
                                                    Class = "block h-0.5 w-full bg-current rounded-full".ToConstSignal(),
                                                },
                                            },
                                            new Span
                                            {
                                                Props = new SpanProps
                                                {
                                                    Class = "block h-0.5 w-full bg-current rounded-full".ToConstSignal(),
                                                },
                                            },
                                        ],
                                    },
                                ],
                            },
                        ],
                    },
                    // Mobile menu
                    new Div
                    {
                        Props = new DivProps
                        {
                            Class = mobileMenuClass,
                        },
                        Children =
                        [
                            new NavItems
                            {
                                Props = new NavItemsProps
                                {
                                    LinkClass = "block px-3 py-2 rounded-lg text-base font-medium text-gray-600 dark:text-gray-400 hover:text-gray-900 dark:hover:text-white hover:bg-gray-100 dark:hover:bg-gray-800 transition-colors",
                                    ActiveLinkClass = "block px-3 py-2 rounded-lg text-base font-medium text-indigo-600 dark:text-indigo-400 bg-indigo-50 dark:bg-indigo-950 transition-colors",
                                },
                                Events = new NavItemsEvents
                                {
                                    OnNavigate = () => mobileMenuOpen.Value = false,
                                },
                            },
                        ],
                    },
                ],
            },
        ];
    }
}
