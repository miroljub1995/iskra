using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Iskra.Signals;

public class Computed<T>(Func<T> func)
    : IReadOnlySignal<T>, ISignalProducer, ISignalConsumer
{
    private readonly ConditionalWeakTable<ISignalConsumer, object?> _consumers = new();
    private readonly HashSet<ISignalProducer> _producers = [];

    [MemberNotNullWhen(false, nameof(_value))]
    private bool IsDirty { get; set; } = true;

    private T? _value;

    public T Value
    {
        get
        {
            ConsumerContext.Track(this);
            return IsDirty ? ComputeValue() : _value;
        }
    }

    private T ComputeValue()
    {
        var oldActive = ConsumerContext.Active;
        ConsumerContext.Active = this;
        try
        {
            _value = func();
            IsDirty = false;
            return _value;
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

    public void TrackProducer(ISignalProducer producer)
    {
        _producers.Add(producer);
    }

    public void UntrackProducer(ISignalProducer producer)
    {
        _producers.Remove(producer);
    }

    public void ConsumeSignal()
    {
        while (_producers.Count > 0)
        {
            _producers.First().Unsubscribe(this);
        }

        _value = default;
        IsDirty = true;
    }
}