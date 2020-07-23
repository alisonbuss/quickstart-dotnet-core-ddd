
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ExampleUsersDDD.Domain.Entities;
using System;

namespace ExampleUsersDDD.Infra.Data.Mappings
{    
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            // Create primary key: 
            builder
                .HasKey(entity => entity.Id);
            // Or:
            // builder.Property(entity => entity.Id)
            //     .HasColumnName("Id")
            //     .UseSerialColumn();

            builder.Property(entity => entity.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(entity => entity.Price)
                .HasColumnType("decimal(5,2)")
                .IsRequired();

            // builder.Property(entity => entity.IsActive)
            //     .HasColumnName("Active")
            //     .HasColumnType("bit");

            builder.Property(entity => entity.Description)
                .HasColumnType("varchar(333)")
                .HasMaxLength(333)
                .IsRequired();  
        }
        
    }
}
