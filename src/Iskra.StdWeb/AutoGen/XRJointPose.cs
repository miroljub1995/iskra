// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class XRJointPose: global::Iskra.StdWeb.XRPose
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public XRJointPose(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public float Radius
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<float, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "radius");
    }
}

#nullable disable