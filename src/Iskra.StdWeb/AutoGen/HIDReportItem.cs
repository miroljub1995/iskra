// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class HIDReportItem: global::Iskra.JSCore.JSObjectProxy
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public HIDReportItem(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public HIDReportItem(): base(global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "Object"))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool IsAbsolute
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "isAbsolute");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "isAbsolute", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool IsArray
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "isArray");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "isArray", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool IsBufferedBytes
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "isBufferedBytes");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "isBufferedBytes", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool IsConstant
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "isConstant");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "isConstant", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool IsLinear
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "isLinear");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "isLinear", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool IsRange
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "isRange");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "isRange", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool IsVolatile
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "isVolatile");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "isVolatile", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool HasNull
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "hasNull");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "hasNull", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool HasPreferredState
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "hasPreferredState");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "hasPreferredState", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool Wrap
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "wrap");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "wrap", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.JSArray<uint, global::Iskra.StdWeb.PropertyAccessor> Usages
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.JSArray<uint, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "usages");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.JSCore.Generics.JSArray<uint, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "usages", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public uint UsageMinimum
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<uint, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "usageMinimum");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<uint, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "usageMinimum", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public uint UsageMaximum
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<uint, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "usageMaximum");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<uint, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "usageMaximum", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ushort ReportSize
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<ushort, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "reportSize");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<ushort, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "reportSize", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ushort ReportCount
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<ushort, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "reportCount");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<ushort, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "reportCount", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public sbyte UnitExponent
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<sbyte, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "unitExponent");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<sbyte, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "unitExponent", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.HIDUnitSystem UnitSystem
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.HIDUnitSystem, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "unitSystem");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.HIDUnitSystem, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "unitSystem", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public sbyte UnitFactorLengthExponent
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<sbyte, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "unitFactorLengthExponent");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<sbyte, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "unitFactorLengthExponent", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public sbyte UnitFactorMassExponent
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<sbyte, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "unitFactorMassExponent");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<sbyte, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "unitFactorMassExponent", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public sbyte UnitFactorTimeExponent
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<sbyte, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "unitFactorTimeExponent");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<sbyte, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "unitFactorTimeExponent", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public sbyte UnitFactorTemperatureExponent
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<sbyte, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "unitFactorTemperatureExponent");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<sbyte, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "unitFactorTemperatureExponent", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public sbyte UnitFactorCurrentExponent
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<sbyte, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "unitFactorCurrentExponent");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<sbyte, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "unitFactorCurrentExponent", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public sbyte UnitFactorLuminousIntensityExponent
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<sbyte, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "unitFactorLuminousIntensityExponent");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<sbyte, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "unitFactorLuminousIntensityExponent", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public int LogicalMinimum
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<int, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "logicalMinimum");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<int, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "logicalMinimum", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public int LogicalMaximum
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<int, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "logicalMaximum");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<int, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "logicalMaximum", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public int PhysicalMinimum
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<int, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "physicalMinimum");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<int, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "physicalMinimum", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public int PhysicalMaximum
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<int, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "physicalMaximum");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<int, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "physicalMaximum", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.JSArray<string, global::Iskra.StdWeb.PropertyAccessor> Strings
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.JSArray<string, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "strings");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.JSCore.Generics.JSArray<string, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "strings", value);
    }
}

#nullable disable