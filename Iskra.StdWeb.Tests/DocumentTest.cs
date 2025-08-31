using System.Runtime.InteropServices.JavaScript;

namespace Iskra.StdWeb.Tests;

public class DocumentTest
{
    private static Document Document => WrapperFactory.GetWrapper<Window>(JSHost.GlobalThis).Document;

    [Test]
    public async Task TestDocumentIsNotNull()
    {
        await Assert.That(Document).IsNotNull();
    }

    [Test]
    public async Task TestCreateDivElement()
    {
        var div = Document.CreateElement("div");

        await Assert.That(div).IsNotNull();
        await Assert.That(div is HTMLDivElement).IsTrue();
    }
}