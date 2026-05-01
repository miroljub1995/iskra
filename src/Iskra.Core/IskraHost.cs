using Iskra.Core.Components;
using Iskra.Core.Features;
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
                _rootComponentFactory().Mount(_renderRoot.GetNextSlot());
            }
            finally
            {
                AppFeatures.Current = prevFeatures;
            }
        });
        return scope;
    }
}
