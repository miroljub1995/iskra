using System.IO.Pipelines;
using System.Text;

namespace Iskra.Core.RenderRoot;

public sealed class SsrCommentNode : ISsrNode
{
    public string Data { get; set; } = string.Empty;

    public ValueTask WriteAsync(PipeWriter writer, bool sortAttributes, CancellationToken cancellationToken = default)
    {
        Encoding.UTF8.GetBytes("<!--", writer);
        Encoding.UTF8.GetBytes(Data, writer);
        Encoding.UTF8.GetBytes("-->", writer);
        return ValueTask.CompletedTask;
    }
}
