// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class XRJointSpace: global::Iskra.StdWeb.XRSpace
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public XRJointSpace(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.XRHandJoint JointName
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.XRHandJoint, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "jointName");
    }
}

#nullable disable