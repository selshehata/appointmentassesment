using Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Identity.Data
{
    public class AppIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedData(builder);
        }
        private void SeedData(ModelBuilder builder)
        {
            // Seed roles'
            var AdminroleId = 1;
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = AdminroleId.ToString(),
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Patient",
                    NormalizedName = "Patient"
                }
            );

            // Seed admin user
            var adminUserId = Guid.NewGuid().ToString();
            var hasher = new PasswordHasher<ApplicationUser>();

            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = adminUserId,
                    UserName = "selshahat@example.com",
                    NormalizedUserName = "selshahat@example.com",
                    Email = "selshahat@example.com",
                    NormalizedEmail = "selshahat@example.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Admin@123"),
                    SecurityStamp = Guid.NewGuid().ToString()
                }
            );

            // Seed user-role mapping
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = adminUserId,
                    RoleId = AdminroleId.ToString()
                }
            );
        }
    }

    
}
