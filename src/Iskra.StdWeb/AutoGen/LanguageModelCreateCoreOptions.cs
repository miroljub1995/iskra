// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class LanguageModelCreateCoreOptions: global::Iskra.JSCore.JSObjectProxy
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public LanguageModelCreateCoreOptions(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public LanguageModelCreateCoreOptions(): base(global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "Object"))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double TopK
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "topK");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "topK", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double Temperature
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "temperature");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "temperature", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.LanguageModelExpected, global::Iskra.StdWeb.PropertyAccessor> ExpectedInputs
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.LanguageModelExpected, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "expectedInputs");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.LanguageModelExpected, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "expectedInputs", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.LanguageModelExpected, global::Iskra.StdWeb.PropertyAccessor> ExpectedOutputs
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.LanguageModelExpected, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "expectedOutputs");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.LanguageModelExpected, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "expectedOutputs", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.LanguageModelTool, global::Iskra.StdWeb.PropertyAccessor> Tools
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.LanguageModelTool, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "tools");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.LanguageModelTool, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "tools", value);
    }
}

#nullable disable