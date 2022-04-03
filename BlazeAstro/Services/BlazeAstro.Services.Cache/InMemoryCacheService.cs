﻿namespace BlazeAstro.Services.Cache
{
    using System;

    using Microsoft.Extensions.Caching.Memory;

    using BlazeAstro.Services.Cache.Contracts;
    using System.Threading.Tasks;

    public class InMemoryCacheService<TValue> : ICacheService<TValue>
        where TValue : class
    {
        private readonly IMemoryCache memoryCache;
        private readonly MemoryCacheEntryOptions options;

        public InMemoryCacheService(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
            this.options = new MemoryCacheEntryOptions();
            options.AbsoluteExpiration = DateTimeOffset.Now.AddDays(1);
        }

        public Task Set(string key, TValue value)
        {
            memoryCache.Set(key, value, options);

            return Task.CompletedTask;
        }

        public Task<TValue> Get(string key)
        {
            var cacheData = memoryCache.Get<TValue>(key);

            return Task.FromResult(cacheData);
        }
    }
}