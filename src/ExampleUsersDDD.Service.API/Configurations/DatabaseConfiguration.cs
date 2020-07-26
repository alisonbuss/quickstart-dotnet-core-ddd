
using System;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Microsoft.EntityFrameworkCore;

using ExampleUsersDDD.Domain.Entities;
using ExampleUsersDDD.Infra.Data.Context;

namespace ExampleUsersDDD.Service.API.Configurations
{
    public static class DatabaseConfiguration
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) 
                throw new ArgumentNullException(nameof(services));

            // services.AddDbContext<DbContextBase>(options =>
            //         options.UseInMemoryDatabase(databaseName: "InMemoryDataSource"));

            // Or:
            // services.AddDbContext<DbContextBase>(options =>
            //         options.UseSqlite(configuration.GetConnectionString("SqliteConnection")));

            // Or:
            services.AddDbContext<DbContextBase>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("SqlServerConnection")));

            services.AddScoped<DbContextBase, DbContextBase>();
        }

        public static void UseDatabaseConfiguration(
            this IApplicationBuilder app, IWebHostEnvironment environment, DbContextBase dbContextBase
        )
        {
            if (environment.IsDevelopment())
            {
                // Drop the database if it exists.
                dbContextBase.Database.EnsureDeleted();
                
                // Create the database if it doesn't exist.
                dbContextBase.Database.EnsureCreated();

                // Add Users for Test:
                dbContextBase.Set<User>().Add(new User("lucifer@formhell.com", "666", DateTime.Today, false, true, "System"));
                dbContextBase.Set<User>().Add(new User("beelzebub@formhell.com", "password666", DateTime.Today, false, true, "System"));
                dbContextBase.Set<User>().Add(new User("mammon@formhell.com", "password666", DateTime.Today, false, true, "System"));
                dbContextBase.Set<User>().Add(new User("azazel@formhell.com", "password666", DateTime.Today, false, true, "System"));
                dbContextBase.Set<User>().Add(new User("asmodeus@formhell.com", "password666", DateTime.Today, false, true, "System"));
                dbContextBase.Set<User>().Add(new User("leviathan@formhell.com", "password666", DateTime.Today, false, true, "System"));
                dbContextBase.Set<User>().Add(new User("belphegor@formhell.com", "password666", DateTime.Today, false, true, "System"));
                dbContextBase.SaveChanges();
            }

        }

    }
}
