namespace Iskra.Signals;

public class ConsumerContext
{
    private static readonly ThreadLocal<ISignalConsumer?> ActiveLocal = new();

    public static ISignalConsumer? Active
    {
        get => ActiveLocal.Value;
        set => ActiveLocal.Value = value;
    }

    public static void Track(ISignalProducer producer)
    {
        if (Active is not null)
        {
            producer.Subscribe(Active);
        }
    }
}