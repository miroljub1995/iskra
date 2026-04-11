// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class XRWebGLDepthInformation: global::Iskra.StdWeb.XRDepthInformation
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public XRWebGLDepthInformation(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.WebGLTexture Texture
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.WebGLTexture, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "texture");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.XRTextureType TextureType
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.XRTextureType, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "textureType");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public uint? ImageIndex
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<uint?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "imageIndex");
    }
}

#nullable disable