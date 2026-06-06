using Iskra.JSCore;
using Iskra.StdWeb;

namespace Iskra.Browser.Tests;

public static class DomHelpers
{
    public static Element CreateContainer()
    {
        var window = JSObjectProxyFactory.GetProxy<Window>(
            System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis);

        return window.Document.CreateElement("div");
    }
}
