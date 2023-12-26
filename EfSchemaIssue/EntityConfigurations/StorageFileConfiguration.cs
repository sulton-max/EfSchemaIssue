using EfSchemaProblem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfSchemaProblem.EntityConfigurations;

public class StorageFileConfiguration : IEntityTypeConfiguration<StorageFile>
{
    public void Configure(EntityTypeBuilder<StorageFile> builder)
    {
        builder.Property(x => x.Name).IsRequired().HasMaxLength(256);
    }
}