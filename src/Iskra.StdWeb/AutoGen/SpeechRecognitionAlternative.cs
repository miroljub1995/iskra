// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class SpeechRecognitionAlternative: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public SpeechRecognitionAlternative(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string Transcript
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "transcript");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public float Confidence
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<float, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "confidence");
    }
}

#nullable disable