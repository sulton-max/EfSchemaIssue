using EfSchemaProblem.EntityConfigurations;
using EfSchemaProblem.Models;
using Microsoft.EntityFrameworkCore;

namespace EfSchemaProblem.Contexts;

public class ContextB(DbContextOptions<ContextB> options) : DbContext(options)
{
    public DbSet<StorageFile> Users => Set<StorageFile>();
    
    public ContextB() : this(new DbContextOptionsBuilder<ContextB>()
        .UseNpgsql("Host=localhost;Port=5432;Database=EfTest.Files;Username=postgres;Password=postgres")
        .Options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Files");
        
        modelBuilder.ApplyConfiguration(new StorageFileConfiguration());
    }
}