using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using WebApplication1.Interfaces;
using WebApplication1.Mapping;
using WebApplication1.Migrations;
using WebApplication1.Models;
using WebApplication1.Settings;

namespace WebApplication1
{
    public class Startup
    {
        PostgresSettings postgresSettings;
        RoutesSettings routesSettings;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var postgresSection = Configuration.GetSection("Postgres");
            postgresSettings = postgresSection.Get<PostgresSettings>();

            var routesSection = Configuration.GetSection("Routes");
            routesSettings = routesSection.Get<RoutesSettings>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddScoped<IResultRepository, ResultRepository>();

            if (postgresSettings != null && postgresSettings.ConnectionString != null)
            {
                services.AddSingleton(postgresSettings);
            }

            if (routesSettings != null && routesSettings.GetDataAddress != null)
            {
                services.AddSingleton(routesSettings);
            }


        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime applicationLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            applicationLifetime.ApplicationStarted.Register(OnApplicationStarted);

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "api/{controller}/{action}/{id?}");
            });
        }

        protected void OnApplicationStarted()
        {
            try
            {
                var migrator = new DbMigrator(postgresSettings);
                var mapping = new InitializeMappings();

                migrator.StartMigration();
                mapping.Initialize();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
