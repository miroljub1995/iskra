using System.IO.Pipelines;
using System.Text;
using Iskra.Core.RenderRoot;

namespace Iskra.Core.Server.Tests;

public static class SsrHelpers
{
    public static async Task<string> RenderAsync(SsrRenderRoot root)
    {
        var pipe = new Pipe();
        await root.WriteAsync(pipe.Writer, true);
        await pipe.Writer.CompleteAsync();

        var sb = new StringBuilder();
        while (true)
        {
            var result = await pipe.Reader.ReadAsync();
            foreach (var segment in result.Buffer)
            {
                sb.Append(Encoding.UTF8.GetString(segment.Span));
            }
            pipe.Reader.AdvanceTo(result.Buffer.End);
            if (result.IsCompleted)
            {
                break;
            }
        }
        await pipe.Reader.CompleteAsync();
        return sb.ToString();
    }
}
