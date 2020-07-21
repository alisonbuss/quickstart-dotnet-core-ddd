
using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

using Serilog;

namespace ExampleUsersDDD.Service.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var hostBuilder = CreateHostBuilder(args).Build();

                Serilog.Log.Information("Starting web host...");

                hostBuilder.Run();
            }
            catch (Exception exception)
            {
                Serilog.Log.Fatal(exception, "Host terminated unexpectedly.");
            }
            finally
            {
                Serilog.Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    // FONT: https://github.com/serilog/serilog-sinks-file
                    // FONT: https://github.com/serilog/serilog-sinks-console
                    // Serilog.Log.Logger = new Serilog.LoggerConfiguration()
                    //     .WriteTo.Console()
                    //     .WriteTo.File("log_service_api_.txt", 
                    //         rollingInterval: RollingInterval.Day, 
                    //         fileSizeLimitBytes: 666666, 
                    //         rollOnFileSizeLimit: true
                    //     )
                    //     .CreateLogger();

                    // Or

                    // FONT: https://github.com/serilog/serilog-settings-configuration
                    var appsettings = config.Build();
                    Serilog.Log.Logger = new Serilog.LoggerConfiguration()
                        .ReadFrom.Configuration(appsettings)
                        .CreateLogger();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

    }
}