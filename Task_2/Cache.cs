namespace Task_2
{
    public class Cache<T, TResult>
    {
        private Dictionary<int, CacheItem<TResult>> _cache = new();

        private EvictionStrategy _evictionStrategy;
        private Func<Dictionary<int, CacheItem<TResult>>, int> _customEvictionPolicy;
        private int _maxCacheSize;
        private int _itemTTLSeconds;
        private System.Timers.Timer _timer;

        public Cache(int itemTTLSeconds)
        {
            _evictionStrategy = EvictionStrategy.TimeBased;
            _itemTTLSeconds = itemTTLSeconds;
            _timer = new System.Timers.Timer(itemTTLSeconds * 1000);
            _timer.Elapsed += (sender, e) => RemoveExpiredItems();
            _timer.AutoReset = true;
            _timer.Start();
        }

        public Cache(EvictionStrategy evictionStrategy, int maxCacheSize)
        {
            _evictionStrategy = evictionStrategy;
            _maxCacheSize = maxCacheSize;
        }

        public Cache(Func<Dictionary<int, CacheItem<TResult>>, int> customEvictionPolicy)
        {
            _evictionStrategy = EvictionStrategy.Custom;
            _customEvictionPolicy = customEvictionPolicy;
        }

        public CacheItem<TResult> GetItem(int key) => _cache.ContainsKey(key) ? _cache[key] : null;

        public void AddItem(int key, CacheItem<TResult> item)
        {
            if (_evictionStrategy == EvictionStrategy.Custom)
            {
                int keyToEvict = _customEvictionPolicy(_cache);

                if (_cache.ContainsKey(keyToEvict))
                    _cache.Remove(keyToEvict);
            }
            else if (_cache.Count() >= _maxCacheSize && _evictionStrategy != EvictionStrategy.TimeBased)
            {
                EvictCache();
            }

            _cache[key] = item;
        }

        private void EvictCache()
        {
            switch (_evictionStrategy)
            {
                case EvictionStrategy.LFU:
                    EvictLFU();
                    break;

                case EvictionStrategy.LRU:
                    EvictLRU();
                    break;

                case EvictionStrategy.Custom:
                    break;
            }
        }

        private void EvictLFU()
        {
            var item = _cache.OrderBy(item => item.Value.Frequency).FirstOrDefault();
            _cache.Remove(item.Key);
        }

        private void EvictLRU()
        {
            var item = _cache.OrderBy(item => item.Value.LastAccessed).FirstOrDefault();
            _cache.Remove(item.Key);
        }

        private void RemoveExpiredItems()
        {
            var now = DateTime.Now;

            var expiredKeys = _cache
                .Where(item => (now - item.Value.CreationTime).TotalSeconds >= _itemTTLSeconds)
                .Select(item => item.Key)
                .ToList();

            foreach (var key in expiredKeys)
                _cache.Remove(key);
        }
    }
}