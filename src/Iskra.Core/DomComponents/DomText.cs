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

    private IDomRenderSlot? _domRenderSlot;

    public void Mount(IRenderSlot root)
    {
        Console.WriteLine($"Mounting text node: {Text}");

        if (OperatingSystem.IsBrowser())
        {
            var node = JSObjectProxyFactory.GetProxy<Window>(JSHost.GlobalThis).Document
                .CreateTextNode(Text.Value);

            new Effect(_ =>
            {
                if (OperatingSystem.IsBrowser())
                {
                    node.TextContent = Text.Value;
                }
            });

            _domRenderSlot = (IDomRenderSlot)root;
            _domRenderSlot.Populate(node);
        }
    }

    public void Unmount()
    {
        Console.WriteLine($"Unmounting text node: {Text}");

        if (OperatingSystem.IsBrowser())
        {
            _domRenderSlot?.Empty();
            _domRenderSlot = null;
        }
    }
}