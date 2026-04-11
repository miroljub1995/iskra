// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class SVGPolygonElement: global::Iskra.StdWeb.SVGGeometryElement
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public SVGPolygonElement(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SVGPointList Points
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SVGPointList, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "points");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SVGPointList AnimatedPoints
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SVGPointList, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "animatedPoints");
    }
}

#nullable disable