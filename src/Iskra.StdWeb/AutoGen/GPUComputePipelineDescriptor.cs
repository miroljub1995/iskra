// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class GPUComputePipelineDescriptor: global::Iskra.StdWeb.GPUPipelineDescriptorBase
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public GPUComputePipelineDescriptor(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public GPUComputePipelineDescriptor(): base()
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public required global::Iskra.StdWeb.GPUProgrammableStage Compute
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.GPUProgrammableStage, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "compute");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.GPUProgrammableStage, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "compute", value);
    }
}

#nullable disable