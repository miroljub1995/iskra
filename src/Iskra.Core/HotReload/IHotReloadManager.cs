namespace Iskra.Core.HotReload;

public interface IHotReloadManager
{
    public event Action<Type[]?>? OnDeltaApplied;
}
