using Iskra.Core.Components;
using Iskra.Core.Features;
using Iskra.Core.Features.HydrationState;
using Iskra.Core.RenderRoot;

namespace Iskra.Core;

public sealed class IskraHost
{
    private readonly Func<IComponent> _rootComponentFactory;
    private readonly IRenderRoot _renderRoot;
    private readonly IFeatureCollection _rootFeatures;

    internal IskraHost(Func<IComponent> rootComponentFactory, IRenderRoot renderRoot, IFeatureCollection rootFeatures)
    {
        _rootComponentFactory = rootComponentFactory;
        _renderRoot = renderRoot;
        _rootFeatures = rootFeatures;
    }

    public IDisposable Mount()
    {
        var scope = new Signals.EffectScope();
        scope.Run(() =>
        {
            var prevFeatures = AppFeatures.Current;
            AppFeatures.Current = _rootFeatures;
            try
            {
                if (OperatingSystem.IsBrowser() && _renderRoot is DomRenderRoot domRootBefore)
                {
                    var hydrationState = _rootFeatures.Get<IClientHydrationStateFeature>();

                    if (hydrationState is not null
                        && (bool?)hydrationState.Value["hydrate"] == true)
                    {
                        domRootBefore.BeginHydration();
                    }
                }

                _rootComponentFactory().Mount(_renderRoot.CreateFirstSlot());

                if (OperatingSystem.IsBrowser() && _renderRoot is DomRenderRoot domRootAfter)
                {
                    domRootAfter.EndHydration();
                }
            }
            finally
            {
                AppFeatures.Current = prevFeatures;
            }
        });
        return scope;
    }
}
