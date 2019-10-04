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

namespace WebApplication1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton(Configuration.GetSection("ConnectionStrings"));
            services.AddScoped<IResultRepository, ResultRepository>();
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
            var migrator = new DbMigrator(Configuration.GetSection("PostgresqlConnection").Value);
            var mapping = new InitializeMappings();

            migrator.StartMigration();
            mapping.Initialize();
        }
    }
}
