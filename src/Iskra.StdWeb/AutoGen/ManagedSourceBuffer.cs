// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class ManagedSourceBuffer: global::Iskra.StdWeb.SourceBuffer
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ManagedSourceBuffer(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.EventHandlerNonNull? Onbufferedchange
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.EventHandlerNonNull?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "onbufferedchange");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.EventHandlerNonNull?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "onbufferedchange", value);
    }
}

#nullable disable