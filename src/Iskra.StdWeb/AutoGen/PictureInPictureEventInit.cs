// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class PictureInPictureEventInit: global::Iskra.StdWeb.EventInit
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public PictureInPictureEventInit(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public PictureInPictureEventInit(): base()
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public required global::Iskra.StdWeb.PictureInPictureWindow PictureInPictureWindow
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.PictureInPictureWindow, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "pictureInPictureWindow");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.PictureInPictureWindow, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "pictureInPictureWindow", value);
    }
}

#nullable disable