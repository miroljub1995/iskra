using System.Text;
using Iskra.Core;
using Iskra.Core.Features;
using Iskra.Ssr;
using Iskra.Ssr.Abstractions.Features;
using Iskra.Ssr.Features;
using Iskra.Ssr.Features.Routing;
using Iskra.Ssr.Abstractions.Features.HydrationState;
using Iskra.Ssr.Features.HydrationState;
using Iskra.Core.Features.Routing;
using Iskra.Core.RenderRoot;
using Iskra.Ssr.RenderRoot;
using MyIskraApp.Components;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapStaticAssets();

app.MapFallback(async (httpContext) =>
{
    var requestPath = httpContext.Request.Path.Value ?? "/";
    var navigation = new ServerNavigationFeature(requestPath);
    var root = new SsrRenderRoot();
    var prefetch = new ServerPrefetchFeature();

    using var _ = new IskraHostBuilder()
        .UseRootRenderer(root)
        .UseTeleport()
        .SetFeature<IServerPrefetchFeature>(prefetch)
        .SetFeature<IServerHydrationStateFeature>(new ServerHydrationStateFeature())
        .SetFeature<INavigationFeature>(navigation)
        .SetFeature(httpContext)
        .UseRootComponent(() => new AppPage { Props = new AppPageProps() })
        .Build()
        .Mount();

    await prefetch.WaitForCompletionAsync(httpContext.RequestAborted);

    if (navigation.RedirectLocation is { } location)
    {
        httpContext.Response.Redirect(location);
        return;
    }

    httpContext.Response.Headers.ContentType = "text/html";
    await httpContext.Response.BodyWriter.WriteAsync(Encoding.UTF8.GetBytes("<!DOCTYPE html>"));
    await root.WriteAsync(httpContext.Response.BodyWriter, cancellationToken: httpContext.RequestAborted);
    await httpContext.Response.BodyWriter.FlushAsync(httpContext.RequestAborted);
});

app.Run();
