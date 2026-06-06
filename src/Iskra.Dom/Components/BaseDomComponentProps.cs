using System.Runtime.Versioning;
using Iskra.Core.RenderRoot;
using Iskra.Ssr.Abstractions.RenderRoot;
using Iskra.StdWeb;

namespace Iskra.Dom.Components;

public abstract class BaseDomComponentProps<TElement>
    where TElement : Element
{
    [SupportedOSPlatform("browser")]
    protected internal virtual void RegisterClientEffects(Action<Action<TElement>> register)
    {
    }

    protected internal virtual void RegisterServerEffects(SsrElementNode el)
    {
    }
}