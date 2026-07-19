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

public sealed class HotReloadInterceptionScript : IComponent
{
    private const string ScriptContent = """
        (function() {
            if (!window.Blazor) window.Blazor = {};
            if (!window.Blazor._internal) window.Blazor._internal = {};
            var real = null;
            var beforeUpdate = null;
            Object.defineProperty(window.Blazor._internal, 'applyHotReloadDeltas', {
                configurable: true,
                enumerable: true,
                get: function() {
                    if (!real) return undefined;
                    return function(deltas, level) {
                        if (beforeUpdate) {
                            try { beforeUpdate(JSON.stringify(deltas)); } catch(e) { console.error('[Iskra] BeforeUpdate error:', e); }
                        }
                        return real(deltas, level);
                    };
                },
                set: function(fn) {
                    real = fn;
                    if (!beforeUpdate) {
                        try {
                            getDotnetRuntime(0)?.getAssemblyExports('Iskra.Browser').then(function(exports) {
                                beforeUpdate = exports.Iskra.Browser.Features.HotReload.HotReloadInterop.BeforeUpdate;
                            });
                        } catch(e) {}
                    }
                }
            });
        })();
        """;

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
            if (existingNode is null)
            {
                var scriptNode = JSObjectProxyFactory.GetProxy<Window>(JSHost.GlobalThis)
                    .Document
                    .CreateElement("script");
                var scriptEl = JSObjectProxyFactory.GetProxy<HTMLScriptElement>(scriptNode.JSObject);
                scriptEl.TextContent = ScriptContent;
                domRenderSlot.Populate(scriptNode);
            }
        }
        else if (slot is ISsrRenderSlot ssrRenderSlot)
        {
            var scriptNode = new SsrElementNode { TagName = "script", IsVoid = false };
            var childRoot = ssrRenderSlot.CreateChildRoot(scriptNode);
            if (childRoot.CreateFirstSlot() is ISsrRenderSlot textSlot)
            {
                textSlot.Populate(new SsrTextNode { TextContent = new Signal<string>(ScriptContent) });
            }
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
