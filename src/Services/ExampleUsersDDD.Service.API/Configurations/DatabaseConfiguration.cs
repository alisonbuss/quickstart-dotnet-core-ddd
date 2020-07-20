
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.EntityFrameworkCore;

using ExampleUsersDDD.Infra.Data.Context;

namespace ExampleUsersDDD.Service.API.Configurations
{
    public static class DatabaseConfiguration
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) 
                throw new ArgumentNullException(nameof(services));

            services.AddDbContext<DbContextBase>(options =>
                    options.UseInMemoryDatabase(databaseName: "InMemoryDataSource"));

            // Or:
            // services.AddDbContext<DbContextBase>(options =>
            //         options.UseSqlite(configuration.GetConnectionString("SqliteConnection")));

            // Or:
            // services.AddDbContext<DbContextBase>(options =>
            //         options.UseSqlServer(configuration.GetConnectionString("SqlServerConnection")));

            services.AddScoped<DbContextBase, DbContextBase>();
        }

    }
}
