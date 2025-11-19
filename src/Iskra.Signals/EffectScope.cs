namespace Iskra.Signals;

public class EffectScope : IEffectScope
{
    private IEffectScope? _parent;
    private readonly HashSet<IEffectScope> _children = [];
    private readonly HashSet<IEffect> _effects = [];
    private byte _disposed;

    public EffectScope() : this(false)
    {
    }

    public EffectScope(bool detached)
    {
        _parent = detached ? null : EffectScopeContext.Active;
        _parent?.AddChild(this);
    }

    public void AddChild(IEffectScope child)
    {
        _children.Add(child);
    }

    public void RemoveChild(IEffectScope child)
    {
        _children.Remove(child);
    }

    public void AddEffect(IEffect effect)
    {
        _effects.Add(effect);
    }

    public void RemoveEffect(IEffect effect)
    {
        _effects.Remove(effect);
    }

    public void Run(Action action)
    {
        var oldActive = EffectScopeContext.Active;
        EffectScopeContext.Active = this;
        try
        {
            action();
        }
        finally
        {
            EffectScopeContext.Active = oldActive;
        }
    }

    public void Dispose()
    {
        if (Interlocked.Exchange(ref _disposed, 1) == 1)
        {
            return;
        }

        while (_children.Count > 0)
        {
            _children.First().Dispose();
        }

        while (_effects.Count > 0)
        {
            _effects.First().Dispose();
        }

        _parent?.RemoveChild(this);
        _parent = null;
    }
}