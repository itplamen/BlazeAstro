namespace BlazeAstro.Services.DataProviders
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Caching.Distributed;

    using Newtonsoft.Json;

    using BlazeAstro.Services.DataProviders.Contracts;
    using BlazeAstro.Services.Models.Contracts;

    public class CacheDataProvider<TRequest, TResponse> : IDataProvider<TRequest, TResponse>
        where TRequest : IRequest
        where TResponse : class
    {
        private readonly IDistributedCache cache;
        private readonly DistributedCacheEntryOptions options;
        private readonly IDataProvider<TRequest, TResponse> decorated;

        public CacheDataProvider(IDistributedCache cache, IDataProvider<TRequest, TResponse> decorated)
        {
            this.cache = cache;
            this.decorated = decorated;
            this.options = new DistributedCacheEntryOptions();
            options.AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(1);
        }

        public async Task<TResponse> GetData(TRequest request)
        {
            var json = await cache.GetStringAsync(request.CacheKey);

            if (string.IsNullOrEmpty(json))
            {
                var response = await decorated.GetData(request);

                var cacheData = JsonConvert.SerializeObject(response);
                await cache.SetStringAsync(request.CacheKey, cacheData, options);

                return response;
            }

            var cachedData = JsonConvert.DeserializeObject<TResponse>(json);

            return cachedData;
        }
    }
}