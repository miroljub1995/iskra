using System.Runtime.InteropServices.JavaScript;
using Iskra.Core.Components;
using Iskra.Core.RenderRoot;
using Iskra.JSCore;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public abstract class BaseDomComponent<TElement, TProps, TEvents>(string tagName) : IComponent
    where TElement : Element
    where TProps : BaseDomComponentProps<TElement>
    where TEvents : BaseDomComponentEvents<TElement>
{
    private IRenderSlot? _slot;
    private readonly List<Action> _eventCleanups = [];

    protected abstract IComponent[]? GetChildren();

    protected abstract bool IsVoid { get; }

    public TProps? Props { get; init; }
    public TEvents? Events { get; init; }

    public ISignal<TElement?>? Ref { get; init; }

    public void Mount(IRenderSlot slot)
    {
        var children = GetChildren();

        if (slot is IDomRenderSlot domRenderSlot)
        {
            if (!OperatingSystem.IsBrowser())
            {
                throw new PlatformNotSupportedException();
            }

            var element = (TElement)JSObjectProxyFactory.GetProxy<Window>(JSHost.GlobalThis).Document
                .CreateElement(tagName);

            var props = Props;
            Action<TElement> combinedEffect = static _ => { };
            props?.RegisterClientEffects(action => combinedEffect += action);
            new Effect(_ => combinedEffect(element));

            var events = Events;
            events?.RegisterClientEffects(effect => _eventCleanups.Add(effect(element)));

            if (!IsVoid && children?.Length > 0)
            {
                var childrenRoot = new DomRenderRoot(element);
                foreach (var child in children)
                {
                    child.Mount(childrenRoot.GetNextSlot());
                }
            }

            domRenderSlot.Populate(element);

            if (Ref is not null)
            {
                Ref.Value = element;
            }
        }
        else if (slot is ISsrRenderSlot ssrRenderSlot)
        {
            var node = new SsrElementNode { TagName = tagName, IsVoid = IsVoid };

            var props = Props;
            Action<SsrElementNode> combinedEffect = static _ => { };
            props?.RegisterServerEffects(action => combinedEffect += action);
            new Effect(_ => combinedEffect(node));

            if (!IsVoid && children?.Length > 0)
            {
                var childrenRoot = new SsrRenderRoot(node);
                foreach (var child in children)
                {
                    child.Mount(childrenRoot.GetNextSlot());
                }
            }

            ssrRenderSlot.Populate(node);
        }

        _slot = slot;
    }

    public void Unmount()
    {
        var children = GetChildren();

        if (_slot is IDomRenderSlot domRenderSlot)
        {
            if (!OperatingSystem.IsBrowser())
            {
                throw new PlatformNotSupportedException();
            }

            domRenderSlot.Empty();

            foreach (var cleanup in _eventCleanups)
            {
                cleanup();
            }
            _eventCleanups.Clear();

            if (!IsVoid && children?.Length > 0)
            {
                foreach (var child in children.Reverse())
                {
                    child.Unmount();
                }
            }
        }
        else if (_slot is ISsrRenderSlot ssrRenderSlot)
        {
            ssrRenderSlot.Empty();

            if (!IsVoid && children?.Length > 0)
            {
                foreach (var child in children.Reverse())
                {
                    child.Unmount();
                }
            }
        }

        _slot = null;
    }
}