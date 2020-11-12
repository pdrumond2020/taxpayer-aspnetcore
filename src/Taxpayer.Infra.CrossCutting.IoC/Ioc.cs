using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Taxpayer.Infra.CrossCutting.IoC.Resolvers;

namespace Taxpayer.Infra.CrossCutting.IoC
{
    public static class IoC
    {
        public static IServiceCollection ResolveApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureContext(configuration)
                    .ConfigureServices()
                    .ConfigureRepositories();

            return services;
        }
    }
}