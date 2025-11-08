using System.Runtime.InteropServices.JavaScript;

namespace Iskra.JSCore;

public abstract class JSObjectProxy(JSObject obj)
{
    public JSObject JSObject => obj;

    public override bool Equals(object? other)
    {
        return other is JSObjectProxy otherProxy && obj.Equals(otherProxy.JSObject);
    }

    public override int GetHashCode() => obj.GetHashCode();
}