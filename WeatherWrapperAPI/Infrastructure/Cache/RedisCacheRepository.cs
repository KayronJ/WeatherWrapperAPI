using Microsoft.Extensions.Caching.Distributed;
using WeatherWrapperAPI.Models.Interfaces;

namespace WeatherWrapperAPI.Infrastructure.Cache
{
    public class RedisCacheRepository : ICacheRepository
    {
        private readonly IDistributedCache _cache;
        public RedisCacheRepository(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<string?> GetAsync(string key) => await _cache.GetStringAsync(key);

        public async Task SetAsync(string key, string value)
        {
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(60),
                SlidingExpiration = TimeSpan.FromMinutes(30)
            };
            await _cache.SetStringAsync(key, value, options);
        }
    }
}
