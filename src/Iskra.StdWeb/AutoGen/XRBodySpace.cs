// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class XRBodySpace: global::Iskra.StdWeb.XRSpace
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public XRBodySpace(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.XRBodyJoint JointName
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.XRBodyJoint, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "jointName");
    }
}

#nullable disable