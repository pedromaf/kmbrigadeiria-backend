using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KMBrigadeiria.Authentication.Data
{
    public class AuthDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> opt) : base(opt)
        {
        
        }
    }
}
