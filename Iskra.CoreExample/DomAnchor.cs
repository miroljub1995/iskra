using System.Runtime.InteropServices.JavaScript;
using Iskra.Core;
using Iskra.StdWeb;

namespace Iskra.CoreExample;

public class DomAnchor : IAnchor
{
    private Element _parent;

    public DomAnchor()
    {
        Window window = WrapperFactory.GetWrapper<Window>(JSHost.GlobalThis);
        _parent = window.Document.Body;
    }
}