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
    private ComposedComponent? _childrenComposed;
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

            TElement element;
            var existingNode = domRenderSlot.TryHydrateSlot();
            if (existingNode is not null)
            {
                if (!string.Equals(existingNode.NodeName, tagName, StringComparison.OrdinalIgnoreCase))
                {
                    throw new HydrationMismatchException(
                        $"Hydration mismatch: expected <{tagName}> but found <{existingNode.NodeName.ToLowerInvariant()}>.");
                }

                element = JSObjectProxyFactory.GetProxy<TElement>(existingNode.JSObject);
            }
            else
            {
                element = (TElement)JSObjectProxyFactory.GetProxy<Window>(JSHost.GlobalThis).Document
                    .CreateElement(tagName);
            }

            var props = Props;
            Action<TElement> combinedEffect = static _ => { };
            props?.RegisterClientEffects(action => combinedEffect += action);
            new Effect(_ => combinedEffect(element));

            var events = Events;
            events?.RegisterClientEffects(effect => _eventCleanups.Add(effect(element)));

            if (!IsVoid && children?.Length > 0)
            {
                var childrenRoot = new DomRenderRoot(element);
                if (domRenderSlot.IsHydrating)
                {
                    childrenRoot.BeginHydration();
                }

                _childrenComposed = new ComposedComponent(children);
                _childrenComposed.Mount(childrenRoot.CreateFirstSlot());

                childrenRoot.EndHydration();
            }

            if (existingNode is null)
            {
                domRenderSlot.Populate(element);
            }

            if (Ref is not null)
            {
                Ref.Value = element;
            }
        }
        else if (slot is ISsrRenderSlot ssrRenderSlot)
        {
            var node = new SsrElementNode { TagName = tagName, IsVoid = IsVoid };

            var props = Props;
            props?.RegisterServerEffects(node);

            if (!IsVoid && children?.Length > 0)
            {
                var childrenRoot = new SsrRenderRoot(node);
                _childrenComposed = new ComposedComponent(children);
                _childrenComposed.Mount(childrenRoot.CreateFirstSlot());
            }

            ssrRenderSlot.Populate(node);
        }

        _slot = slot;
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

            foreach (var cleanup in _eventCleanups)
            {
                cleanup();
            }
            _eventCleanups.Clear();
        }
        else if (_slot is ISsrRenderSlot ssrRenderSlot)
        {
            ssrRenderSlot.Empty();
        }

        _childrenComposed?.Unmount();
        _childrenComposed = null;
        _slot = null;
    }
}