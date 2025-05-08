namespace Task_2
{
    public static class MemoizationHelper
    {
        public static Func<T, TResult> Memoize<T, TResult>(
            Func<T, TResult> function,
            int maxCacheSize = int.MaxValue,
            int itemTTLSeconds = -1,
            Memoizer.EvictionStrategy strategy = Memoizer.EvictionStrategy.LRU,
            Func<Dictionary<int, Memoizer.CacheItem<TResult>>, int> customEvictionPolicy = null)
        {
            Memoizer.Cache<T, TResult> cache;

            switch (strategy)
            {
                case Memoizer.EvictionStrategy.TimeBased:
                    if (itemTTLSeconds <= 0)
                        throw new ArgumentException("Time-based strategy requires a positive itemTTLSeconds value.", nameof(itemTTLSeconds));
                    cache = new Memoizer.Cache<T, TResult>(itemTTLSeconds);
                    break;

                case Memoizer.EvictionStrategy.Custom:
                    if (customEvictionPolicy == null)
                        throw new ArgumentNullException(nameof(customEvictionPolicy), "Custom strategy requires a non-null eviction policy function.");
                    cache = new Memoizer.Cache<T, TResult>(customEvictionPolicy);
                    break;

                case Memoizer.EvictionStrategy.LRU:
                case Memoizer.EvictionStrategy.LFU:
                    if (maxCacheSize <= 0)
                        throw new ArgumentException("LRU and LFU strategies require a positive maxCacheSize.", nameof(maxCacheSize));
                    cache = new Memoizer.Cache<T, TResult>(strategy, maxCacheSize);
                    break;

                default:
                    throw new ArgumentException("Unknown eviction strategy.", nameof(strategy));
            }

            return arg =>
            {
                if (arg == null)
                    throw new ArgumentNullException(nameof(arg), "Argument can't be null");

                int key = arg.GetHashCode();
                var cacheItem = cache.GetItem(key);

                if (cacheItem != null)
                {
                    cacheItem.RecordAccess();
                    return cacheItem.Result;
                }

                var result = function(arg);
                var newItem = new Memoizer.CacheItem<TResult>(result);
                cache.AddItem(key, newItem);

                return result;
            };
        }
    }
}