using Iskra.StdWeb;

namespace Iskra.Core.Fallthrough;

public class ElementFallthrough<TElement>
{
    public Action<TElement, Action<Action>> ElementEffect { get; init; } = static (_, _) => { };
}