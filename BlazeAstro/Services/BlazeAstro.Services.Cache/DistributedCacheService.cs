namespace BlazeAstro.Services.Cache
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Caching.Distributed;

    using Newtonsoft.Json;

    using BlazeAstro.Services.Cache.Contracts;

    public class DistributedCacheService<TValue> : ICacheService<TValue>
        where TValue : class
    {
        private readonly IDistributedCache cache;
        private readonly DistributedCacheEntryOptions options;

        public DistributedCacheService(IDistributedCache cache)
        {
            this.cache = cache;
            this.options = new DistributedCacheEntryOptions();
            options.AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(1);
        }

        public async Task Set(string key, TValue value)
        {
            var cacheData = JsonConvert.SerializeObject(value);
            await cache.SetStringAsync(key, cacheData, options);
        }

        public async Task<TValue> Get(string key)
        {
            var cacheData = await cache.GetStringAsync(key);

            if (!string.IsNullOrEmpty(cacheData))
            {
                return JsonConvert.DeserializeObject<TValue>(cacheData);
            }

            return null;
        }
    }
}