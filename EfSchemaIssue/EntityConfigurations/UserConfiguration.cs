using EfSchemaProblem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfSchemaProblem.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.FirstName).IsRequired().HasMaxLength(256);
        builder.HasOne(user => user.ProfilePicture).WithOne();
            // .HasForeignKey<User>(user => user.ProfilePictureId).IsRequired();

        builder.Ignore(user => user.ProfilePicture);
    }
}