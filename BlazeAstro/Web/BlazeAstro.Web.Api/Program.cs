using System.Reflection;

using Newtonsoft.Json;

using BlazeAstro.Infrastructure.IoCContainer;
using BlazeAstro.Infrastructure.Mapping;
using BlazeAstro.Web.Shared.Models.Api;
using BlazeAstro.Web.Shared.Models.Apod;
using BlazeAstro.Web.Shared.Models.Mars;
using BlazeAstro.Web.Shared.Validations.Apod;
using BlazeAstro.Web.Shared.Validations.Contracts;
using BlazeAstro.Web.Shared.Validations.Mars;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddAutoMapper((_, config) => 
    config.AddProfile(new MappingProfile(typeof(ApodInputModel).GetTypeInfo().Assembly)), 
    Array.Empty<Assembly>());

builder.Services.AddScoped<IRequestValidation<ApodInputModel>, ApodDateRequestValidation>();
builder.Services.AddScoped<IRequestValidation<ApodInputModel>, ApodDateRangesRequestValidation>();
builder.Services.AddScoped<IRequestValidation<ApodInputModel>, ApodCountRequestValidation>();
builder.Services.AddScoped<IRequestValidation<MarsInputModel>, MarsRequestValidation>();

builder.Services.RegisterServices(builder.Configuration);

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