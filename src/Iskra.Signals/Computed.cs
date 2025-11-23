using System.Runtime.CompilerServices;

namespace Iskra.Signals;

public class Computed<T>(Func<T> func, IEqualityComparer<T> comparer)
    : IReadOnlySignal<T>, ISignalProducer, ISignalConsumer
{
    [Flags]
    public enum StateFlags : byte
    {
        Initialized = 1,
        PendingCompute = 2,
    }

    private readonly ConditionalWeakTable<ISignalConsumer, object?> _consumers = new();
    private readonly Dictionary<ISignalProducer, long> _producers = [];
    private long _version;
    private StateFlags _flags;
    private T _value = default!;

    public Computed(Func<T> func) : this(func, EqualityComparer<T>.Default)
    {
    }

    public T Value
    {
        get
        {
            MakeValueUpToDate();
            ConsumerContext.Track(this);
            return _value;
        }
    }

    private void MakeValueUpToDate()
    {
        if (_flags.HasFlag(StateFlags.Initialized) && !_flags.HasFlag(StateFlags.PendingCompute))
        {
            return;
        }

        if (_flags.HasFlag(StateFlags.Initialized) && !AnyProducerChanged())
        {
            _flags &= ~StateFlags.PendingCompute;
            return;
        }

        UnsubscribeFromProducers();

        var oldActive = ConsumerContext.Active;
        ConsumerContext.Active = this;
        try
        {
            var oldValue = _value;
            _value = func();

            _flags |= StateFlags.Initialized;
            _flags &= ~StateFlags.PendingCompute;

            if (!comparer.Equals(oldValue, _value))
            {
                _version++;
            }
        }
        finally
        {
            ConsumerContext.Active = oldActive;
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

    public long GetVersion()
    {
        MakeValueUpToDate();
        return _version;
    }

    public void TrackProducer(ISignalProducer producer)
    {
        _producers.Add(producer, producer.GetVersion());
    }

    public void UntrackProducer(ISignalProducer producer)
    {
        _producers.Remove(producer);
    }

    public void ConsumeSignal()
    {
        _flags |= StateFlags.PendingCompute;
    }

    private void UnsubscribeFromProducers()
    {
        while (_producers.Count > 0)
        {
            _producers.First().Key.Unsubscribe(this);
        }
    }

    private bool AnyProducerChanged()
    {
        return _producers.Any(producer => producer.Value != producer.Key.GetVersion());
    }
}