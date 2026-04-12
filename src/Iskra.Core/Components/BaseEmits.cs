namespace Iskra.Core.Components;

public abstract class BaseEmits
{
    public bool Disabled { get; private set; }

    public void Disable()
    {
        Disabled = true;
    }
}