// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class ScreenDetailed: global::Iskra.StdWeb.Screen
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ScreenDetailed(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public int AvailLeft
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<int, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "availLeft");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public int AvailTop
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<int, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "availTop");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public int Left
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<int, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "left");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public int Top
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<int, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "top");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool IsPrimary
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "isPrimary");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool IsInternal
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "isInternal");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public float DevicePixelRatio
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<float, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "devicePixelRatio");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string Label
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "label");
    }
}

#nullable disable