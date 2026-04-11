using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;

namespace Iskra.JSCore;

public abstract class JSObjectProxy
{
    private readonly JSObject _obj;

    [SupportedOSPlatform("browser")]
    protected JSObjectProxy(JSObject obj)
    {
        _obj = obj;
    }

    public JSObject JSObject => _obj;

    public override bool Equals(object? other)
    {
        return other is JSObjectProxy otherProxy && _obj.Equals(otherProxy.JSObject);
    }

    public override int GetHashCode() => _obj.GetHashCode();
}