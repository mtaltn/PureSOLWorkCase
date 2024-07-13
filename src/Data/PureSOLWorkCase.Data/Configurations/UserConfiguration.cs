using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PureSOLWorkCase.Domain;

namespace PureSOLWorkCase.Data;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.UserId);

        builder.Property(u => u.Name)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(u => u.Email)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(u => u.JoinDate)
               .IsRequired();

        builder.HasMany(u => u.Activities)
               .WithOne()
               .HasForeignKey(a => a.UserId);
    }
}
