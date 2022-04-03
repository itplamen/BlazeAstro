namespace BlazeAstro.Infrastructure.IoCContainer
{
    using Microsoft.Extensions.DependencyInjection;

    using BlazeAstro.Infrastructure.IoCContainer.Contracts;
    using BlazeAstro.Infrastructure.IoCContainer.IoCPackages;
    using Microsoft.Extensions.Configuration;

    public static class IoCContainer
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            IPackage[] packages = new IPackage[]
            {
                new CachePackage(configuration),
                new DataProvidersPackage()
            };

            foreach (var package in packages)
            {
                package.RegisterServices(services);
            }
        }
    }
}
