using System.IO.Pipelines;
using System.Text;
using Iskra.Signals;

namespace Iskra.Ssr.Abstractions.RenderRoot;

public sealed class SsrCommentNode : ISsrNode
{
    public IReadOnlySignal<string>? Data { get; init; }

    public ValueTask WriteAsync(PipeWriter writer, bool sortAttributes, CancellationToken cancellationToken = default)
    {
        Encoding.UTF8.GetBytes("<!--", writer);
        Encoding.UTF8.GetBytes(Data?.Value ?? string.Empty, writer);
        Encoding.UTF8.GetBytes("-->", writer);
        return ValueTask.CompletedTask;
    }
}
