// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class OfflineAudioCompletionEventInit: global::Iskra.StdWeb.EventInit
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public OfflineAudioCompletionEventInit(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public OfflineAudioCompletionEventInit(): base()
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public required global::Iskra.StdWeb.AudioBuffer RenderedBuffer
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.AudioBuffer, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "renderedBuffer");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.AudioBuffer, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "renderedBuffer", value);
    }
}

#nullable disable