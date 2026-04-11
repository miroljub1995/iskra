// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class GamepadPose: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public GamepadPose(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool HasOrientation
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "hasOrientation");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool HasPosition
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "hasPosition");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Float32Array? Position
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Float32Array?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "position");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Float32Array? LinearVelocity
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Float32Array?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "linearVelocity");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Float32Array? LinearAcceleration
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Float32Array?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "linearAcceleration");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Float32Array? Orientation
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Float32Array?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "orientation");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Float32Array? AngularVelocity
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Float32Array?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "angularVelocity");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Float32Array? AngularAcceleration
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Float32Array?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "angularAcceleration");
    }
}

#nullable disable