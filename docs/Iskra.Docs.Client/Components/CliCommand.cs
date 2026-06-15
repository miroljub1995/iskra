using System.Runtime.InteropServices.JavaScript;
using Iskra.Core.Components;
using Iskra.Dom.Components;
using Iskra.JSCore;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Docs.Client.Components;

public class CliCommandProps
{
    public required IReadOnlySignal<string> Label { get; init; }
    public required IReadOnlySignal<string> Command { get; init; }
}

public class CliCommand : BaseComponent<CliCommandProps, NoEvents, NoSlots, NoExpose>
{
    protected override IComponent[] Setup(out NoExpose exposed)
    {
        exposed = default;

        return
        [
            new Div
            {
                Props = new DivProps
                {
                    Class = "my-6".ToConstSignal(),
                },
                Children =
                [
                    new P
                    {
                        Props = new PProps
                        {
                            Class = "mb-2 text-gray-700 dark:text-gray-300".ToConstSignal(),
                        },
                        Children = [new DomText { Text = Props.Label }],
                    },
                    new Div
                    {
                        Props = new DivProps
                        {
                            Class = "flex items-center justify-between gap-4 rounded-lg border border-gray-200 dark:border-gray-700 bg-gray-50 dark:bg-gray-900 px-4 py-3".ToConstSignal(),
                        },
                        Children =
                        [
                            new Code
                            {
                                Props = new CodeProps
                                {
                                    Class = "text-sm sm:text-base text-gray-900 dark:text-gray-100 break-all".ToConstSignal(),
                                },
                                Children = [new DomText { Text = Props.Command }],
                            },
                            new Button
                            {
                                Props = new ButtonProps
                                {
                                    Class = "shrink-0 inline-flex items-center justify-center w-9 h-9 rounded-md border border-gray-300 dark:border-gray-600 text-gray-600 dark:text-gray-300 hover:text-indigo-600 dark:hover:text-indigo-400 hover:border-indigo-400 transition-colors".ToConstSignal(),
                                    Title = "Copy command".ToConstSignal(),
                                },
                                Events = new ButtonEvents
                                {
                                    OnClick = (_) =>
                                    {
                                        if (!OperatingSystem.IsBrowser())
                                        {
                                            return;
                                        }

                                        var window = JSObjectProxyFactory.GetProxy<Window>(JSHost.GlobalThis);
                                        window.Navigator.Clipboard.WriteText(Props.Command.Value);
                                    },
                                },
                                Children =
                                [
                                    new Span
                                    {
                                        Props = new SpanProps
                                        {
                                            Class = "relative inline-block w-4 h-4".ToConstSignal(),
                                        },
                                        Children =
                                        [
                                            new Span
                                            {
                                                Props = new SpanProps
                                                {
                                                    Class = "absolute top-0 left-0 w-3 h-3 rounded border border-current".ToConstSignal(),
                                                },
                                            },
                                            new Span
                                            {
                                                Props = new SpanProps
                                                {
                                                    Class = "absolute bottom-0 right-0 w-3 h-3 rounded border border-current".ToConstSignal(),
                                                },
                                            },
                                        ],
                                    },
                                ],
                            },
                        ],
                    },
                ],
            },
        ];
    }
}