using System.Runtime.InteropServices.JavaScript;

namespace Iskra.StdWeb.Tests;

public class WindowTest
{
    [Test]
    public async Task TestGlobalThisAsWindow()
    {
        var window = WrapperFactory.GetWrapper<Window>(JSHost.GlobalThis);
        await Assert.That(window).IsNotNull();
    }

    [Test]
    public async Task GetWindowDocument()
    {
        var window = WrapperFactory.GetWrapper<Window>(JSHost.GlobalThis);
        await Assert.That(window.Document).IsNotNull();
    }
}