using Iskra.Core.Components;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public abstract class BaseVoidDomComponent<TElement, TProps, TEvents>(string tagName)
    : BaseDomComponent<TElement, TProps, TEvents>(tagName)
    where TElement : Element
    where TProps : BaseDomComponentProps<TElement>
    where TEvents : BaseDomComponentEvents<TElement>
{
    protected override bool IsVoid => true;
    protected override IComponent[]? GetChildren() => null;
}
