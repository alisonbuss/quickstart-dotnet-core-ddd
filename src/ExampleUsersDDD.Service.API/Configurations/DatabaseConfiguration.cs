
using System;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Microsoft.EntityFrameworkCore;

using ExampleUsersDDD.Domain.Entities;
using ExampleUsersDDD.Infra.Data.Context;
using System.IO;

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

                // Add 7 initial users to the system for testing:
                foreach (var user in "lucifer,beelzebub,mammon,azazel,asmodeus,leviathan,belphegor".Split(','))
                {
                    var newUser = new User(
                        $"{user}@formhell.com",  // Email
                        "P@ssw0rdT0He11666",     // Password
                        "Fallen Angels"          // Group
                    );
                    dbContextBase.Set<User>().Add(newUser);
                }
                dbContextBase.SaveChanges();
            }

        }

    }
}
