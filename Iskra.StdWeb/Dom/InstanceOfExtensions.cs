using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices.JavaScript;
using Iskra.Utils;

namespace Iskra.StdWeb.Dom;

public static class InstanceOfExtensions
{
    public static bool InstanceOf(this JSObject obj, [NotNullWhen(true)] out HtmlDivElement? target)
    {
        if (obj.InstanceOf(new Window(JSHost.GlobalThis).HtmlDivElement))
        {
            target = new(obj);
            return true;
        }

        target = null;
        return false;
    }

    public static bool InstanceOf(this JSObject obj, [NotNullWhen(true)] out Event? target)
    {
        if (obj.InstanceOf(new Window(JSHost.GlobalThis).Event))
        {
            target = new(obj);
            return true;
        }

        target = null;
        return false;
    }

    public static bool InstanceOf(this JSObject obj, [NotNullWhen(true)] out HtmlInputElement? target)
    {
        if (obj.InstanceOf(new Window(JSHost.GlobalThis).HtmlInputElement))
        {
            target = new(obj);
            return true;
        }

        target = null;
        return false;
    }
}