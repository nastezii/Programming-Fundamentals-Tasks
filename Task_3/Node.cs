namespace Task_3
{
    public class Node
    {
        public T Item { get; private set; }
        public int Priority { get; private set; }
        public long Timestamp { get; private set; }

        public Node(T item, int priority, long timestamp)
        {
            Item = item;
            Priority = priority;
            Timestamp = timestamp;
        }
    }
}
