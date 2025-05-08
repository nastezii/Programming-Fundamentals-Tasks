namespace Task_2
{
    public class CacheItem<T>
    {
        public T Result { get; private set; }
        public DateTime CreationTime { get; private set; }
        public DateTime LastAccessed { get; private set; }
        public int Frequency { get; private set; }

        public CacheItem(T result)
        {
            Result = result;
            LastAccessed = CreationTime = DateTime.Now;
            Frequency = 1;
        }

        public void RecordAccess()
        {
            LastAccessed = DateTime.Now;
            Frequency++;
        }
    }
}