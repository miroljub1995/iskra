namespace Iskra.Signals;

public class ConsumerContext
{
    public static ISignalConsumer? Active { get; set; }

    public static void Track(ISignalProducer producer)
    {
        if (Active is not null)
        {
            producer.Subscribe(Active);
            // var subscription = producer.Subscribe(Active);
            // Active.AddSubscription(subscription);
        }
    }
}