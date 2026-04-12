namespace Iskra.Core.Fallthrough;

public class ComponentAndElementFallthrough<TProps, TElement>
{
    // Props
    // Events
    public Action<TElement, Action<Action>> ElementEffect { get; init; } = static (_, _) => { };
}