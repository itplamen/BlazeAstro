namespace BlazeAstro.Infrastructure.IoCContainer.IoCPackages
{
    using System.Collections.Generic;

    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.Caching.Distributed;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using BlazeAstro.Infrastructure.IoCContainer.Contracts;
    using BlazeAstro.Services.Cache;
    using BlazeAstro.Services.Cache.Contracts;
    using BlazeAstro.Services.Models.Apod;
    using BlazeAstro.Services.Models.Astronauts.AstronautInfo;
    using BlazeAstro.Services.Models.Astronauts.AstronautsInSpace;
    using BlazeAstro.Services.Models.MarsPhotos;

    public sealed class CachePackage : IPackage
    {
        private bool useInMemoryCache;
        private int absoluteExpiration;
        private readonly IConfiguration configuration;

        public CachePackage(IConfiguration configuration)
        {
            this.configuration = configuration;
            useInMemoryCache = bool.Parse(configuration["Cache:UseInMemoryCache"]);
            absoluteExpiration = int.Parse(configuration["Cache:AbsoluteExpiration"]);
        }

        public void RegisterServices(IServiceCollection services)
        {
            RegisterCacheService<IEnumerable<ApodResponseModel>>(services);
            RegisterCacheService<AstronautsResponseModel>(services);
            RegisterCacheService<AstronautInfoResponseModel>(services);
            RegisterCacheService<MarsPhotosResponseModel>(services);

            if (!useInMemoryCache)
            {
                services.AddStackExchangeRedisCache(options =>
                {
                    options.InstanceName = "BlazeAstroDb";
                    options.Configuration = configuration["Cache:ConnectionStrings:Redis"];
                });
            }
        }

        private void RegisterCacheService<TValue>(IServiceCollection services)
            where TValue : class
        {
            if (useInMemoryCache)
            {
                services.AddTransient<ICacheService<TValue>, InMemoryCacheService<TValue>>(x =>
                new InMemoryCacheService<TValue>(
                    x.GetRequiredService<IMemoryCache>(),
                    absoluteExpiration));
            }
            else
            {
                services.AddTransient<ICacheService<TValue>, DistributedCacheService<TValue>>(x =>
                new DistributedCacheService<TValue>(
                    x.GetRequiredService<IDistributedCache>(),
                    absoluteExpiration));
            }
        }
    }
}