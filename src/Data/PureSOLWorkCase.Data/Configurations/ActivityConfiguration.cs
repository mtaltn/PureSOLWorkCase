using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PureSOLWorkCase.Domain;

namespace PureSOLWorkCase.Data;

internal class ActivityConfiguration : IEntityTypeConfiguration<Activity>
{
    public void Configure(EntityTypeBuilder<Activity> builder)
    {
        builder.HasKey(a => a.ActivityId);

        builder.Property(a => a.ActivityType)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(a => a.ActivityDate)
               .IsRequired();

        builder.Property(a => a.Description)
               .HasMaxLength(500);

        builder.HasOne<User>()
               .WithMany(u => u.Activities)
               .HasForeignKey(a => a.UserId);
    }
}
