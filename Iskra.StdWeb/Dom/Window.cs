using System.Runtime.InteropServices.JavaScript;

namespace Iskra.StdWeb.Dom;

public class Window(JSObject obj) : EventTarget(obj) 
{
    public Document Document
    {
        get
        {
            JSObject docObj = JSObject.GetPropertyAsJSObject("document")
                ?? throw new("Document not found on window");

            return new Document(docObj);
        }
    }
}