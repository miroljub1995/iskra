namespace IskraSample;

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
            _value = value;
            DepsTracking.Trigger(this, nameof(Value));
        }
    }
}