using System.Runtime.CompilerServices;

namespace Iskra.Signals;

public class Signal<T>(T value, IEqualityComparer<T> comparer) : ISignal<T>, ISignalProducer
{
    public Signal(T value) : this(value, EqualityComparer<T>.Default)
    {
    }

    private long _version;

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

            _version++;
            _value = value;
            ProduceSignal();
        }
    }

    public void Subscribe(ISignalConsumer consumer)
    {
        _consumers.Subscribe(this, consumer);
    }

    public void Unsubscribe(ISignalConsumer consumer)
    {
        _consumers.Unsubscribe(this, consumer);
    }

    public IEnumerable<ISignalConsumer> GetConsumers()
    {
        return _consumers.GetConsumers();
    }

    public void ProduceSignal()
    {
        ConsumerExtensions.ProduceSignal(this);
    }

    public long GetVersion() => _version;
}