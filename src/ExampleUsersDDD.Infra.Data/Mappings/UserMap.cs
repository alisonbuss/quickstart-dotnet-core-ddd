
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
                .HasColumnName("PasswordHash") // Hash Algorithm: SHA256
                .HasColumnType("varchar(66)")
                .HasMaxLength(66)
                .IsRequired();

            builder.Property(entity => entity.Registered)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(entity => entity.Status)
                .HasConversion<string>() // Convert Enum to String
                .HasColumnType("varchar(13)")
                .HasMaxLength(13)
                .IsRequired();

            builder.Property(entity => entity.Group)
                .HasColumnType("varchar(66)")
                .HasMaxLength(66)
                .IsRequired();

            builder.Property(entity => entity.Roles)
                .HasColumnType("varchar(99)")
                .HasMaxLength(99);

            // Columns - User:
            builder.Property(entity => entity.Photo)
                //.HasColumnType("varbinary(max)");
                .HasColumnType("varchar(77)")
                .HasMaxLength(77);

            builder.Property(entity => entity.Nickname)
                .HasColumnType("varchar(66)")
                .HasMaxLength(66);

            builder.Property(entity => entity.FirstName)
                .HasColumnType("varchar(66)")
                .HasMaxLength(66);

            builder.Property(entity => entity.LastName)
                .HasColumnType("varchar(99)")
                .HasMaxLength(99);

            builder.Ignore(entity => entity.FullName);

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
