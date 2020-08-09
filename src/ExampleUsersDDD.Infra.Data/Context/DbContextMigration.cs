
// EF Core Migrations with DbContext in Separate Library
// https://manojchoudhari.wordpress.com/2019/03/18/ef-cire-migrations-with-dbcontext-in-separate-library/
// https://medium.com/oppr/net-core-using-entity-framework-core-in-a-separate-project-e8636f9dc9e5
// https://code-maze.com/migrations-and-seed-data-efcore/

using System.IO;
using Microsoft.Extensions.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

using ExampleUsersDDD.Domain.Entities;
using ExampleUsersDDD.Infra.Data.Mappings;

namespace ExampleUsersDDD.Infra.Data.Context
{
    public class DbContextMigration : DbContext
    {
        public DbContextMigration(DbContextOptions<DbContextMigration> options) : base(options)
        {
         
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new UserMap());
                        
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<User> User { get; set; }

    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DbContextMigration>
    {
        public DbContextMigration CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Migration.json")
                .Build();
            var connectionString = configuration.GetConnectionString("SqlServerConnection");

            // Database Connection:
            var builder = new DbContextOptionsBuilder<DbContextMigration>();
            // builder.UseInMemoryDatabase(databaseName: "InMemoryDataSource");
            // Or:
            // builder.UseSqlite(connectionString);
            // Or:
            builder.UseSqlServer(connectionString);

            return new DbContextMigration(builder.Options);
        }
    }
}
