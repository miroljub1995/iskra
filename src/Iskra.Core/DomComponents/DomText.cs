using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;
using Iskra.Core.Components;
using Iskra.Core.RenderRoot;
using Iskra.JSCore;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class DomText : IComponent
{
    public required IReadOnlySignal<string> Text { get; init; }

    private IRenderSlot? _slot;

    public void Mount(IRenderSlot root)
    {
        if (root is IDomRenderSlot domRenderSlot)
        {
            if (!OperatingSystem.IsBrowser())
            {
                throw new PlatformNotSupportedException();
            }

            var node = domRenderSlot.GetNode();
            if (node is not null)
            {
                if (node.NodeType != Node.TEXT_NODE)
                {
                    throw new HydrationMismatchException(
                        $"Hydration mismatch: expected a text node but found <{node.NodeName.ToLowerInvariant()}>.");
                }

                if (node.TextContent != Text.Value)
                {
                    throw new HydrationMismatchException(
                        $"Hydration mismatch: expected text \"{Text.Value}\" but found \"{node.TextContent ?? string.Empty}\".");
                }

                RegisterTextEffect(node, Text);
            }
            else
            {
                node = JSObjectProxyFactory.GetProxy<Window>(JSHost.GlobalThis).Document
                    .CreateTextNode(Text.Value);

                RegisterTextEffect(node, Text);

                domRenderSlot.Populate(node);
            }
        }
        else if (root is ISsrRenderSlot ssrRenderSlot)
        {
            var node = new SsrTextNode { TextContent = Text };

            ssrRenderSlot.Populate(node);
        }

        _slot = root;
    }

    [SupportedOSPlatform("browser")]
    private static void RegisterTextEffect(Node node, IReadOnlySignal<string> text)
    {
        new Effect(_ => node.TextContent = text.Value);
    }

    public void Unmount()
    {
        if (_slot is IDomRenderSlot domRenderSlot)
        {
            if (!OperatingSystem.IsBrowser())
            {
                throw new PlatformNotSupportedException();
            }

            domRenderSlot.Empty();
        }
        else if (_slot is ISsrRenderSlot ssrRenderSlot)
        {
            ssrRenderSlot.Empty();
        }

        _slot = null;
    }
}