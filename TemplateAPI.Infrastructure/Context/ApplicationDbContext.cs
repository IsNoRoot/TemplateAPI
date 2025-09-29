using Microsoft.EntityFrameworkCore;
using TemplateAPI.Domain.Entities;
using TemplateAPI.Infrastructure.Context.Configuration;

namespace TemplateAPI.Infrastructure.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<UserEntity> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}
