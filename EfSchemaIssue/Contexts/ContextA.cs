using System.Collections.Immutable;
using EfSchemaProblem.EntityConfigurations;
using EfSchemaProblem.Models;
using Microsoft.EntityFrameworkCore;

namespace EfSchemaProblem.Contexts;

public class ContextA(DbContextOptions<ContextA> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    
    public ContextA() : this(new DbContextOptionsBuilder<ContextA>()
        .UseNpgsql("Host=localhost;Port=5432;Database=EFTest.Identity;Username=postgres;Password=postgres")
        .Options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Identity");
        
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}