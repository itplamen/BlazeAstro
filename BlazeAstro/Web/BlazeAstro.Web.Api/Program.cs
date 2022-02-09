using System.Reflection;

using AngleSharp.Html.Parser;

using Microsoft.Extensions.Caching.Distributed;

using BlazeAstro.Infrastructure.Mapping;
using BlazeAstro.Services.DataProviders;
using BlazeAstro.Services.DataProviders.Contracts;
using BlazeAstro.Services.Models.Apod;
using BlazeAstro.Web.Shared.Models.Apod;
using BlazeAstro.Web.Shared.Validations.Apod;
using BlazeAstro.Services.Models.AstronautsInSpace;
using BlazeAstro.Services.Models.Astronauts.AstronautInfo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddAutoMapper((_, config) => 
    config.AddProfile(new MappingProfile(typeof(ApodInputModel).GetTypeInfo().Assembly)), 
    Array.Empty<Assembly>());

builder.Services.AddScoped<IApodRequestValidation, ApodDateRequestValidation>();
builder.Services.AddScoped<IApodRequestValidation, ApodDateRangesRequestValidation>();
builder.Services.AddScoped<IApodRequestValidation, ApodCountRequestValidation>();

builder.Services.AddSingleton(new HttpClient());
builder.Services.AddSingleton<IHtmlParser, HtmlParser>();

builder.Services.AddTransient<ApodDataProvider>();
builder.Services.AddTransient<AstronautsDataProvider>();
builder.Services.AddTransient<MarsPhotosDataProvider>();

builder.Services.AddTransient<IDataProvider<ApodRequestModel, IEnumerable<ApodResponseModel>>,
    CacheDataProvider<ApodRequestModel, IEnumerable<ApodResponseModel>>>(x =>
    new CacheDataProvider<ApodRequestModel, IEnumerable<ApodResponseModel>>(
        x.GetRequiredService<IDistributedCache>(),
        x.GetRequiredService<ApodDataProvider>()));

builder.Services.AddTransient<IDataProvider<AstronautsRequestModel, AstronautsResponseModel>,
    CacheDataProvider<AstronautsRequestModel, AstronautsResponseModel>>(x =>
    new CacheDataProvider<AstronautsRequestModel, AstronautsResponseModel>(
        x.GetRequiredService<IDistributedCache>(),
        x.GetRequiredService<AstronautsDataProvider>()));

builder.Services.AddTransient<IDataProvider<AstronautInfoRequestModel, AstronautInfoResponseModel>,
    CacheDataProvider<AstronautInfoRequestModel, AstronautInfoResponseModel>>(x =>
    new CacheDataProvider<AstronautInfoRequestModel, AstronautInfoResponseModel>(
        x.GetRequiredService<IDistributedCache>(),
        x.GetRequiredService<AstronautsDataProvider>()));

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
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();