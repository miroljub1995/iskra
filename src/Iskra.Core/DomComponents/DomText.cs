using System.Runtime.InteropServices.JavaScript;
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

            var node = JSObjectProxyFactory.GetProxy<Window>(JSHost.GlobalThis).Document
                .CreateTextNode(Text.Value);

            new Effect(_ =>
            {
                if (OperatingSystem.IsBrowser())
                {
                    node.TextContent = Text.Value;
                }
            });

            domRenderSlot.Populate(node);
        }
        else if (root is ISsrRenderSlot ssrRenderSlot)
        {
            var node = new SsrTextNode { TextContent = Text.Value };

            new Effect(_ => node.TextContent = Text.Value);

            ssrRenderSlot.Populate(node);
        }

        _slot = root;
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