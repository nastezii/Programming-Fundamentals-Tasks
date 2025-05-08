using Task_3;

public class BiDirectionalPriorityQueue<T>
{
    private List<Node<T>> _queue = new();

    public int Count => _queue.Count;
    public void Enqueue(T item, int priority) => _queue.Add(new Node<T>(item, priority));

    public T Dequeue(Mode mode)
    {
        CheckQueueCapacity();

        var target = GetNodeByMode(mode);
        _queue.Remove(target);
        return target.Item;
    }

    public T Peek(Mode mode)
    {
        CheckQueueCapacity();
        return GetNodeByMode(mode).Item;
    }

    private Node<T> GetNodeByMode(Mode mode)
    {
        return mode switch
        {
            Mode.Highest => GetHighestPriority(),
            Mode.Lowest => GetLowestPriority(),
            Mode.Newest => GetNewest(),
            Mode.Oldest => GetOldest(),
            _ => throw new ArgumentException("Invalid mode.")
        };
    }

    private Node<T> GetHighestPriority() =>_queue.OrderByDescending(n => n.Priority).First();
    private Node<T> GetLowestPriority() => _queue.OrderBy(n => n.Priority).First();
    private Node<T> GetNewest() => _queue[^1]; 
    private Node<T> GetOldest() =>_queue[0];

    private void CheckQueueCapacity()
    {
        if (Count == 0)
            throw new InvalidOperationException("The queue is empty. Cannot dequeue an element.");
    }
}