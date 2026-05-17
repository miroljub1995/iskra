using System.IO.Pipelines;
using System.Text;

namespace Iskra.Core.RenderRoot;

public sealed class SsrElementNode : ISsrNode
{
    private readonly List<(string Name, object Value, Func<object, SsrAttributeValue?> Selector)> _attributes = [];
    private readonly List<(object Value, Func<object, IEnumerable<(string Name, SsrAttributeValue? Value)>> Selector)> _multiAttributes = [];

    public required string TagName { get; init; }

    public bool IsVoid { get; init; }

    internal LinkedList<SsrRenderSlot?> Children { get; } = [];

    internal void SetAttribute(string name, object value, Func<object, SsrAttributeValue?> selector)
        => _attributes.Add((name, value, selector));

    internal void SetMultiAttribute(object value, Func<object, IEnumerable<(string Name, SsrAttributeValue? Value)>> selector)
        => _multiAttributes.Add((value, selector));

    public async ValueTask WriteAsync(PipeWriter writer, bool sortAttributes, CancellationToken cancellationToken = default)
    {
        Write(writer, "<");
        Write(writer, TagName);

        var pairs = sortAttributes
            ? GetAllAttributePairs().OrderBy(static p => p.Name, StringComparer.Ordinal)
            : GetAllAttributePairs();

        foreach (var (name, attrValue) in pairs)
        {
            WriteAttribute(writer, name, attrValue.Value);
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

    private IEnumerable<(string Name, SsrAttributeValue Value)> GetAllAttributePairs()
    {
        foreach (var (name, value, selector) in _attributes)
        {
            if (selector(value) is { } v)
            {
                yield return (name, v);
            }
        }

        foreach (var (value, selector) in _multiAttributes)
        {
            foreach (var (name, attrValue) in selector(value))
            {
                if (attrValue is { } v)
                {
                    yield return (name, v);
                }
            }
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
