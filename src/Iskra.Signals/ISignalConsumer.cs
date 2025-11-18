namespace Iskra.Signals;

public interface ISignalConsumer
{
    void TrackProducer(ISignalProducer producer);
    void UntrackProducer(ISignalProducer producer);
    void ConsumeSignal();
}