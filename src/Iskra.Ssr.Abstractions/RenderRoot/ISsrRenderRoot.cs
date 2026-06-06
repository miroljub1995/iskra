using System.IO.Pipelines;
using Iskra.Core.RenderRoot;

namespace Iskra.Ssr.Abstractions.RenderRoot;

public interface ISsrRenderRoot : IRenderRoot
{
    ValueTask WriteAsync(PipeWriter writer, bool sortAttributes = false, CancellationToken cancellationToken = default);
}