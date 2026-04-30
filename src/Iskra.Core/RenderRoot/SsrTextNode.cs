using System.IO.Pipelines;
using System.Text;

namespace Iskra.Core.RenderRoot;

public sealed class SsrTextNode : ISsrNode
{
    public string TextContent { get; set; } = string.Empty;

    public ValueTask WriteAsync(PipeWriter writer, bool sortAttributes, CancellationToken cancellationToken = default)
    {
        Encoding.UTF8.GetBytes(TextContent, writer);
        return ValueTask.CompletedTask;
    }
}
