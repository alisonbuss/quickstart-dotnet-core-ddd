
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.EntityFrameworkCore;

//using ExampleUsersDDD.Infra.Data.Context;

namespace ExampleUsersDDD.Service.API.Configurations
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            // if (services == null) 
                // throw new ArgumentNullException(nameof(services));

            // services.AddDbContext<ContextBase>(options =>
            //     options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


            if (services == null) 
                throw new ArgumentNullException(nameof(services));

            services.AddDbContext<ExampleUsersDDD.Infra.Data.Context.ContextBase>(options => 
                options.UseInMemoryDatabase(databaseName: "InMemoryDb"));

        }

    }
}
