
namespace Task_2
{
    public class Memoizer
    {
        public Func<T, TResult> Memoize<T, TResult>(
            Func<T, TResult> function,
            int maxCacheSize = int.MaxValue,
            int itemTTLSeconds = -1,
            EvictionStrategy strategy = EvictionStrategy.LRU,
            Func<Dictionary<int, CacheItem<TResult>>, int> customEvictionPolicy = null)
        {
            Cache<T, TResult> cache;

            switch (strategy)
            {
                case EvictionStrategy.TimeBased:
                    if (itemTTLSeconds <= 0)
                        throw new ArgumentException("Time-based strategy requires a positive itemTTLSeconds value.", nameof(itemTTLSeconds));
                    cache = new Cache<T, TResult>(itemTTLSeconds);
                    break;

                case EvictionStrategy.Custom:
                    if (customEvictionPolicy == null)
                        throw new ArgumentNullException(nameof(customEvictionPolicy), "Custom strategy requires a non-null eviction policy function.");
                    cache = new Cache<T, TResult>(customEvictionPolicy);
                    break;

                case EvictionStrategy.LRU:
                case EvictionStrategy.LFU:
                    if (maxCacheSize <= 0)
                        throw new ArgumentException("LRU and LFU strategies require a positive maxCacheSize.", nameof(maxCacheSize));
                    cache = new Cache<T, TResult>(strategy, maxCacheSize);
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
                var newItem = new CacheItem<TResult>(result);
                cache.AddItem(key, newItem);

                return result;
            };
        }
    }
}