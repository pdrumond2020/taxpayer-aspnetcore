using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Taxpayer.Infra.CrossCutting.IoC;
using Taxpayer.Web.Extensions;

namespace Taxpayer.Web
{
    public class Startup
    {
        //public Startup(IWebHostEnvironment env)
        //{
        //    var builder = new ConfigurationBuilder()
        //        .SetBasePath(env.ContentRootPath)
        //        .AddJsonFile("AppSettings/appsettings.json", true, true)
        //        .AddJsonFile($"AppSettings/appsettings.{env.EnvironmentName}.json", true, true);

        //    builder.AddEnvironmentVariables();

        //    Configuration = builder.Build();
        //}

        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("AppSettings/appsettings.json", true, true)
                .AddJsonFile($"AppSettings/appsettings.{env.EnvironmentName}.json", true, true);

            builder.AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ResolveApi(Configuration);

            //services.AddCors();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMiddleware<CustomExceptionMiddleware>();

            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }
            else
            {
                app.UseStaticFiles();
            }

            app.UseRouting();

            //app.UseCors(c =>
            //{
            //    c.AllowAnyHeader();
            //    c.AllowAnyMethod();
            //    c.AllowAnyOrigin();
            //});

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    //spa.UseAngularCliServer(npmScript: "start");
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                }
            });

            app.UseSwaggerSetup();
        }
    }
}