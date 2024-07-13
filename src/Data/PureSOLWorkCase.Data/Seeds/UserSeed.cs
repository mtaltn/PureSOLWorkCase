using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PureSOLWorkCase.Domain;
using System;

namespace PureSOLWorkCase.Data;

internal class UserSeed : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(
            new User
            {
                UserId = 1,
                Name = "John Doe",
                Email = "john.doe@example.com",
                JoinDate = new DateTime(2023, 1, 1)
            },
            new User
            {
                UserId = 2,
                Name = "Jane Smith",
                Email = "jane.smith@example.com",
                JoinDate = new DateTime(2023, 2, 15)
            }
        );
    }
}
