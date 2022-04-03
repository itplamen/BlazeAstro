using System.Reflection;

using AngleSharp.Html.Parser;

using Microsoft.Extensions.Caching.Distributed;

using Newtonsoft.Json;

using BlazeAstro.Infrastructure.Mapping;
using BlazeAstro.Services.DataProviders;
using BlazeAstro.Services.DataProviders.Contracts;
using BlazeAstro.Services.Models.Apod;
using BlazeAstro.Services.Models.Astronauts.AstronautInfo;
using BlazeAstro.Services.Models.Astronauts.AstronautsInSpace;
using BlazeAstro.Services.Models.MarsPhotos;
using BlazeAstro.Web.Shared.Models.Api;
using BlazeAstro.Web.Shared.Models.Apod;
using BlazeAstro.Web.Shared.Models.Mars;
using BlazeAstro.Web.Shared.Validations.Apod;
using BlazeAstro.Web.Shared.Validations.Contracts;
using BlazeAstro.Web.Shared.Validations.Mars;
using BlazeAstro.Services.Cache.Contracts;
using BlazeAstro.Services.Cache;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddAutoMapper((_, config) => 
    config.AddProfile(new MappingProfile(typeof(ApodInputModel).GetTypeInfo().Assembly)), 
    Array.Empty<Assembly>());

builder.Services.AddScoped<IRequestValidation<ApodInputModel>, ApodDateRequestValidation>();
builder.Services.AddScoped<IRequestValidation<ApodInputModel>, ApodDateRangesRequestValidation>();
builder.Services.AddScoped<IRequestValidation<ApodInputModel>, ApodCountRequestValidation>();
builder.Services.AddScoped<IRequestValidation<MarsInputModel>, MarsRequestValidation>();

builder.Services.AddSingleton(new HttpClient());
builder.Services.AddSingleton<IHtmlParser, HtmlParser>();

builder.Services.AddTransient<ApodDataProvider>();
builder.Services.AddTransient<AstronautsDataProvider>();
builder.Services.AddTransient<MarsPhotosDataProvider>();

builder.Services.AddTransient<ICacheService<IEnumerable<ApodResponseModel>>, InMemoryCacheService<IEnumerable<ApodResponseModel>>>();
builder.Services.AddTransient<ICacheService<AstronautsResponseModel>, InMemoryCacheService<AstronautsResponseModel>>();
builder.Services.AddTransient<ICacheService<AstronautInfoResponseModel>, InMemoryCacheService<AstronautInfoResponseModel>>();
builder.Services.AddTransient<ICacheService<MarsPhotosResponseModel>, InMemoryCacheService<MarsPhotosResponseModel>>();
//builder.Services.AddTransient<ICacheService<IEnumerable<ApodResponseModel>>, DistributedCacheService<IEnumerable<ApodResponseModel>>>();
//builder.Services.AddTransient<ICacheService<AstronautsResponseModel>, DistributedCacheService<AstronautsResponseModel>>();
//builder.Services.AddTransient<ICacheService<AstronautInfoResponseModel>, DistributedCacheService<AstronautInfoResponseModel>>();
//builder.Services.AddTransient<ICacheService<MarsPhotosResponseModel>, DistributedCacheService<MarsPhotosResponseModel>>();

//builder.Services.AddTransient<IDataProvider<ApodRequestModel, IEnumerable<ApodResponseModel>>,
//    CacheDataProvider<ApodRequestModel, IEnumerable<ApodResponseModel>>>(x =>
//    new CacheDataProvider<ApodRequestModel, IEnumerable<ApodResponseModel>>(
//        x.GetRequiredService<IDistributedCache>(),
//        x.GetRequiredService<ApodDataProvider>()));

builder.Services.AddTransient<IDataProvider<ApodRequestModel, IEnumerable<ApodResponseModel>>,
    CacheDataProvider<ApodRequestModel, IEnumerable<ApodResponseModel>>>(x =>
    new CacheDataProvider<ApodRequestModel, IEnumerable<ApodResponseModel>>(
        x.GetRequiredService<ICacheService<IEnumerable<ApodResponseModel>>>(),
        x.GetRequiredService<ApodDataProvider>()));

builder.Services.AddTransient<IDataProvider<AstronautsRequestModel, AstronautsResponseModel>,
    CacheDataProvider<AstronautsRequestModel, AstronautsResponseModel>>(x =>
    new CacheDataProvider<AstronautsRequestModel, AstronautsResponseModel>(
        x.GetRequiredService<ICacheService<AstronautsResponseModel>>(),
        x.GetRequiredService<AstronautsDataProvider>()));

builder.Services.AddTransient<IDataProvider<AstronautInfoRequestModel, AstronautInfoResponseModel>,
    CacheDataProvider<AstronautInfoRequestModel, AstronautInfoResponseModel>>(x =>
    new CacheDataProvider<AstronautInfoRequestModel, AstronautInfoResponseModel>(
        x.GetRequiredService<ICacheService<AstronautInfoResponseModel>>(),
        x.GetRequiredService<AstronautsDataProvider>()));

builder.Services.AddTransient<IDataProvider<MarsPhotosRequestModel, MarsPhotosResponseModel>,
    CacheDataProvider<MarsPhotosRequestModel, MarsPhotosResponseModel>>(x =>
    new CacheDataProvider<MarsPhotosRequestModel, MarsPhotosResponseModel>(
        x.GetRequiredService<ICacheService<MarsPhotosResponseModel>>(),
        x.GetRequiredService<MarsPhotosDataProvider>()));

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.InstanceName = "BlazeAstro";
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseHsts();
    app.UseExceptionHandler(exceptionHandlerApp =>
    {
        exceptionHandlerApp.Run(async context =>
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(new ApiResponse() { ErrorMessage = "Could not retrieve data. Please try again" }));
        });
    });

}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();