
using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ExampleUsersDDD.Domain.Entities;

namespace ExampleUsersDDD.Infra.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            // Define specific table name.
            builder.ToTable("Users");

            // Create primary key: 
            builder
                .HasKey(entity => entity.Id);
            // Or:
            // builder.Property(entity => entity.Id)
            //     .HasColumnName("Id")
            //     .UseSerialColumn();

            // Columns - Account:
            builder.Property(entity => entity.Email)
                .HasColumnType("varchar(99)")
                .HasMaxLength(99)
                .IsRequired();

            builder.Property(entity => entity.Password)
                .HasColumnName("HashPassword") // Hash Algorithm: SHA256
                .HasColumnType("varchar(66)")
                .HasMaxLength(66)
                .IsRequired();

            builder.Property(entity => entity.Registered)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(entity => entity.IsConfirmed)
                .HasColumnName("Confirmed")
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(entity => entity.IsActive)
                .HasColumnName("Active")
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(entity => entity.Group)
                .HasColumnType("varchar(66)")
                .HasMaxLength(66)
                .IsRequired();

            builder.Ignore(entity => entity.Roles);

            // Columns - User:
            builder.Property(entity => entity.Photo)
                .HasColumnType("varbinary(max)");

            builder.Property(entity => entity.Nickname)
                .HasColumnType("varchar(66)")
                .HasMaxLength(66);

            builder.Property(entity => entity.FirstName)
                .HasColumnType("varchar(66)")
                .HasMaxLength(66);

            builder.Property(entity => entity.FullName)
                .HasColumnType("varchar(99)")
                .HasMaxLength(99);

            builder.Property(entity => entity.Phone)
                .HasColumnType("varchar(18)")
                .HasMaxLength(18);

            builder.Property(entity => entity.BirthDate)
                .HasColumnType("datetime");  

            builder.Property(entity => entity.Gender)
                .HasColumnType("char")
                .HasMaxLength(1);

            // Add Indexing:
            builder.HasIndex(entity => entity.Email).IsUnique();
            builder.HasIndex(entity => entity.Nickname).IsUnique();
            
        }
        
    }
}
