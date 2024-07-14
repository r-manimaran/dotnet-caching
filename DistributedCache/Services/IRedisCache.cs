namespace DistributedCache.Services
{
    public interface IRedisCache
    {
        Task<T> GetCacheDataAsync<T>(string key);
        Task SetCacheDataAsync<T>(string key, T value, double absExpRelToNow, double slidingExp);
        Task RemoveCacheDataAsync(string key);
    }
}
