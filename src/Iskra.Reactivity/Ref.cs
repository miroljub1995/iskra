namespace Iskra.Reactivity;

public class Ref<TValue>(TValue value)
{
    private TValue _value = value;

    public TValue Value
    {
        get
        {
            DepsTracking.Track(this, nameof(Value));
            return _value;
        }
        set
        {
            if (value?.Equals(_value) == true)
            {
                return;
            }

            _value = value;
            DepsTracking.Trigger(this, nameof(Value));
        }
    }
}