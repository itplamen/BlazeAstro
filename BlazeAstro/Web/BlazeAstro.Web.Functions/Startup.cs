using System;
using System.Reflection;

using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

using BlazeAstro.Infrastructure.IoCContainer;
using BlazeAstro.Infrastructure.Mapping;
using BlazeAstro.Web.Shared.Models.Apod;

[assembly: FunctionsStartup(typeof(BlazeAstro.Web.Functions.Startup))]

namespace BlazeAstro.Web.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddAutoMapper((_, config) =>
                config.AddProfile(new MappingProfile(typeof(ApodInputModel).GetTypeInfo().Assembly)),
                Array.Empty<Assembly>());

            builder.GetContext().Configuration["Cache:UseInMemoryCache"] = "true";
            builder.GetContext().Configuration["Cache:AbsoluteExpiration"] = "86400";

            builder.Services.RegisterServices(builder.GetContext().Configuration);
        }
    }
}