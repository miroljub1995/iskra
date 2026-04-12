using Iskra.Core.Components;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public abstract class BaseNonVoidDomComponent<TElement, TProps, TEvents>(string tagName)
    : BaseDomComponent<TElement, TProps, TEvents>(tagName)
    where TElement : Element
    where TProps : BaseDomComponentProps<TElement>
    where TEvents : BaseDomComponentEvents<TElement>
{
    protected override bool IsVoid => false;

    public IComponent[] Children { get; init; } = [];

    protected override IComponent[]? GetChildren() => Children;
}
