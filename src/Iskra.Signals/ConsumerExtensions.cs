using System.Runtime.CompilerServices;

namespace Iskra.Signals;

public static class ConsumerExtensions
{
    public static void Subscribe(this ConditionalWeakTable<ISignalConsumer, object?> consumers,
        ISignalProducer producer, ISignalConsumer consumer)
    {
        if (consumers.TryAdd(consumer, null))
        {
            consumer.TrackProducer(producer);
        }
    }

    public static void Unsubscribe(this ConditionalWeakTable<ISignalConsumer, object?> consumers,
        ISignalProducer producer, ISignalConsumer consumer)
    {
        if (consumers.Remove(consumer))
        {
            consumer.UntrackProducer(producer);
        }
    }

    public static IEnumerable<ISignalConsumer> GetConsumers(
        this ConditionalWeakTable<ISignalConsumer, object?> consumers) =>
        consumers.Select(keyValuePair => keyValuePair.Key);

    public static void ProduceSignal(this ISignalProducer producer)
    {
        LinkedList<ISignalConsumer> queue = [];
        Dictionary<ISignalConsumer, LinkedListNode<ISignalConsumer>> consumerNodes = [];

        EnqueueConsumers(queue, consumerNodes, producer);

        while (queue.First is { } first)
        {
            first.Value.ConsumeSignal();

            queue.RemoveFirst();
            consumerNodes.Remove(first.Value);

            if (first.Value is ISignalProducer firstAsProducer)
            {
                EnqueueConsumers(queue, consumerNodes, firstAsProducer);
            }
        }

        return;

        static void EnqueueConsumers(
            LinkedList<ISignalConsumer> queue,
            Dictionary<ISignalConsumer, LinkedListNode<ISignalConsumer>> consumerNodes,
            ISignalProducer producer
        )
        {
            foreach (var consumer in producer.GetConsumers())
            {
                // Existing consumer should be moved to the end of the queue
                if (consumerNodes.TryGetValue(consumer, out var node))
                {
                    queue.Remove(node);
                }
                else
                {
                    node = new LinkedListNode<ISignalConsumer>(consumer);
                    consumerNodes[consumer] = node;
                }

                queue.AddLast(node);
            }
        }
    }
}