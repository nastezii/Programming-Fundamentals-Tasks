namespace Task_3
{
    public class Node<T>
    {
        public T Item { get; private set; }
        public int Priority { get; private set; }

        public Node(T item, int priority)
        {
            Item = item;
            Priority = priority;
        }
    }
}
