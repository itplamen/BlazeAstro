namespace BlazeAstro.Services.DataProviders
{
    using System.Threading.Tasks;

    using BlazeAstro.Services.Cache.Contracts;
    using BlazeAstro.Services.DataProviders.Contracts;
    using BlazeAstro.Services.Models.Contracts;

    public class CacheDataProvider<TRequest, TResponse> : IDataProvider<TRequest, TResponse>
        where TRequest : IRequest
        where TResponse : class
    {
        private readonly ICacheService<TResponse> cacheService;
        private readonly IDataProvider<TRequest, TResponse> decorated;

        public CacheDataProvider(ICacheService<TResponse> cacheService, IDataProvider<TRequest, TResponse> decorated)
        {
            this.cacheService = cacheService;
            this.decorated = decorated;
        }

        public async Task<TResponse> GetData(TRequest request)
        {
            var cacheData = await cacheService.Get(request.CacheKey);

            if (cacheData == null)
            {
                var response = await decorated.GetData(request);
                await cacheService.Set(request.CacheKey, response);

                return response;
            }

            return cacheData;
        }
    }
}