using KMBrigadeiria.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace KMBrigadeiria.Data
{
    public class KMContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Client> Clients { get; set; }

        public KMContext(DbContextOptions<KMContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Address>()
                .HasOne(address => address.Client)
                .WithOne(client => client.Address)
                .HasForeignKey<Client>(client => client.AddressId);

        }

    }
}
