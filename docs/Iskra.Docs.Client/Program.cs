using System.Runtime.InteropServices.JavaScript;
using Iskra.Core;
using Iskra.Docs.Components;
using Iskra.JSCore;
using Iskra.StdWeb;

if (!OperatingSystem.IsBrowser())
{
    throw new PlatformNotSupportedException();
}

await StdWebProxyFactory.InitializeAsync();

var window = JSObjectProxyFactory.GetProxy<Window>(JSHost.GlobalThis);
var appElement = window.Document.GetElementById("app")
    ?? throw new System.Exception("Element with id 'app' not found.");

var _ = new IskraHostBuilder()
    .UseRootElement(appElement)
    .UseRootComponent(() => new DocsApp { Props = new DocsAppProps() })
    .Build()
    .Mount();

await Task.Delay(Timeout.Infinite);
