using System.Text;
using Iskra.Core;
using Iskra.Core.Features;
using Iskra.Core.RenderRoot;
using Iskra.Docs.Server.Components;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateSlimBuilder(args);
var app = builder.Build();

app.UseStaticFiles();

// Serve _framework assets (wasm, js) from the Iskra.Docs.Client output
var baseDir = AppContext.BaseDirectory.TrimEnd(Path.DirectorySeparatorChar);
var clientFramework = Path.GetFullPath(Path.Combine(
    baseDir,
    "..", "..", "..", "..",
    "Iskra.Docs.Client", "bin",
    Path.GetFileName(Path.GetDirectoryName(baseDir)!), // config (Debug/Release)
    Path.GetFileName(baseDir),                          // tfm (net10.0, etc.)
    "wwwroot", "_framework"
));
if (Directory.Exists(clientFramework))
{
    app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(clientFramework),
        RequestPath = "/_framework"
    });
}

app.MapGet("/", async (httpContext) =>
{
    var root = new SsrRenderRoot();
    var prefetch = new ServerPrefetchFeature();

    using var _ = new IskraHostBuilder()
        .UseRootRenderer(root)
        .SetFeature<IServerPrefetchFeature>(prefetch)
        .SetFeature(httpContext)
        .UseRootComponent(() => new DocsPage { Props = new DocsPageProps() })
        .Build()
        .Mount();

    await prefetch.WaitForCompletionAsync();

    httpContext.Response.Headers.ContentType = "text/html";
    await httpContext.Response.BodyWriter.WriteAsync(Encoding.UTF8.GetBytes("<!DOCTYPE html>"));
    await root.WriteAsync(httpContext.Response.BodyWriter, cancellationToken: httpContext.RequestAborted);
});

app.Run();
