using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PureSOLWorkCase.Domain;

namespace PureSOLWorkCase.Data;

internal class ActivitySeed : IEntityTypeConfiguration<Activity>
{
    public void Configure(EntityTypeBuilder<Activity> builder)
    {
        builder.HasData(
            new Activity
            {
                ActivityId = 1,
                UserId = 1,
                ActivityType = "Login",
                ActivityDate = new DateTime(2023, 3, 1),
                Description = "Login Successfully."
            },
            new Activity
            {
                ActivityId = 2,
                UserId = 2,
                ActivityType = "PageView",
                ActivityDate = new DateTime(2023, 3, 2),
                Description = "Profile"
            },
            new Activity
            {
                ActivityId = 3,
                UserId = 1,
                ActivityType = "PageView",
                ActivityDate = new DateTime(2023, 3, 3),
                Description = "Games"
            }
        );
    }
}
