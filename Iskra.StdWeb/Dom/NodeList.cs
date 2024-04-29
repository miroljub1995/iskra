using System.Runtime.InteropServices.JavaScript;
using Iskra.Utils;

namespace Iskra.StdWeb.Dom;

public class NodeList(JSObject obj) : JSObjectWrapper(obj)
{
    public int Length => JSObject.GetPropertyAsInt32("length");
}