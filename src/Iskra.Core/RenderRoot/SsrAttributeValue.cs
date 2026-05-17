namespace Iskra.Core.RenderRoot;

/// <summary>
/// Represents an HTML attribute value for SSR rendering.
/// </summary>
/// <remarks>
/// When used as <c>IReadOnlySignal&lt;SsrAttributeValue?&gt;</c>:
/// <list type="bullet">
/// <item><description><c>null</c> — attribute is absent (not rendered)</description></item>
/// <item><description><c>new SsrAttributeValue(null)</c> — bare attribute, e.g. <c>disabled</c></description></item>
/// <item><description><c>new SsrAttributeValue("val")</c> — attribute with value, e.g. <c>type="val"</c></description></item>
/// </list>
/// </remarks>
public readonly record struct SsrAttributeValue(string? Value);
