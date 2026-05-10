using Iskra.Core.Components;
using Iskra.Core.DomComponents;
using Iskra.Docs.Components;
using Iskra.Signals;

namespace Iskra.Docs.Server.Components;

public class DocsPageProps { }

public class DocsPage : BaseComponent<DocsPageProps, BaseEmits, object>
{
    protected override IComponent[] Setup(DocsPageProps props, BaseEmits? events, out object exposed)
    {
        exposed = new object();

        return
        [
            new Html
            {
                Props = new HtmlProps { Lang = new Signal<string>("en") },
                Children =
                [
                    new Head
                    {
                        Props = new HeadProps(),
                        Children =
                        [
                            new Meta
                            {
                                Props = new MetaProps
                                {
                                    HttpEquiv = new Signal<string>("Content-Type"),
                                    Content = new Signal<string>("text/html; charset=utf-8"),
                                },
                            },
                            new Title
                            {
                                Props = new TitleProps(),
                                Children = [new DomText { Text = new Signal<string>("Iskra Docs (SSR)") }],
                            },
                            new Script
                            {
                                Props = new ScriptProps { Type = new Signal<string>("module") },
                                Children = [new DomText { Text = new Signal<string>("""
                                    import { dotnet } from './_framework/dotnet.js'
                                    const { runMain } = await dotnet.create();
                                    await runMain();
                                    """) }],
                            },
                        ],
                    },
                    new Body
                    {
                        Props = new BodyProps(),
                        Children = [new DocsApp { Props = new DocsAppProps() }],
                    },
                ],
            },
        ];
    }
}
