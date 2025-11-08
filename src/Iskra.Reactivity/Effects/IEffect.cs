namespace Iskra.Reactivity.Effects;

public interface IEffect : IDisposable
{
    void Trigger();
}