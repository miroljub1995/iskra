namespace Iskra.Signals;

public interface IEffectScope : IDisposable
{
    void AddChild(IEffectScope child);
    void RemoveChild(IEffectScope child);
    void AddEffect(IEffect effect);
    void RemoveEffect(IEffect effect);
    void Run(Action action);
}