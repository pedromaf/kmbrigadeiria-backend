using KMBrigadeiria.Authentication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KMBrigadeiria.Authentication.Data
{
    public class AuthDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        private readonly IConfiguration _config;

        public AuthDbContext(DbContextOptions<AuthDbContext> opt, IConfiguration config) : base(opt)
        {
            _config = config;
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            IdentityUser<int> admin = new IdentityUser<int>
            {
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "pedro.maf666@gmail.com",
                NormalizedEmail = "PEDRO.MAF666@GMAIL.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                Id = 1,
            };

            PasswordHasher<IdentityUser<int>> hasher = new PasswordHasher<IdentityUser<int>>();

            admin.PasswordHash = hasher.HashPassword(admin, _config.GetValue<string>("admininfo:password"));

            builder.Entity<IdentityUser<int>>().HasData(admin);

            builder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int>
            {
                Id = 1,
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>
            {
                RoleId = 1,
                UserId = 1
            });
        }
    }
}
