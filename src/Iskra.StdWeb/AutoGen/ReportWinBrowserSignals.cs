// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class ReportWinBrowserSignals: global::Iskra.StdWeb.ReportingBrowserSignals
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ReportWinBrowserSignals(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ReportWinBrowserSignals(): base()
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double AdCost
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "adCost");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "adCost", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string Seller
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "seller");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "seller", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool MadeHighestScoringOtherBid
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "madeHighestScoringOtherBid");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "madeHighestScoringOtherBid", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string InterestGroupName
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "interestGroupName");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "interestGroupName", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string BuyerReportingId
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "buyerReportingId");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "buyerReportingId", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ushort ModelingSignals
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<ushort, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "modelingSignals");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<ushort, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "modelingSignals", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public uint DataVersion
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<uint, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "dataVersion");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<uint, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "dataVersion", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.KAnonStatus KAnonStatus
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.KAnonStatus, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "kAnonStatus");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.KAnonStatus, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "kAnonStatus", value);
    }
}

#nullable disable