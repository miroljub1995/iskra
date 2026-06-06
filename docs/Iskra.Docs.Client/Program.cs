using System.Runtime.InteropServices.JavaScript;
using Iskra.Browser;
using Iskra.Browser.Components;
using Iskra.Browser.Features.Routing;
using Iskra.Core;
using Iskra.Browser.Features.HydrationState;
using Iskra.Browser.Abstractions.Features.HydrationState;
using Iskra.Core.Features.Routing;
using Iskra.Core.HotReload;
using Iskra.Docs.Client.Components;
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

var hydration = new ClientHydrationStateFeature();

var _ = new IskraHostBuilder()
    .UseRootElement(appElement)
    .UseTeleport()
    .SetFeature<IClientHydrationStateFeature>(hydration)
    .SetFeature<INavigationFeature>(new ClientNavigationFeature(window))
    .UseRootComponent(() => new HydrationRoot { Children = [new DocsApp { Props = new DocsAppProps() }] })
    .UseDefaultHotReloadManager()
    .Build()
    .Mount();

await Task.Delay(Timeout.Infinite);
