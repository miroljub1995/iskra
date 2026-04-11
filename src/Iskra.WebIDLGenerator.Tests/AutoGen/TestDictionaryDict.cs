// ReSharper disable All

namespace Iskra.WebIDLGenerator.Tests;

#nullable enable

public partial class TestDictionaryDict: global::Iskra.JSCore.JSObjectProxy
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public TestDictionaryDict(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public TestDictionaryDict(): base(global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "Object"))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string Name
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.WebIDLGenerator.Tests.PropertyAccessor>(JSObject, "name");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string, global::Iskra.WebIDLGenerator.Tests.PropertyAccessor>(JSObject, "name", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public int Age
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<int, global::Iskra.WebIDLGenerator.Tests.PropertyAccessor>(JSObject, "age");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<int, global::Iskra.WebIDLGenerator.Tests.PropertyAccessor>(JSObject, "age", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool Active
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.WebIDLGenerator.Tests.PropertyAccessor>(JSObject, "active");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<bool, global::Iskra.WebIDLGenerator.Tests.PropertyAccessor>(JSObject, "active", value);
    }
}

#nullable disable