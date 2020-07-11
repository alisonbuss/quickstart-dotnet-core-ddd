
using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;

using ExampleUsersDDD.Domain.Entities;
using ExampleUsersDDD.Infra.Data.Mappings;

namespace ExampleUsersDDD.Infra.Data.Context
{
    public class ContextBase : DbContext
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Ignore<ValidationResult>();
            //modelBuilder.Ignore<Event>();

            // foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
            //     e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            //     property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfiguration(new ProductMap());
                        
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // If not configured in the API project.
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(GetStringConectionConfig());
            base.OnConfiguring(optionsBuilder);
        }

        private string GetStringConectionConfig()
        {
            string strCon = "Data Source=DESKTOP-HVNTI80\\DESENVOLVIMENTO;Initial Catalog=DDD_2020_AULA_UPDATE_MIGRATION;Integrated Security=False;User ID=sa;Password=1234;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
            return strCon;
        }

    }
}
