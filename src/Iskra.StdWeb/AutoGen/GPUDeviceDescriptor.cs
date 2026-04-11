// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class GPUDeviceDescriptor: global::Iskra.StdWeb.GPUObjectDescriptorBase
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public GPUDeviceDescriptor(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public GPUDeviceDescriptor(): base()
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.GPUFeatureName, global::Iskra.StdWeb.PropertyAccessor> RequiredFeatures
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.GPUFeatureName, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "requiredFeatures");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.GPUFeatureName, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "requiredFeatures", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.Record<ulong?, global::Iskra.StdWeb.PropertyAccessorNullable> RequiredLimits
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.Record<ulong?, global::Iskra.StdWeb.PropertyAccessorNullable>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "requiredLimits");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.JSCore.Generics.Record<ulong?, global::Iskra.StdWeb.PropertyAccessorNullable>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "requiredLimits", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.GPUQueueDescriptor DefaultQueue
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.GPUQueueDescriptor, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "defaultQueue");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.GPUQueueDescriptor, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "defaultQueue", value);
    }
}

#nullable disable