using System.Text;
using Iskra.Core;
using Iskra.Core.Features;
using Iskra.Core.Features.HydrationState;
using Iskra.Core.RenderRoot;
using Iskra.Docs.Components;

var vars = Environment.GetEnvironmentVariables();

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapStaticAssets();

app.MapGet("/", async (httpContext) =>
{
    var root = new SsrRenderRoot();
    var prefetch = new ServerPrefetchFeature();

    using var _ = new IskraHostBuilder()
        .UseRootRenderer(root)
        .SetFeature<IServerPrefetchFeature>(prefetch)
        .SetFeature<IServerHydrationStateFeature>(new ServerHydrationStateFeature())
        .SetFeature(httpContext)
        .UseRootComponent(() => new DocsPage { Props = new DocsPageProps() })
        .Build()
        .Mount();

    await prefetch.WaitForCompletionAsync(httpContext.RequestAborted);

    httpContext.Response.Headers.ContentType = "text/html";
    await httpContext.Response.BodyWriter.WriteAsync(Encoding.UTF8.GetBytes("<!DOCTYPE html>"));
    await root.WriteAsync(httpContext.Response.BodyWriter, cancellationToken: httpContext.RequestAborted);
    await httpContext.Response.BodyWriter.FlushAsync(httpContext.RequestAborted);
});

app.Run();
