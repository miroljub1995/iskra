using System.Buffers;
using System.IO.Pipelines;
using System.Text;

namespace Iskra.Core.RenderRoot;

public sealed class SsrElementNode : ISsrNode
{
    private readonly Dictionary<string, string?> _attributes = [];

    public required string TagName { get; init; }

    public bool IsVoid { get; init; }

    internal LinkedList<SsrRenderSlot?> Children { get; } = [];

    public void SetAttribute(string name, string? value)
    {
        _attributes[name] = value;
    }

    public void RemoveAttribute(string name)
    {
        _attributes.Remove(name);
    }

    public async ValueTask WriteAsync(PipeWriter writer, bool sortAttributes, CancellationToken cancellationToken = default)
    {
        Write(writer, "<");
        Write(writer, TagName);

        if (sortAttributes && _attributes.Count > 1)
        {
            var names = ArrayPool<string>.Shared.Rent(_attributes.Count);
            try
            {
                _attributes.Keys.CopyTo(names, 0);

                Array.Sort(names, 0, _attributes.Count, StringComparer.Ordinal);

                for (var j = 0; j < _attributes.Count; j++)
                {
                    WriteAttribute(writer, names[j], _attributes[names[j]]);
                }
            }
            finally
            {
                ArrayPool<string>.Shared.Return(names, clearArray: true);
            }
        }
        else
        {
            foreach (var (name, value) in _attributes)
            {
                WriteAttribute(writer, name, value);
            }
        }

        Write(writer, ">");

        if (!IsVoid)
        {
            foreach (var slot in Children)
            {
                if (slot?.Node is { } childNode)
                {
                    await childNode.WriteAsync(writer, sortAttributes, cancellationToken).ConfigureAwait(false);
                }
            }

            Write(writer, "</");
            Write(writer, TagName);
            Write(writer, ">");
        }

        if (writer.CanGetUnflushedBytes && writer.UnflushedBytes >= 8 * 1024)
        {
            await writer.FlushAsync(cancellationToken).ConfigureAwait(false);
        }
    }

    private static void Write(PipeWriter writer, string text) => Encoding.UTF8.GetBytes(text, writer);

    private static void WriteAttribute(PipeWriter writer, string name, string? value)
    {
        Write(writer, " ");
        Write(writer, name);
        if (value is not null)
        {
            Write(writer, "=\"");
            Write(writer, value);
            Write(writer, "\"");
        }
    }
}
