using Microsoft.Extensions.DependencyInjection;
using Taxpayer.Domain.Interface.Repositories;
using Taxpayer.Infra.Data.Repositories;

namespace Taxpayer.Infra.CrossCutting.IoC.Resolvers
{
    public static class RepositoriesResolver
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();

            return services;
        }
    }
}