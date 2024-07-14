using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace DistributedCache.Services
{
    public class RedisCache:IRedisCache
    {
        private readonly IDistributedCache _distributedCache;

        public RedisCache(IDistributedCache distributedCache) 
        {
            _distributedCache = distributedCache;
        }

        public async Task<T> GetCacheDataAsync<T>(string key)
        {
            var cacheData = await _distributedCache.GetStringAsync(key);

            if (!string.IsNullOrEmpty(cacheData))
            {
                return JsonSerializer.Deserialize<T>(cacheData);
            }

            return default!;
        }

        public async Task RemoveCacheDataAsync(string key)
        {
            await _distributedCache.RemoveAsync(key);
        }

        public async Task SetCacheDataAsync<T>(string key, T value, double absExpRelToNow=10.0, double slidingExp=5.0)
        {
            //Configure the cache Expiry
            DistributedCacheEntryOptions cacheEntryOptions = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(absExpRelToNow),
                SlidingExpiration = TimeSpan.FromMinutes(slidingExp)                
            };

            await _distributedCache.SetStringAsync(key, JsonSerializer.Serialize(value), cacheEntryOptions);
        }
    }
}
