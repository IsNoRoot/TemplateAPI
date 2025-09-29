using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateAPI.Domain.Entities;

namespace TemplateAPI.Infrastructure.Context.Configuration;

public class UserConfiguration:IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder){
            
        builder.ToTable("Users");
        
        builder.OwnsOne(
            user => user.Email,
            addressBuilder =>
            {
                addressBuilder.Property(a => a.Value).HasColumnName("Email");
                addressBuilder.HasIndex(a=>a.Value).IsUnique();

            });
        
        builder.OwnsOne(
            user => user.Age,
            addressBuilder =>
            {
                addressBuilder.Property(a => a.Value).HasColumnName("Age");
            });
        
        builder.OwnsOne(
            user => user.Password,
            addressBuilder =>
            {
                addressBuilder.Property(a => a.Value).HasColumnName("Password");
            });  
        
        builder.Property(e => e.Name)
            .HasColumnName("Name")
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(e => e.FirstName)
            .HasColumnName("FirstName")
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(e => e.LastName)
            .HasColumnName("LastName")
            .HasMaxLength(50)
            .IsRequired();
        
        // builder.Property(e => e.Age)
        //     .HasColumnName("Age")
        //     .IsRequired();
        
        builder.Property(e => e.UserName)
            .HasColumnName("UserName")
            .HasMaxLength(50)
            .IsRequired();
        
        // builder.Property(e => e.Password)
        //     .HasColumnName("Password")
        //     .HasMaxLength(50)
        //     .IsRequired();
        
        // builder.Property(e => e.Email)
        //     .HasColumnName("Email")
        //     .HasMaxLength(100)
        //     .IsRequired();
        
        builder.HasIndex(u => u.UserName)
            .IsUnique();
        
        // builder.HasIndex(u => u.Email)
        //     .IsUnique();

         
    }
}