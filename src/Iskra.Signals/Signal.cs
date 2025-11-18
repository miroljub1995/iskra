using System.Runtime.CompilerServices;

namespace Iskra.Signals;

public class Signal<T>(T value, IEqualityComparer<T> comparer) : ISignal<T>, ISignalProducer
{
    public Signal(T value) : this(value, EqualityComparer<T>.Default)
    {
    }

    private readonly ConditionalWeakTable<ISignalConsumer, object?> _consumers = new();

    // TODO: In dotnet 10 use 'field' keyword in property
    private T _value = value;

    public T Value
    {
        get
        {
            ConsumerContext.Track(this);
            return _value;
        }
        set
        {
            if (comparer.Equals(_value, value))
            {
                return;
            }

            _value = value;
            ProduceSignal();
        }
    }

    public void Subscribe(ISignalConsumer consumer)
    {
        _consumers.TryAdd(consumer, null);
        consumer.TrackProducer(this);
    }

    public void Unsubscribe(ISignalConsumer consumer)
    {
        _consumers.Remove(consumer);
        consumer.UntrackProducer(this);
    }

    public void ProduceSignal()
    {
        foreach (var keyValuePair in _consumers)
        {
            keyValuePair.Key.ConsumeSignal();
        }
    }
}