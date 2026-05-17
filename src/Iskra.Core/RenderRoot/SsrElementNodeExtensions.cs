using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Iskra.Signals;

namespace Iskra.Core.RenderRoot;

internal static class SsrElementNodeExtensions
{
    public static void SetAttribute(this SsrElementNode el, string name, IReadOnlySignal<string> signal)
        => el.SetAttribute(name, signal, static obj => new SsrAttributeValue(((IReadOnlySignal<string>)obj).Value));

    /// <summary>
    /// HTML boolean attribute: present (bare) when <c>true</c>, absent when <c>false</c>.
    /// </summary>
    public static void SetBoolean(this SsrElementNode el, string name, IReadOnlySignal<bool> signal)
        => el.SetAttribute(name, signal, static obj => ((IReadOnlySignal<bool>)obj).Value ? new SsrAttributeValue(null) : null);

    /// <summary>HTML enumerated boolean attribute rendered as <c>true</c> or <c>false</c>.</summary>
    public static void SetEnumeratedBoolTrueFalse(this SsrElementNode el, string name, IReadOnlySignal<bool> signal)
        => el.SetAttribute(name, signal, static obj => new SsrAttributeValue(((IReadOnlySignal<bool>)obj).Value ? "true" : "false"));

    /// <summary>HTML enumerated boolean attribute rendered as <c>yes</c> or <c>no</c>.</summary>
    public static void SetEnumeratedBoolYesNo(this SsrElementNode el, string name, IReadOnlySignal<bool> signal)
        => el.SetAttribute(name, signal, static obj => new SsrAttributeValue(((IReadOnlySignal<bool>)obj).Value ? "yes" : "no"));

    /// <summary>HTML enumerated boolean attribute rendered as <c>on</c> or <c>off</c>.</summary>
    public static void SetEnumeratedBoolOnOff(this SsrElementNode el, string name, IReadOnlySignal<bool> signal)
        => el.SetAttribute(name, signal, static obj => new SsrAttributeValue(((IReadOnlySignal<bool>)obj).Value ? "on" : "off"));

    public static void SetInt(this SsrElementNode el, string name, IReadOnlySignal<int> signal)
        => el.SetAttribute(name, signal, static obj => new SsrAttributeValue(((IReadOnlySignal<int>)obj).Value.ToString(CultureInfo.InvariantCulture)));

    public static void SetUInt(this SsrElementNode el, string name, IReadOnlySignal<uint> signal)
        => el.SetAttribute(name, signal, static obj => new SsrAttributeValue(((IReadOnlySignal<uint>)obj).Value.ToString(CultureInfo.InvariantCulture)));

    public static void SetDouble(this SsrElementNode el, string name, IReadOnlySignal<double> signal)
        => el.SetAttribute(name, signal, static obj => new SsrAttributeValue(((IReadOnlySignal<double>)obj).Value.ToString(CultureInfo.InvariantCulture)));

    /// <summary>
    /// Sets a string attribute, or omits it when the signal value is <c>null</c>.
    /// </summary>
    public static void SetNullableString(this SsrElementNode el, string name, IReadOnlySignal<string?> signal)
        => el.SetAttribute(name, signal, static obj => { var v = ((IReadOnlySignal<string?>)obj).Value; return v is null ? null : new SsrAttributeValue(v); });

    public static void SetDataAttributes(this SsrElementNode el, IReadOnlySignal<IDictionary<string, string>> signal)
        => el.SetMultiAttribute(signal, static obj =>
            ((IReadOnlySignal<IDictionary<string, string>>)obj).Value
                .Select(static kvp => ($"data-{kvp.Key}", (SsrAttributeValue?)new SsrAttributeValue(kvp.Value))));
}
