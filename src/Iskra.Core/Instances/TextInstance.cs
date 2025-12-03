using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;
using Iskra.Core.RenderRoot;
using Iskra.JSCore;
using Iskra.StdWeb;

namespace Iskra.Core.Instances;

[SupportedOSPlatform("browser")]
public class TextInstance(string initialText) : BaseInstance
{
    private IDomRenderSlot? _renderSlot;

    public Text Node { get; } =
        JSObjectProxyFactory.GetProxy<Window>(JSHost.GlobalThis).Document.CreateTextNode(initialText);

    public override void Mount(IRenderSlot root)
    {
        Console.WriteLine($"Mounting text node: {initialText}");
        _renderSlot = (IDomRenderSlot)root;
        _renderSlot.Populate(Node);
    }

    public override void Unmount()
    {
        Console.WriteLine($"Unmounting text node: {initialText}");
        if (_renderSlot is null)
        {
            return;
        }

        _renderSlot.Empty();
        _renderSlot = null;
    }
}