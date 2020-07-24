
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Serilog;

using ExampleUsersDDD.Infra.Data.Context;
using ExampleUsersDDD.Service.API.Configurations;
using Microsoft.Extensions.FileProviders;
using System.IO;

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
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
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

            // Serve static files.
            app.UseFileServer(new FileServerOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "StaticFiles/public")),
                RequestPath = "/doc",
                EnableDirectoryBrowsing = true
            });

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
