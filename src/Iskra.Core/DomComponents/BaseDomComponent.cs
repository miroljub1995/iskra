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
    private IDomRenderSlot? _domRenderSlot;
    private readonly List<Action> _eventCleanups = [];

    protected abstract IComponent[]? GetChildren();

    protected abstract bool IsVoid { get; }

    public TProps? Props { get; init; }
    public TEvents? Events { get; init; }

    public ISignal<TElement?>? Ref { get; init; }

    public void Mount(IRenderSlot slot)
    {
        var children = GetChildren();

        if (OperatingSystem.IsBrowser())
        {
            _domRenderSlot = (IDomRenderSlot)slot;

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

            _domRenderSlot.Populate(element);

            if (Ref is not null)
            {
                Ref.Value = element;
            }
        }
    }

    public void Unmount()
    {
        var children = GetChildren();

        if (OperatingSystem.IsBrowser())
        {
            if (_domRenderSlot is null)
            {
                return;
            }

            _domRenderSlot.Empty();
            _domRenderSlot = null;

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
    }
}