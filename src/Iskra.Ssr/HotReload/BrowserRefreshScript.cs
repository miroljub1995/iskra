using System.Reflection.Metadata;
using System.Runtime.InteropServices.JavaScript;
using Iskra.Core;
using Iskra.Core.Components;
using Iskra.JSCore;
using Iskra.Core.RenderRoot;
using Iskra.Signals;
using Iskra.Ssr.Abstractions.RenderRoot;
using Iskra.StdWeb;

namespace Iskra.Ssr.HotReload;

public sealed class BrowserRefreshScript : IComponent
{
    private IRenderSlot? _slot;

    public void Mount(IRenderSlot slot)
    {
        if (!MetadataUpdater.IsSupported)
        {
            return;
        }

        if (_slot is not null)
        {
            throw new InvalidOperationException("Component is already mounted.");
        }

        if (slot is IDomRenderSlot domRenderSlot)
        {
            if (!OperatingSystem.IsBrowser())
            {
                throw new PlatformNotSupportedException();
            }

            var existingNode = domRenderSlot.TryHydrateSlot();
            Node scriptNode;
            if (existingNode is not null)
            {
                if (!string.Equals(existingNode.NodeName, "SCRIPT", StringComparison.OrdinalIgnoreCase))
                {
                    throw new HydrationMismatchException(
                        $"Hydration mismatch: expected <script> but found <{existingNode.NodeName.ToLowerInvariant()}>.");
                }

                scriptNode = existingNode;
            }
            else
            {
                scriptNode = JSObjectProxyFactory.GetProxy<Window>(JSHost.GlobalThis)
                    .Document
                    .CreateElement("script");
            }

            var scriptEl = JSObjectProxyFactory.GetProxy<HTMLScriptElement>(scriptNode.JSObject);
            scriptEl.Src = "/_framework/aspnetcore-browser-refresh.js";

            if (existingNode is null)
            {
                domRenderSlot.Populate(scriptNode);
            }
        }
        else if (slot is ISsrRenderSlot ssrRenderSlot)
        {
            var scriptNode = new SsrElementNode { TagName = "script", IsVoid = false };
            scriptNode.SetAttribute("src", new Signal<string>("/_framework/aspnetcore-browser-refresh.js"));
            ssrRenderSlot.Populate(scriptNode);
        }

        _slot = slot;
    }

    public void Unmount()
    {
        if (_slot is IDomRenderSlot domRenderSlot)
        {
            if (!OperatingSystem.IsBrowser())
            {
                throw new PlatformNotSupportedException();
            }

            domRenderSlot.Empty();
        }
        else if (_slot is ISsrRenderSlot ssrRenderSlot)
        {
            ssrRenderSlot.Empty();
        }

        _slot = null;
    }
}
