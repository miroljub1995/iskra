using System.Runtime.Versioning;
using Iskra.Core.RenderRoot;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public abstract class BaseDomComponentProps<TElement>
    where TElement : Element
{
    [SupportedOSPlatform("browser")]
    protected internal virtual void RegisterClientEffects(Action<Action<TElement>> register)
    {
    }

    protected internal virtual void RegisterServerEffects(Action<Action<SsrElementNode>> register)
    {
    }
}