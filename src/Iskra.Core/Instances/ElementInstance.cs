using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;
using Iskra.Core.RenderRoot;
using Iskra.JSCore;
using Iskra.StdWeb;

namespace Iskra.Core.Instances;

[SupportedOSPlatform("browser")]
public class ElementInstance<TElement> : BaseInstance
    where TElement : Element
{
    private IDomRenderSlot? _renderSlot;

    public ElementInstance(string tagName) : this(tagName, [])
    {
    }

    public ElementInstance(string tagName, BaseInstance[] children)
    {
        Element = (TElement)JSObjectProxyFactory.GetProxy<Window>(JSHost.GlobalThis).Document.CreateElement(tagName);
        Children = children;
    }

    public TElement Element { get; }
    public BaseInstance[] Children { get; }

    public override void Mount(IRenderSlot slot)
    {
        _renderSlot = (IDomRenderSlot)slot;

        if (Children.Length > 0)
        {
            var childrenRoot = new DomRenderRoot(Element);
            foreach (var child in Children)
            {
                child.Mount(childrenRoot.GetNextSlot());
            }
        }

        _renderSlot.Populate(Element);
    }

    public override void Unmount()
    {
        if (_renderSlot is null)
        {
            return;
        }

        _renderSlot.Empty();
        _renderSlot = null;

        if (Children.Length > 0)
        {
            foreach (var child in Children.Reverse())
            {
                child.Unmount();
            }
        }
    }
}