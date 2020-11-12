using Microsoft.Extensions.DependencyInjection;
using Taxpayer.Application.Implementation;
using Taxpayer.Application.Interface;
using Taxpayer.Domain.Interface.Services;
using Taxpayer.Domain.Interface.UnitOfWork;
using Taxpayer.Domain.Services;
using Taxpayer.Infra.Data.UnitOfWork;

namespace Taxpayer.Infra.CrossCutting.IoC.Resolvers
{
    public static class ServicesResolver
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IEmployeeAppService, EmployeeAppService>();

            return services;
        }
    }
}