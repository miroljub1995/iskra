using System.Runtime.Versioning;
using Iskra.StdWeb;

namespace Iskra.Core.RenderRoot;

[SupportedOSPlatform("browser")]
public interface IDomRenderSlot : IRenderSlot
{
    /// <summary>
    /// The existing DOM node at this slot's cursor position in the server-rendered
    /// HTML, or <c>null</c> when operating in normal (non-hydration) mode.
    /// </summary>
    Node? GetNode();
    void Populate(Node node);
    void Empty();
}