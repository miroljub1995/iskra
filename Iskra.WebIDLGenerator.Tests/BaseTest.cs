using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices.JavaScript;
using Iskra.JSCore;

namespace Iskra.WebIDLGenerator.Tests;

public class BaseTest<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)] T>(
    string propName
)
    where T : JSObjectProxy
{
    protected T GetSut()
    {
        return JSObjectProxyFactory.GetProxy<T>(
            JSHost.GlobalThis.GetPropertyAsJSObject("tests")?.GetPropertyAsJSObject(propName) ??
            throw new Exception($"Could not find tests property {propName}."));
    }

    protected bool PropertyIsReadOnly(string propertyName)
    {
        var property = typeof(T).GetProperty(propertyName) ??
                       throw new Exception($"Property {propertyName} not found.");

        return property is { CanRead: true, CanWrite: false };
    }
}