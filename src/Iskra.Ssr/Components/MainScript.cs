using Iskra.Core.Components;
using Iskra.Dom.Components;
using Iskra.Core.Features;
using Iskra.Core.RenderRoot;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.StaticAssets;
using Microsoft.Extensions.DependencyInjection;
using Iskra.Signals;

namespace Iskra.Ssr.Components;

public sealed class MainScript : IComponent
{
    private Script? _script;

    public void Mount(IRenderSlot slot)
    {
        if (_script is not null)
        {
            throw new InvalidOperationException("Component is already mounted.");
        }

        var httpContext = AppFeatures.Features.Get<HttpContext>()
            ?? throw new InvalidOperationException("HttpContext is not registered as a feature.");

        var dotnetJsPath = ResolveFingerprintedDotnetJsPath(httpContext);

        _script = new Script
        {
            Props = new ScriptProps { Type = "module".ToConstSignal() },
            Children = [new DomText { Text = $$"""
                import { dotnet } from '{{dotnetJsPath}}'
                const { runMain } = await dotnet.create();
                await runMain();
                """.ToConstSignal() }],
        };

        _script.Mount(slot);
    }

    public void Unmount()
    {
        _script?.Unmount();
        _script = null;
    }

    private static string ResolveFingerprintedDotnetJsPath(HttpContext httpContext)
    {
        var dataSources = httpContext.RequestServices.GetRequiredService<EndpointDataSource>();
        foreach (var endpoint in dataSources.Endpoints)
        {
            var descriptor = endpoint.Metadata.GetMetadata<StaticAssetDescriptor>();
            if (descriptor is null)
                continue;

            var label = descriptor.Properties.FirstOrDefault(p => p.Name == "label");
            if (label is not null && label.Value == "_framework/dotnet.js")
                return "/" + descriptor.Route;
        }

        throw new InvalidOperationException(
            "Could not find a fingerprinted _framework/dotnet.js endpoint. Ensure MapStaticAssets() is called before mounting.");
    }
}
