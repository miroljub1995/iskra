namespace Iskra.Signals;

public class Effect : IEffect
{
    private readonly IEffectScope _scope;
    private readonly Action<Action<Action>> _fn;
    private readonly List<Action> _cleanupFns = [];
    private readonly Dictionary<ISignalProducer, long> _producers = [];
    private byte _disposed;

    public Effect(Action<Action<Action>> fn)
    {
        _scope = EffectScopeContext.Active ?? throw new("Can not create effect outside of scope.");

        _fn = fn;

        _scope.AddEffect(this);
        RunFun();
    }

    public void Dispose()
    {
        if (Interlocked.Exchange(ref _disposed, 1) == 0)
        {
            UnsubscribeFromProducers();
            FlushCleanups();
            _scope.RemoveEffect(this);
        }
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
        if (_disposed != 0)
        {
            return;
        }

        if (!AnyProducerChanged())
        {
            return;
        }

        UnsubscribeFromProducers();
        FlushCleanups();
        RunFun();
    }

    private void RunFun()
    {
        var oldConsumer = ConsumerContext.Active;
        ConsumerContext.Active = this;
        try
        {
            _fn(_cleanupFns.Add);
        }
        finally
        {
            ConsumerContext.Active = oldConsumer;
        }
    }

    private void UnsubscribeFromProducers()
    {
        while (_producers.Count > 0)
        {
            _producers.First().Key.Unsubscribe(this);
        }
    }

    private void FlushCleanups()
    {
        foreach (var cleanupFn in _cleanupFns)
        {
            cleanupFn();
        }

        _cleanupFns.Clear();
    }

    private bool AnyProducerChanged()
    {
        return _producers.Any(producer => producer.Value != producer.Key.GetVersion());
    }
}