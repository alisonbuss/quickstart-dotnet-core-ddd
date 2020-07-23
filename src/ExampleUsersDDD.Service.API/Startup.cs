using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using ExampleUsersDDD.Service.API.Configurations;
using Microsoft.AspNetCore.Http;
using ExampleUsersDDD.Infra.Data.Context;

using Serilog;

namespace ExampleUsersDDD.Service.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: false)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // WebAPI Config.
            services.AddControllers();

            // Setting DBContexts.
            services.AddDatabaseConfiguration(Configuration);

            // .NET Native DI Abstraction.
            services.AddDependencyInjectionConfiguration();

            // Details of the problem of the (Model State).
            services.AddProblemDetailsModelStateConfiguration();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory, DbContextBase dbContextBase)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Drop the database if it exists.
                dbContextBase.Database.EnsureDeleted();
                // Create the database if it doesn't exist.
                dbContextBase.Database.EnsureCreated();
            }

            // Details of the problem of the (Exception Handler).
            app.UseProblemDetailsExceptionHandlerConfiguration(loggerFactory);

            // Middleware that uses Serilog to log requests to Endpoints.
            app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseCors(crossOriginRequest =>
            {
                crossOriginRequest.WithMethods("OPTIONS", "GET", "POST", "PUT", "DELETE", "PATCH");
                crossOriginRequest.AllowAnyOrigin();
                crossOriginRequest.AllowAnyHeader();
                crossOriginRequest.WithExposedHeaders("x-perpro", "Cache-control", "Pragma", "x-hubin-info");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync($" Hello World! Environment({env.EnvironmentName})");
                });

                endpoints.MapControllers();
            });
        }
        
    }
}
