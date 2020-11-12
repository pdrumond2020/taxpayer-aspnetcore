using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Taxpayer.Infra.Data.Context;

namespace Taxpayer.Infra.CrossCutting.IoC.Resolvers
{
    public static class ContextResolver
    {
        public static IServiceCollection ConfigureContext(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<SqlContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), options => options.EnableRetryOnFailure()));

            services.AddScoped<SqlContext, SqlContext>();

            return services;
        }
    }
}