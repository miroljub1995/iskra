// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class MIDIInput: global::Iskra.StdWeb.MIDIPort
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public MIDIInput(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.EventHandlerNonNull? Onmidimessage
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.EventHandlerNonNull?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "onmidimessage");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.EventHandlerNonNull?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "onmidimessage", value);
    }
}

#nullable disable