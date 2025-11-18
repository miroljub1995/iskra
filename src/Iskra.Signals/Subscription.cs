namespace Iskra.Signals;

internal class Subscription(
    LinkedList<WeakReference<ISignalConsumer>> consumers,
    LinkedListNode<WeakReference<ISignalConsumer>> node
) : IDisposable
{
    public void Dispose()
    {
        if (node.List is not null)
        {
            consumers.Remove(node);
        }
    }
}