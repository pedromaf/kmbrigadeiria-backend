using KMBrigadeiria.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace KMBrigadeiria.Data
{
    public class KMContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }

        public KMContext(DbContextOptions<KMContext> opt) : base(opt)
        {

        }

    }
}
