namespace Iskra.Core.Components;

public abstract class BaseEmits
{
    protected bool Disabled { get; private set; }

    public void Disable()
    {
        Disabled = true;
    }
}