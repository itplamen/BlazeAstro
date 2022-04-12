namespace BlazeAstro.Infrastructure.IoCContainer.IoCPackages
{
    using System.Collections.Generic;
    using System.Net.Http;

    using AngleSharp.Html.Parser;

    using Microsoft.Extensions.DependencyInjection;

    using BlazeAstro.Infrastructure.IoCContainer.Contracts;
    using BlazeAstro.Services.Cache.Contracts;
    using BlazeAstro.Services.DataProviders;
    using BlazeAstro.Services.DataProviders.Contracts;
    using BlazeAstro.Services.Models.Apod;
    using BlazeAstro.Services.Models.Astronauts.AstronautInfo;
    using BlazeAstro.Services.Models.Astronauts.AstronautsInSpace;
    using BlazeAstro.Services.Models.Contracts;
    using BlazeAstro.Services.Models.MarsPhotos;

    public sealed class DataProvidersPackage : IPackage
    {
        public void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton(new HttpClient());
            services.AddSingleton(new HtmlParser());

            services.AddTransient<ApodDataProvider>();
            services.AddTransient<AstronautsDataProvider>();
            services.AddTransient<MarsPhotosDataProvider>();

            RegisterDecorator<ApodRequestModel, IEnumerable<ApodResponseModel>, ApodDataProvider>(services);
            RegisterDecorator<AstronautsRequestModel, AstronautsResponseModel, AstronautsDataProvider>(services);
            RegisterDecorator<AstronautInfoRequestModel, AstronautInfoResponseModel, AstronautsDataProvider>(services);
            RegisterDecorator<MarsPhotosRequestModel, MarsPhotosResponseModel, MarsPhotosDataProvider>(services);
        }

        private void RegisterDecorator<TRequest, TResponse, TDataProvider>(IServiceCollection services)
            where TRequest : IRequest
            where TResponse : class
            where TDataProvider : IDataProvider<TRequest, TResponse>
        {
            services.AddTransient<IDataProvider<TRequest, TResponse>, CacheDataProvider<TRequest, TResponse>>(x =>
            new CacheDataProvider<TRequest, TResponse>(
                x.GetRequiredService<ICacheService<TResponse>>(),
                x.GetRequiredService<TDataProvider>()));
        }
    }
}