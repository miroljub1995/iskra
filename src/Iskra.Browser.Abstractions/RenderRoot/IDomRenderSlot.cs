using System.Runtime.Versioning;
using Iskra.StdWeb;

namespace Iskra.Core.RenderRoot;

[SupportedOSPlatform("browser")]
public interface IDomRenderSlot : IRenderSlot
{
    IDomRenderRoot CreateChildRoot(Element parent);

    /// <summary>
    /// Whether the render root is currently in hydration mode.
    /// </summary>
    bool IsHydrating { get; }

    /// <summary>
    /// Attempts to dequeue the next pre-existing DOM node from the hydration queue
    /// and associate it with this slot. Returns the node when hydrating server-rendered
    /// HTML, or <c>null</c> when operating in normal (non-hydration) mode.
    /// </summary>
    Node? TryHydrateSlot();
    void Populate(Node node);
    void Empty();
}