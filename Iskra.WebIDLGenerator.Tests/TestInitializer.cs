using Iskra.JSCore;

namespace Iskra.WebIDLGenerator.Tests;

public static class TestInitializer
{
    [Before(Assembly)]
    public static async Task Before()
    {
        await JSCoreShims.InitializeAsync();
        JSCoreProxyFactory.Initialize();
        WebIDLGeneratorTestsProxyFactory.Initialize();
    }
}