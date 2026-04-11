// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class SpeechSynthesisUtterance: global::Iskra.StdWeb.EventTarget
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public SpeechSynthesisUtterance(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatformAttribute("browser")]
    public static global::Iskra.StdWeb.SpeechSynthesisUtterance New()
    {
        global::System.Runtime.InteropServices.JavaScript.JSObject ___res_2 = global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "SpeechSynthesisUtterance");
        return new global::Iskra.StdWeb.SpeechSynthesisUtterance(___res_2);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatformAttribute("browser")]
    public static global::Iskra.StdWeb.SpeechSynthesisUtterance New(string text)
    {
        int ___argsArrayLength_3 = 1;

        using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_3);

        // Argument 1
        string ___marshalledValue_4;
        ___marshalledValue_4 = text;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsStringV2(___argsArray_0.JSObject, 0, ___marshalledValue_4);

        global::System.Runtime.InteropServices.JavaScript.JSObject ___res_2 = global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectNonEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "SpeechSynthesisUtterance", ___argsArray_0.JSObject);
        return new global::Iskra.StdWeb.SpeechSynthesisUtterance(___res_2);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string Text
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "text");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "text", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string Lang
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "lang");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "lang", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SpeechSynthesisVoice? Voice
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SpeechSynthesisVoice?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "voice");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.SpeechSynthesisVoice?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "voice", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public float Volume
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<float, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "volume");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<float, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "volume", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public float Rate
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<float, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "rate");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<float, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "rate", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public float Pitch
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<float, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "pitch");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<float, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "pitch", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.EventHandlerNonNull? Onstart
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.EventHandlerNonNull?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "onstart");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.EventHandlerNonNull?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "onstart", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.EventHandlerNonNull? Onend
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.EventHandlerNonNull?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "onend");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.EventHandlerNonNull?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "onend", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.EventHandlerNonNull? Onerror
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.EventHandlerNonNull?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "onerror");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.EventHandlerNonNull?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "onerror", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.EventHandlerNonNull? Onpause
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.EventHandlerNonNull?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "onpause");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.EventHandlerNonNull?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "onpause", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.EventHandlerNonNull? Onresume
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.EventHandlerNonNull?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "onresume");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.EventHandlerNonNull?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "onresume", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.EventHandlerNonNull? Onmark
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.EventHandlerNonNull?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "onmark");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.EventHandlerNonNull?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "onmark", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.EventHandlerNonNull? Onboundary
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.EventHandlerNonNull?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "onboundary");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.EventHandlerNonNull?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "onboundary", value);
    }
}

#nullable disable