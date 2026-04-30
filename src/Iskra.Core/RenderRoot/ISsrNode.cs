using System.IO.Pipelines;

namespace Iskra.Core.RenderRoot;

public interface ISsrNode
{
    ValueTask WriteAsync(PipeWriter writer, bool sortAttributes, CancellationToken cancellationToken = default);
}
