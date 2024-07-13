using Microsoft.EntityFrameworkCore;
using PureSOLWorkCase.Domain;
using System.Reflection;

namespace PureSOLWorkCase.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Activity> Activities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new UserSeed()); 
        modelBuilder.ApplyConfiguration(new ActivityConfiguration());
        modelBuilder.ApplyConfiguration(new ActivitySeed()); 

        // if u wanna use Assembly you use like that
        //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());  

        /*
             *If you want to enable only one of the IEntityTypeConfiguration contents, but not all of them, you can use this configuration.
            modelBuilder.ApplyConfiguration(new ActivityConfiguration());
            */

        /*
         * If you want, you can add seed data this way as well.
        modelBuilder.Entity<Activity>().HasData(new ProductFeature() {
            ActivityId = 1,
            UserId = 1,
            ActivityType = "Login",
            ActivityDate = new DateTime(2023, 3, 1),
            Description = "Login Successfully."
        });
        */
        base.OnModelCreating(modelBuilder);
    }
}
