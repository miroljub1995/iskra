using System.Globalization;

namespace Iskra.Core.RenderRoot;

internal static class SsrAttributes
{
    /// <summary>
    /// HTML boolean attribute: present (bare) when <c>true</c>, removed when <c>false</c>.
    /// </summary>
    public static void SetBoolean(SsrElementNode el, string name, bool value)
    {
        if (value)
            el.SetAttribute(name, null);
        else
            el.RemoveAttribute(name);
    }

    /// <summary>
    /// HTML enumerated boolean attribute, e.g. <c>draggable="true|false"</c> or
    /// <c>spellcheck="true|false"</c>. Always renders the attribute with one of the two values.
    /// </summary>
    public static void SetEnumeratedBoolean(
        SsrElementNode el,
        string name,
        bool value,
        string trueValue = "true",
        string falseValue = "false")
    {
        el.SetAttribute(name, value ? trueValue : falseValue);
    }

    public static void SetInt(SsrElementNode el, string name, int value)
        => el.SetAttribute(name, value.ToString(CultureInfo.InvariantCulture));

    public static void SetUInt(SsrElementNode el, string name, uint value)
        => el.SetAttribute(name, value.ToString(CultureInfo.InvariantCulture));

    public static void SetDouble(SsrElementNode el, string name, double value)
        => el.SetAttribute(name, value.ToString(CultureInfo.InvariantCulture));

    /// <summary>
    /// Sets a string attribute, or removes it when the value is <c>null</c>.
    /// </summary>
    public static void SetNullableString(SsrElementNode el, string name, string? value)
    {
        if (value is null)
            el.RemoveAttribute(name);
        else
            el.SetAttribute(name, value);
    }
}
