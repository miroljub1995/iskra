namespace Iskra.Signals;

public interface ISignalProducer
{
    void Subscribe(ISignalConsumer consumer);
    void Unsubscribe(ISignalConsumer consumer);
    IEnumerable<ISignalConsumer> GetConsumers();
    void ProduceSignal();
}