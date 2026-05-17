using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;
using Iskra.Core.Components;
using Iskra.Core.RenderRoot;
using Iskra.JSCore;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class DomComment : IComponent
{
    public required IReadOnlySignal<string> Data { get; init; }

    private IRenderSlot? _slot;

    public void Mount(IRenderSlot slot)
    {
        if (slot is IDomRenderSlot domRenderSlot)
        {
            if (!OperatingSystem.IsBrowser())
            {
                throw new PlatformNotSupportedException();
            }

            var existingNode = domRenderSlot.GetNode();
            Comment node;
            if (existingNode is not null)
            {
                if (existingNode.NodeType != Node.COMMENT_NODE)
                {
                    throw new HydrationMismatchException(
                        $"Hydration mismatch: expected a comment node but found <{existingNode.NodeName.ToLowerInvariant()}>.");
                }

                node = JSObjectProxyFactory.GetProxy<Comment>(existingNode.JSObject);
                if (node.Data != Data.Value)
                {
                    throw new HydrationMismatchException(
                        $"Hydration mismatch: expected comment \"{Data.Value}\" but found \"{node.Data}\"");
                }

                RegisterDataEffect(node, Data);
            }
            else
            {
                node = JSObjectProxyFactory.GetProxy<Window>(JSHost.GlobalThis).Document
                    .CreateComment(Data.Value);

                RegisterDataEffect(node, Data);

                domRenderSlot.Populate(node);
            }
        }
        else if (slot is ISsrRenderSlot ssrRenderSlot)
        {
            var node = new SsrCommentNode { Data = Data };

            ssrRenderSlot.Populate(node);
        }

        _slot = slot;
    }

    [SupportedOSPlatform("browser")]
    private static void RegisterDataEffect(Comment node, IReadOnlySignal<string> data)
    {
        new Effect(_ => node.Data = data.Value);
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
