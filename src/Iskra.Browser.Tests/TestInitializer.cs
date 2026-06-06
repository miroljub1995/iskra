using Iskra.StdWeb;

namespace Iskra.Browser.Tests;

public static class TestInitializer
{
    [Before(Assembly)]
    public static async Task Before()
    {
        await StdWebProxyFactory.InitializeAsync();
    }
}
