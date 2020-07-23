
using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;

using ExampleUsersDDD.Domain.Entities;
using ExampleUsersDDD.Infra.Data.Mappings;
using System.Linq;

namespace ExampleUsersDDD.Infra.Data.Context
{
    public class DbContextBase : DbContext
    {
        public DbContextBase(DbContextOptions<DbContextBase> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Ignore<ValidationResult>();
            //modelBuilder.Ignore<Event>();

            // foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
            //     e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            //     property.SetColumnType("varchar(100)");

            // https://thecodebuzz.com/efcore-dbcontext-cannot-access-disposed-object-net-core/

            // FONT: https://stackoverflow.com/questions/46837617/where-are-entity-framework-core-conventions
            // modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            // modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            // modelBuilder.EntityTypes()
            //     .Configure(et => et.SetTableName(et.DisplayName()));

            // modelBuilder.Properties()
            //     .Where(x => x.Name == "Id")
            //     .Configure(p => p.SetColumnName(BaseName(p.DeclaringEntityType.Name) + "Id"));

            // font https://stackoverflow.com/questions/46526230/disable-cascade-delete-on-ef-core-2-globally
            // builder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            // builder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            // protected override void OnModelCreating(ModelBuilder modelBuilder)
            // {
            //     // ...

            //     var cascadeFKs = modelBuilder.Model.GetEntityTypes()
            //         .SelectMany(t => t.GetForeignKeys())
            //         .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            //     foreach (var fk in cascadeFKs)
            //         fk.DeleteBehavior = DeleteBehavior.Restrict;

            //     base.OnModelCreating(modelBuilder);
            // }

            // foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
            //     e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            //     property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfiguration(new ProductMap());
                        
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Product { get; set; }

    }
}
