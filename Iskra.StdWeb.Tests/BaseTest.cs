using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices.JavaScript;

namespace Iskra.StdWeb.Tests;

public class BaseTest<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)] T>(
    string testApiPropertyName)
{
    protected T GetSut()
    {
        return WrapperFactory.GetWrapper<T>(
            JSHost.GlobalThis.GetPropertyAsJSObject("testApi")?.GetPropertyAsJSObject(testApiPropertyName) ??
            throw new Exception($"Could not find testApi property {testApiPropertyName}."));
    }

    protected bool PropertyIsReadOnly(string propertyName)
    {
        var property = typeof(T).GetProperty(propertyName) ??
                       throw new Exception($"Property {propertyName} not found.");

        return property is { CanRead: true, CanWrite: false };
    }
}